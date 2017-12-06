using dcim.enums;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dcim.Program;
namespace dcim.objects
{
    public class DCObject : IDCObject
    {
        [Browsable(true)]
        [Category("Numeric")]
        [ReadOnly(true)]
        [Description("User id")]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Browsable(true)]
        [Category("Numeric")]
        [ReadOnly(true)]
        [Description("Row version")]
        [DisplayName("Version")]
        public int Version { get; set; }

        [Browsable(true)]
        [Category("Text")]
        [ReadOnly(true)]
        [Description("User UUID")]
        [DisplayName("Uuid")]
        public string Uuid { get; set; }

        [Browsable(true)]
        [Category("Numeric")]
        [ReadOnly(true)]
        [Description("Object type id")]
        [TypeConverter(typeof(DCEnumConverter))]
        public DCType TypeId { get; set; }

        [Browsable(true)]
        [Category("DateTime")]
        [ReadOnly(true)]
        [Description("Object creation time")]
        [DisplayName("CreateTime")]
        public MySqlDateTime CreateTime { get; set; }

        [Browsable(true)]
        [Category("Text")]
        [ReadOnly(false)]
        [Description("User name for login")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Browsable(true)]
        [Category("Text")]
        [ReadOnly(false)]
        [Description("Full name")]
        [DisplayName("FullName")]
        public string FullName { get; set; }

        [Browsable(true)]
        [Category("Text")]
        [ReadOnly(false)]
        [Description("User info")]
        [DisplayName("Info")]
        public string Info { get; set; }

        public virtual void FromArray(object[] values)
        {
            Id = (int)values[0];
            Version = (int)values[1];
            Uuid = (string)values[2];
            TypeId = (DCType)values[3];
            CreateTime = (MySqlDateTime)values[4];
            Name = (string)values[5];
            FullName = (string)values[6];
            Info = (string)values[7];
        }
        [Browsable(false)]
        public int ObjectTypeID
        {
            get { return (int)TypeId; }
        }
        [Browsable(false)]
        public int ObjectID
        {
            get { return Id; }
        }
        [Browsable(false)]
        public string ObjectName
        {
            get { return Name; }
        }
        [Browsable(false)]
        public string ObjectFullName
        {
            get { return string.IsNullOrEmpty(FullName) ? Name : FullName; }
        }
        [Browsable(false)]
        public string ObjectInfo
        {
            get { return Info; }
        }

        public MySqlDateTime GetMySqlDateTime(object o)
        {
            if (o is MySql.Data.Types.MySqlDateTime)
                return (MySqlDateTime)o;
            else
                return new MySqlDateTime("00.00.0000 00:00:00");
        }

    }
}
