using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using static dcim.Program;
using dcim.objects;
using dcim.dialogs;

namespace dcim.objects
{
    public class DCUser : DCObject
    {        
        private string m_email;
        private int m_allow_winauth;
        private int m_status;
        private MySqlDateTime m_last_logon;
        
        public DCUser() { }
        public override void FromArray(object[] values)
        {
            base.FromArray(values);            
            m_email = (string)values[8];
            m_allow_winauth = (int)values[9];
            m_status = (int)values[10];
            m_last_logon = (MySqlDateTime)values[11];
        }        

        public static int Logon(string name, string password)
        {
            string query = string.Format("select logon('{0}','{1}')", name, password);
            int result = DataProvider.GetScalar<int>(query);
            return result;
        }

        private string GetFullName()
        {
            // TODO: полное имя заполняем в базу при добавлении с опцией winauth
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
