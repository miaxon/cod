using dcim.dialogs;
using dcim.enums;
using dcim.objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using static dcim.Program;
using NLog;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace dcim.dataprovider
{
    public class DCDataProvider
    {
        private string m_conn_string =
                                "server={0};" +
                                "User Id=dc_admin;password=dc_admin;" +
                                "database=dc;" +
                                "Allow User Variables=True;" +
                                "Allow Zero Datetime=True;" +
                                "Character Set=utf8;" +
                                "Convert Zero Datetime=True";
        private MySqlConnection m_conn;
        private Logger logger = LogManager.GetLogger("dataprovider");
        public DCDataProvider()
        {
            
        }
        public bool Init(string server)
        {
            m_conn_string = string.Format(m_conn_string, server);
            m_conn = new MySqlConnection(m_conn_string);
            bool result = false;
            try
            {
                m_conn.Open();
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                logger.Debug(ex.Message);
            }
            if (m_conn.State == ConnectionState.Open)
            {
                m_conn.InfoMessage += M_conn_InfoMessage;
                m_conn.StateChange += M_conn_StateChange;
                result = true;
            }
            logger.Info(Info());
            return result;
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
            logger.Debug(msg);
        }

        private void M_conn_InfoMessage(object sender, MySqlInfoMessageEventArgs args)
        {
            MySqlError[] errors = args.errors;
            string errstr = "";
            foreach (var e in errors)
                errstr += string.Format("{0} {1}", e.Code, e.Message) + Environment.NewLine;
            string msg = string.Format("MySql connection info message:{0} {1}", Environment.NewLine, errstr);
            logger.Debug(msg);
        }

        public List<T> GetObjectList<T>(string query) where T : IDCObject, new()
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
                    t.FromArray(values);
                    dt.Add(t);
                }
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                logger.Debug(ex.Message);
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
        public T GetObject<T>(string query) where T : IDCObject, new()
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
                    t.FromArray(values);
                }
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                logger.Debug(ex.Message);
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
                logger.Debug(ex.Message);
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
                    logger.Debug(ex.Message);
                }
                catch (Exception sysex)
                {
                    DCMessageBox.OkFail(sysex.Message);
                }
            }
            return result;
        }
        public DataTable GetView(string view_name)
        {
            DataTable dt = new DataTable();
            string query = string.Format("select * from {0}", view_name);            
            MySqlCommand cmd = new MySqlCommand(query, m_conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                logger.Debug(ex.Message);
            }
            catch (Exception sysex)
            {
                DCMessageBox.OkFail(sysex.Message);
            }
            finally
            {
                da.Dispose();
            }
            return dt;
        }
        public void LogAdd<T>(T o, DCAction a, string p = "") where T : IDCObject, new()
        {
            string query = string.Format("call log_add({0}, {1}, {2}, {3}, '{4}', '{5}')", CurrentUser.ObjectID, (int)a, o.ObjectTypeID, o.ObjectID, o.ObjectFullName, p);
            Update(query);
        }

        public int FileAdd(string name, byte[] data, int size)
        {
            string query = "call file_add(@fname, @fdata, @fsize)";
            MySqlCommand cmd = new MySqlCommand(query, m_conn);
            cmd.Parameters.AddWithValue("@fsize", size);
            cmd.Parameters.AddWithValue("@fdata", data);
            cmd.Parameters.AddWithValue("@fname", name);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
            }
            catch (Exception sysex)
            {
                DCMessageBox.OkFail(sysex.Message);
            }
            return result;
        }

        public byte[] FileGet(string name)
        {
            string query = string.Format("call file_get('{0}')", name);
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, m_conn);
            MySqlDataReader reader = null;
            byte[] data = null;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int size = reader.GetInt32(reader.GetOrdinal("size"));
                    data = new byte[size];
                    reader.GetBytes(reader.GetOrdinal("data"), 0, data, 0, size);
                };                                
                return data;
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
                if(reader != null)
                    reader.Close();
            }
            return data;
        }
    }
}
