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
    public class DCDataProvider
    {
        private string m_conn_string = "server=10.0.225.117;" +
                                "User Id=dc_admin;password=dc_admin;" +
                                "database=dc;" +
                                "Allow User Variables=True;" +
                                "Allow Zero Datetime=True;" +
                                "Character Set=utf8;" +
                                "Convert Zero Datetime=True";
        private MySqlConnection m_conn;
        public DCSession session { get; set; }
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
        }
        public List<T> Select<T>(string query) where T : IDCObject, new()
        {
            List<T> dt = new List<T>();
            MySqlDataReader reader = null;            
            MySqlCommand cmd = new MySqlCommand(query, m_conn);           
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
                return null;
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
            MySqlDataReader reader = null;
            MySqlCommand cmd = new MySqlCommand(query, m_conn);
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
                return t;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return t;
        }
        public T GetScalar<T>(string query) where T:new()
        {
            MySqlDataReader reader = null;
            MySqlCommand cmd = new MySqlCommand(query, m_conn);
            T result = new T();
            try
            {
                result = (T)cmd.ExecuteScalar();               
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return result;
        }
        public long Update(string query)
        {
            MySqlDataReader reader = null;
            MySqlCommand cmd = new MySqlCommand(query, m_conn);
            long result = 0;
            try
            {
                result = (long)cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return result;
        }
    }
}
