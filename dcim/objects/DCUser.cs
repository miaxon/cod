using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dcim.Program;
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
            m_full_name = (string)values[10];            
        }
        private void Logon()
        {
            if (m_allow_winauth == 1)
                m_full_name = GetFullName();
            string query = string.Format("update dc_user set last_logon=CURRENT_TIMESTAMP where id={0}", m_id);
            DataProvider.Update(query);
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
            string query = string.Format("select id, version, uuid, create_time, name, email, allow_winauth, status, last_logon, info, full_name from dc_user where name='{0}'", name);
            return DataProvider.SelectOne<DCUser>(query);
        }
        public static List<DCUser> GetList()
        {
            string query = string.Format("select * from dc_user");
            return DataProvider.Select<DCUser>(query);
        }
        
        public bool Auth(string password)
        {
            if (m_allow_winauth == 1)
            {
                Logon();
                return true;
            }
            string query = string.Format("select count(*) from dc_user where name='{0}' and passwd=SHA2('{0}', 256)", m_name, password);
            bool sucsess = DataProvider.GetScalar<long>(query) == 1;
            if (sucsess)
            {
                Logon();
                return true;
            }
            return false;
        }        
    }
}
