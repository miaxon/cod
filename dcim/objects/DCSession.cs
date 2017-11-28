using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dcim.Program;
namespace dcim.objects
{
    public class DCSession : IDCObject
    {
        private int m_id;
        private int m_version;
        private string m_uuid;
        private int m_user_id;
        private string m_remote_ip;
        private MySqlDateTime m_timestamp;

        public string Ssid { get { return m_uuid; } }
        public DCSession() { }

        public void fromArray(object[] values)
        {
            m_id = (int)values[0];
            m_version = (int)values[1];
            m_uuid = (string)values[2];
            m_user_id = (int)values[3];
            m_remote_ip = (string)values[4];
            m_timestamp = (MySqlDateTime)values[5];
        }
        public bool IsValid
        {
            get
            {
                bool result = m_timestamp.Value.AddMinutes(10) >= DateTime.Now;
                if(!result)
                {
                    string query = string.Format("delete from dc_session where uuid='{0}'", m_uuid);
                    DataProvider.Update(query);
                }
                return result;
            }
        }
        public static DCSession Get(int user_id, string uuid)
        {
            if (!string.IsNullOrEmpty(uuid))
            {
                string query = string.Format("select * from dc_session where user_id={0} and uuid='{1}'", user_id, uuid);
                DCSession s = DataProvider.SelectOne<DCSession>(query);
                if (s.IsValid)
                    return s;
                else
                    return DCSession.Get(user_id, null);
            }
            else
            {
                string new_uuid = Guid.NewGuid().ToString();
                string query = string.Format("insert into dc_session (user_id, uuid) values ({0}, '{1}')", user_id, new_uuid);
                if (DataProvider.Update(query) == 1)
                    return DCSession.Get(user_id, new_uuid);
                else
                    return null;
            }

        }
    }
}
