using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dcim.enums
{
    public enum DCAction
    {
        Logon = 1,
        Logoff
    }  

    public enum DCType
    {
        [Description("User")]
        User,
        [Description("Cod")]
        Cod
    }

    public enum DCStatus
    {
        [Description("Default")]
        Default,
        [Description("Disabled")]
        Disabled
    }

    class DCEnumConverter : EnumConverter
    {
        private Type type;

        public DCEnumConverter(Type type)
            : base(type)
        {
            this.type = type;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destType)
        {
            FieldInfo fi = type.GetField(Enum.GetName(type, value));
            DescriptionAttribute descAttr =
              (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

            if (descAttr != null)
                return descAttr.Description;
            else
                return value.ToString();
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            foreach (FieldInfo fi in type.GetFields())
            {
                DescriptionAttribute descAttr =
                  (DescriptionAttribute)Attribute.GetCustomAttribute(
                    fi, typeof(DescriptionAttribute));

                if ((descAttr != null) && ((string)value == descAttr.Description))
                    return Enum.Parse(type, fi.Name);
            }
            return Enum.Parse(type, (string)value);
        }
    }
}
