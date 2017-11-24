using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using dcim.dialogs;

namespace dcim.dataprovider
{
    public class DCDataProvider
    {
        string m_conn_string = "server=10.0.225.117;" +
                                "User Id=dc_admin;password=dc_admin;" +
                                "database=dc;" +
                                "Allow User Variables=True;" +
                                "Allow Zero Datetime=True;" +
                                "Character Set=utf8;" +
                                "Convert Zero Datetime=True";
        MySqlConnection m_conn;
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
        public bool AuthUser(string name, string passwd)
        {
            MySqlDataReader reader = null;
            string query = string.Format("select * from dc_user where passwd=SHA2('{0}', 256)", "admin");
            MySqlCommand cmd = new MySqlCommand(query, m_conn);
            string username = "";
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    username = values[4].ToString();
                }
            }
            catch (MySqlException ex)
            {
                DCMessageBox.OkFail(ex.Message);
                return false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return username.Equals(name); ;
        }
    }
}
