using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using dcim.dialogs;
using dcim.objects;
using System.Data;

namespace dcim.dataprovider
{
    public class DCDataProvider : IDisposable
    {
        private string m_conn_string = 
                                //"server=192.168.1.101;" +
                                "server=10.0.225.111;" +
                                "User Id=dc_admin;password=dc_admin;" +
                                "database=dc;" +
                                "Allow User Variables=True;" +
                                "Allow Zero Datetime=True;" +
                                "Character Set=utf8;" +
                                "Convert Zero Datetime=True";
        private MySqlConnection m_conn;
        
        public void Dispose()
        {
            m_conn.Dispose();
        }
        public DCDataProvider()
        {
            m_conn = new MySqlConnection(m_conn_string);
            try
            {
                m_conn.Open();
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                return;
            }
            if (m_conn.State == ConnectionState.Open)
            {
                m_conn.InfoMessage += M_conn_InfoMessage;
                m_conn.StateChange += M_conn_StateChange;
            }
        }
        public string Info()
        {
            if (m_conn.State != ConnectionState.Closed)
            {
                string server = m_conn.ServerVersion;
                string db = m_conn.Database;
                string source = m_conn.DataSource;
                string state = m_conn.State.ToString();
                return string.Format(
                    "Server:   {0}\n" +
                    "DataBase: {1}\n" +
                    "Source:   {2}\n" +
                    "State:    {3}",
                    server,
                    db,
                    source,
                    state);
            }
            else
            {
                return "Connection closed.";
            }
        }

        private void M_conn_StateChange(object sender, StateChangeEventArgs e)
        {
            string msg = string.Format("MySql connection state changed from {0} to '{1}'", e.OriginalState, e.CurrentState);
            //TODO: write log;
        }

        private void M_conn_InfoMessage(object sender, MySqlInfoMessageEventArgs args)
        {
            MySqlError[] errors = args.errors;
            string errstr = "";
            foreach (var e in errors)
                errstr += string.Format("{0} (1)", e.Code, e.Message) + Environment.NewLine;
            string msg = string.Format("MySql connection info message:{0} {1}", Environment.NewLine, errstr);
            //TODO: write log;
        }
        
        public List<T> Select<T>(string query) where T : IDCObject, new()
        {
            List<T> dt = new List<T>();
            MySqlCommand cmd = new MySqlCommand(query, m_conn);
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    T t = new T();
                    t.fromArray(values);
                    dt.Add(t);
                }
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
            }
            catch (Exception sysex)
            {
                DCMessageBox.OkFail(sysex.Message);
            }            
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return dt;
        }
        public T SelectOne<T>(string query) where T : IDCObject, new()
        {
            MySqlCommand cmd = new MySqlCommand(query, m_conn);
            MySqlDataReader reader = null;
            T t = new T();
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    t.fromArray(values);
                }
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                return default(T);
            }
            catch (Exception sysex)
            {
                DCMessageBox.OkFail(sysex.Message);
                return default(T);
            }
            finally
            {
                if (reader != null)
                    reader.Close();               
            }
            return t;
        }
        public T GetScalar<T>(string query) where T : new()
        {
            MySqlCommand cmd = new MySqlCommand(query, m_conn);            
            try
            {
                return (T)cmd.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                return default(T);
            }            
            catch (Exception sysex)
            {
                DCMessageBox.OkFail(sysex.Message);
                return default(T);
            }
        }
        public long Update(string query)
        {
            MySqlTransaction tr = m_conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand(query, m_conn, tr);
            long result = 0;
            try
            {
                result = (long)cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                try
                {
                    tr.Rollback();
                }
                catch (MySqlException extr)
                {
                    DCMessageBox.OkFail(extr.Message);
                }
                catch (Exception sysex)
                {
                    DCMessageBox.OkFail(sysex.Message);
                }
            }            
            return result;
        }
    }
}
