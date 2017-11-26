using dcim.dialogs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dcim.dialogs
{
    public partial class DCAuthDialog : dcim.dialogs.DCBaseDialog
    {        
        public DCAuthDialog()
        {
            InitializeComponent();
            chb_allow_winauth.Checked = Properties.Settings.Default.allow_winauth;
        }
        public string UserName
        {
            get { return txt_username.Text; }
        }

        public string Password
        {
            get { return txt_password.Text; }
        }
        private void DCAuthDialog_Load(object sender, EventArgs e)
        {
            
            
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void chb_allow_winauth_CheckedChanged(object sender, EventArgs e)
        {
            txt_username.Enabled = txt_password.Enabled = !chb_allow_winauth.Checked;
            txt_username.Text = Environment.UserName;
            using (DirectoryEntry domain = new DirectoryEntry(string.Format("WinNT://{0}/{1}", Environment.UserDomainName, Environment.UserName)))
            {
                lbl_fullName.Text = domain.Properties["fullname"].Value.ToString();
            }
            Properties.Settings.Default.allow_winauth = chb_allow_winauth.Checked;
            Properties.Settings.Default.Save();
        }
        
    }
}
