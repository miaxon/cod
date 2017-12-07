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
using dcim.dialogs.msgboxs;

namespace dcim
{
    static class Program
    {
        public static DCDataProvider DataProvider = new DCDataProvider();
        public static DCUserObject CurrentUser;
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
        auth: Tuple<string, string, string> tuple = ShowAuthDialog();
            if (tuple == null)
                Application.Exit();
            else
            {
                Properties.Settings.Default.server = tuple.Item1;
                if(!DataProvider.Init(tuple.Item1))
                {
                    DCMessageBox.Error("Invalid server name.");
                    goto auth;
                }
                Properties.Settings.Default.username = tuple.Item2;                
                if (DCUserObject.Logon(tuple.Item2, tuple.Item3) <= 0)
                {
                    DCMessageBox.Error("Invalid user name or password.");
                    DCLogger.Info("Failure LogOn user " + tuple.Item2);
                    goto auth;
                }
                else
                {                    
                    //string q = string.Format("call log_filter(1, 100, '{0}', '{1}')", DateTime.Now.AddHours(-4), DateTime.Now);
                    //DataTable dt = DataProvider.GetTable(q);
                    Properties.Settings.Default.Save();
                    CurrentUser = DCUserObject.Get(tuple.Item2);
                    DataProvider.LogAdd(CurrentUser, DCAction.Logon);
                    DCLogger.Info("LogOn user " + CurrentUser.ObjectName);
                    Application.Run(new MainForm());
                    DataProvider.LogAdd(CurrentUser, DCAction.Logoff);
                    DCLogger.Info("LogOff user " + CurrentUser.ObjectName);
                    DCLogger.Info("### Shutdown ###");
                }
            }
        }
        static Tuple<string, string, string> ShowAuthDialog()
        {
            DCAuthDialog dlg = new DCAuthDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                return new Tuple<string, string, string>(dlg.Server, dlg.UserName, dlg.Password);            
            return null;
        }
    }
}
