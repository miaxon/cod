using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using static dcim.Program;
using dcim.objects;
using dcim.dialogs;

namespace dcim.objects
{
    public class DCUser : IDCObject
    {
        private int m_id;
        private int m_version;
        private string m_uuid;
        private MySqlDateTime m_create_time;
        private string m_name;
        private string m_email;
        private int m_allow_winauth;
        private int m_status;
        private MySqlDateTime m_last_logon;
        private string m_info;
        private string m_full_name;
        public DCUser() { }
        public void fromArray(object[] values)
        {
            m_id = (int)values[0];
            m_version = (int)values[1];
            m_uuid = (string)values[2];
            m_create_time = (MySqlDateTime)values[3];
            m_name = (string)values[4];
            m_email = (string)values[5];
            m_allow_winauth = (int)values[6];
            m_status = (int)values[7];
            m_last_logon = (MySqlDateTime)values[8];
            m_info = (string)values[9];
            m_full_name = (m_allow_winauth == 1) ? GetFullName() : (string)values[10];
        }
        public static int Logon(string name, string password)
        {
            string query = string.Format("select logon('{0}','{1}')", name, password);
            int result = DataProvider.GetScalar<int>(query);
            return result;
        }

        public static string GetFullName()
        {
            using (DirectoryEntry domain = new DirectoryEntry(string.Format("WinNT://{0}/{1}", Environment.UserDomainName, Environment.UserName)))
            {
                return domain.Properties["fullname"].Value.ToString();
            }
        }

        public static DCUser Get(string name)
        {            
            string query = string.Format("call user_get('{0}')", name);
            DCUser result = DataProvider.SelectOne<DCUser>(query);
            return result;
        }
        public static List<DCUser> GetList()
        {
            string query = string.Format("call user_list()");
            List<DCUser> result = DataProvider.Select<DCUser>(query);
            return result;
        }
        
    }
}
