using dcim.dataprovider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcim
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DCAuthDialog dlg = new DCAuthDialog();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                Application.Exit();
            else
            {
                string user = dlg.UserName;
                string passwd = dlg.Password;
                DCDataProvider dp = new DCDataProvider();
                if (!dp.AuthUser(user, passwd))
                    Application.Exit();
                else
                    Application.Run(new MainForm());
            }
        }
    }
}
