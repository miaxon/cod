using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using static dcim.Program;
using dcim.objects;
using dcim.dialogs;
using System.ComponentModel;
using dcim.enums;

namespace dcim.objects
{
    public class DCUserObject : DCObject
    {
        [Browsable(true)]
        [Category("Text")]
        [ReadOnly(false)]
        [Description("User email")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Browsable(true)]
        [Category("Boolean")]
        [ReadOnly(false)]
        [Description("Allow user login with windows credentials")]
        [DisplayName("AllowWinAuth")]
        public bool AllowWinAuth { get; set; }        

        [Browsable(true)]
        [Category("Numeric")]
        [ReadOnly(false)]
        [Description("User status")]
        [TypeConverter(typeof(DCEnumConverter))]
        public DCStatus Status { get; set; }

        [Browsable(true)]
        [Category("DateTime")]
        [ReadOnly(true)]
        [Description("Object creation time")]
        [DisplayName("LastLogon")]
        public MySqlDateTime LastLogon { get; set; }



        public DCUserObject()
        {

        }
        public override void FromArray(object[] values)
        {
            base.FromArray(values);
            Email = (string)values[8];
            AllowWinAuth = (bool)values[9];
            Type t = values[10].GetType();
            LastLogon = GetMySqlDateTime(values[10]);
            Status = (DCStatus)values[11];

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

        public static DCUserObject Get(string name)
        {
            string query = string.Format("call user_get('{0}')", name);
            DCUserObject result = DataProvider.GetObject<DCUserObject>(query);
            return result;
        }
        public static List<DCUserObject> GetList()
        {
            string query = string.Format("call user_list()");
            List<DCUserObject> result = DataProvider.GetObjectList<DCUserObject>(query);
            return result;
        }

        public void Save()
        {
            string query = string.Format("call user_update({0},'{1}','{2}','{3}','{4}',{5},{6})",
                Id, Name, FullName, Email, Info, (int)Status, AllowWinAuth);
            DataProvider.Update(query);
        }

        public void Create()
        {
            string query = string.Format("call user_create('{0}','{1}','{2}','{3}',{4},{5})",
                Name, FullName, Email, Info, (int)Status, AllowWinAuth);
            DataProvider.Update(query);
        }
        public void Delete()
        {
            string query = string.Format("call user_delete({0})", Id);
            DataProvider.Update(query);
        }
    }
}
