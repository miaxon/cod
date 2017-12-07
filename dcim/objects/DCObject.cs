using dcim.enums;
using MySql.Data.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dcim.Program;
namespace dcim.objects
{
    [TypeConverter(typeof(PropertySorter))]
    [DefaultProperty("Name")]
    public class DCObject : IDCObject
    {
        [Browsable(true)]
        [Category("Service")]
        [ReadOnly(true)]
        [Description("Object id")]
        [DisplayName("Id")]
        [PropertyOrder(-1)]
        public int Id { get; set; }

        [Browsable(true)]
        [Category("Service")]
        [ReadOnly(true)]
        [Description("Is the object valid?")]
        [DisplayName("Has error")]
        [PropertyOrder(0)]
        public bool HasError
        {
            get { return valid && Id > 0; }
        }

        [Browsable(true)]
        [Category("Service")]
        [ReadOnly(true)]
        [Description("Object version")]
        [DisplayName("Version")]
        [PropertyOrder(1)]
        public int Version { get; set; }

        [Browsable(true)]
        [Category("Service")]
        [ReadOnly(true)]
        [Description("Objcet UUID")]
        [DisplayName("Uuid")]
        [PropertyOrder(2)]
        public string Uuid { get; set; }

        [Browsable(true)]
        [Category("Service")]
        [ReadOnly(true)]
        [Description("Object type id")]
        [TypeConverter(typeof(DCEnumConverter))]
        [PropertyOrder(3)]
        public DCType TypeId { get; set; }

        [Browsable(true)]
        [Category("DateTime")]
        [ReadOnly(true)]
        [Description("Object creation time")]
        [DisplayName("CreateTime")]
        [PropertyOrder(4)]
        public MySqlDateTime CreateTime { get; set; }

        [Browsable(true)]
        [Category("Security")]
        [ReadOnly(false)]
        [Description("Object system name")]
        [DisplayName("Name")]
        [PropertyOrder(5)]
        public string Name { get; set; }

        [Browsable(true)]
        [Category("Personal")]
        [ReadOnly(false)]
        [Description("Extended object name")]
        [DisplayName("FullName")]
        [PropertyOrder(6)]
        public string FullName { get; set; }

        [Browsable(true)]
        [Category("Personal")]
        [ReadOnly(false)]
        [Description("Object info")]
        [DisplayName("Info")]
        [PropertyOrder(7)]
        public string Info { get; set; }

        protected bool valid = true;

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
