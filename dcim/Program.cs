using dcim.dataprovider;
using dcim.dialogs;
using dcim.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcim
{
    static class Program
    {
        public static DCDataProvider DataProvider = new DCDataProvider();
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
                DCUser u = DCUser.Get(tuple.Item1);
                if (u == null || !u.Auth(tuple.Item2))
                {
                    DCMessageBox.OkFail("Invalid user name or password.");
                    goto auth;
                }
                else
                    Application.Run(new MainForm());
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
