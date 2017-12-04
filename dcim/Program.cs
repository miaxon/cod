using dcim.dataprovider;
using dcim.dialogs;
using dcim.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using dcim.enums;
using NLog;
using System.Data;
using MySql.Data.Types;

namespace dcim
{
    static class Program
    {
        public static DCDataProvider DataProvider = new DCDataProvider();
        public static DCUser CurrentUser;
        public static Logger DCLogger = LogManager.GetLogger("main");
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DCLogger.Info("### Start ###");
        auth: Tuple<string, string> tuple = ShowAuthDialog();
            if (tuple == null)
                Application.Exit();
            else
            {
                Properties.Settings.Default.username = tuple.Item1;                
                if (DCUser.Logon(tuple.Item1, tuple.Item2) <= 0)
                {
                    DCMessageBox.OkFail("Invalid user name or password.");
                    DCLogger.Info("Failure LogOn user " + tuple.Item1);
                    goto auth;
                }
                else
                {                    
                    //string q = string.Format("call log_filter(1, 100, '{0}', '{1}')", DateTime.Now.AddHours(-4), DateTime.Now);
                    //DataTable dt = DataProvider.GetTable(q);
                    Properties.Settings.Default.Save();
                    CurrentUser = DCUser.Get(tuple.Item1);
                    DataProvider.Log(CurrentUser, DCAction.Logon);
                    DCLogger.Info("LogOn user " + CurrentUser.ObjectName);
                    int i = DataProvider.FileAdd();
                    Application.Run(new MainForm());
                    DataProvider.Log(CurrentUser, DCAction.Logoff);
                    DCLogger.Info("LogOff user " + CurrentUser.ObjectName);
                    DCLogger.Info("### Shutdown ###");
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
