using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using static dcim.Program;
using dcim.objects;
using dcim.dialogs;
using System.ComponentModel;
using dcim.enums;
using dcim.dialogs.msgboxs;
using System.Drawing;
using System.Windows.Forms.Design;

namespace dcim.objects
{
    
    public class DCUserObject : DCObject
    {
        [Browsable(true)]
        [Category("Personal")]
        [ReadOnly(false)]
        [Description("User email")]
        [DisplayName("Email")]
        [PropertyOrder(8)]
        public string Email { get; set; }

        [Browsable(true)]
        [Category("Security")]
        [ReadOnly(false)]
        [Description("Allow user login with windows credentials")]
        [DisplayName("AllowWinAuth")]
        [PropertyOrder(9)]
        public bool AllowWinAuth { get; set; }

        [Browsable(true)]
        [Category("Security")]
        [ReadOnly(false)]
        [Description("User password")]
        [PropertyOrder(10)]
        [PasswordPropertyText(true)]
        public string Password { get; set; }

        [Browsable(true)]
        [Category("Security")]
        [ReadOnly(false)]
        [Description("User status")]
        [TypeConverter(typeof(DCEnumConverter))]
        [PropertyOrder(11)]
        public DCStatus Status { get; set; }

        [Browsable(true)]
        [Category("DateTime")]
        [ReadOnly(true)]
        [Description("Object creation time")]
        [DisplayName("LastLogon")]
        [PropertyOrder(12)]
        public MySqlDateTime LastLogon { get; set; }


        public DCUserObject()
        {
            TypeId = DCType.User;
        }

        public override void FromArray(object[] values)
        {
            try
            {
                base.FromArray(values);
                Email = (string)values[9];
                AllowWinAuth = (bool)values[10];
                LastLogon = GetMySqlDateTime(values[11]);
                Status = (DCStatus)values[12];
                has_error = false;
            }
            catch (Exception e)
            {
                DCMessageBox.Error(e);
                has_error = true;
            }

        }

        public static int Logon(string name, string password)
        {
            string query = string.Format("select logon('{0}','{1}')", name, password);
            int result = DataProvider.GetScalar<int>(query);
            return result;
        }
        
        public static DCUserObject Get(int id)
        {
            string query = string.Format("call user_get({0}, '{1}')", id, null);
            DCUserObject result = DataProvider.GetObject<DCUserObject>(query);
            return result;
        }

        public static DCUserObject Get(string name)
        {
            string query = string.Format("call user_get({0}, '{1}')", -1, name);
            DCUserObject result = DataProvider.GetObject<DCUserObject>(query);
            return result;
        }

        public static List<DCUserObject> GetList()
        {
            string query = string.Format("call user_list()");
            List<DCUserObject> result = DataProvider.GetObjectList<DCUserObject>(query);
            return result;
        }

        public void Update()
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
        public static void Delete(int id)
        {
            string query = string.Format("call user_delete({0})", id);
            DataProvider.Update(query);
        }

        public void SetPassword(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                DCMessageBox.Error("Empty password is not permitted!");
                return;
            }
            string query = string.Format("call user_password('{0}')", password);
            DataProvider.Update(query);
        }
    }
}
