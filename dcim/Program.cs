using dcim.dataprovider;
using dcim.dialogs;
using dcim.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using dcim.enums;
namespace dcim
{
    static class Program
    {
        public static DCDataProvider DataProvider = new DCDataProvider();
        public static DCUser CurrentUser;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
        auth: Tuple<string, string> tuple = ShowAuthDialog();
            if (tuple == null)
                Application.Exit();
            else
            {
                if (DCUser.Logon(tuple.Item1, tuple.Item2) <= 0)
                {
                    DCMessageBox.OkFail("Invalid user name or password.");
                    goto auth;
                }
                else
                {
                    CurrentUser = DCUser.Get(tuple.Item1);
                    DataProvider.Log(CurrentUser, DCAction.Logon);
                    Application.Run(new MainForm());
                    DataProvider.Log(CurrentUser, DCAction.Logoff);
                }
            }
        }
        static Tuple<string, string> ShowAuthDialog()
        {
            DCAuthDialog dlg = new DCAuthDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                return new Tuple<string, string>(dlg.UserName, dlg.Password);            
            return null;
        }
    }
}
