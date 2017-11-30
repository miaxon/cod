using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcim.objects
{
    public class DCObject : IDCObject
    {
        protected int m_id;
        protected int m_version;
        protected string m_uuid;
        protected int m_type_id;
        protected MySqlDateTime m_create_time; 
        protected string m_name;
        protected string m_full_name;
        public virtual void FromArray(object[] values)
        {
            m_id = (int)values[0];
            m_version = (int)values[1];
            m_uuid = (string)values[2];
            m_type_id = (int)values[3];
            m_create_time = (MySqlDateTime)values[4];
            m_name = (string)values[5];
            m_full_name = (string)values[6];           
        }

        public int TypeID
        {
            get { return m_type_id; }
        }
        public int ObjectID
        {
            get { return m_id; }
        }
        public string ObjectName
        {
            get { return m_name; }
        }
        public string ObjectFullName
        {
            get { return m_full_name; }
        }
    }
}
