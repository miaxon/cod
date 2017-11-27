using dcim.objects;
using System;
using System.Windows.Forms;

namespace dcim.dialogs
{
    public partial class DCAuthDialog : DCBaseDialog
    {        
        public DCAuthDialog()
        {
            InitializeComponent();
            chb_allow_winauth.Checked = Properties.Settings.Default.allow_winauth;
            txt_username.Text = Properties.Settings.Default.username;
        }
        public string UserName
        {
            get { return txt_username.Text; }
        }

        public string Password
        {
            get { return txt_password.Text; }
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
            lbl_fullName.Text = DCUser.GetFullName();
            Properties.Settings.Default.allow_winauth = chb_allow_winauth.Checked;
            Properties.Settings.Default.Save();
        }
        
    }
}
