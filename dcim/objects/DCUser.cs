using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcim.objects
{
    public class DCUser
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
        public DCUser(object[] values)
        {
            m_id = (int)values[0];
            m_version = (int)values[1];
            m_uuid = (string)values[2];
            m_create_time = (MySqlDateTime)values[3];
            m_allow_winauth = (int)values[7];
            
        }
        public bool AllowWinAuth
        {
            get { return m_allow_winauth == 1; }
        }
    }
}
