using dcim.dialogs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dcim
{
    public partial class DCAuthDialog : dcim.dialogs.DCBaseDialog
    {        
        public DCAuthDialog()
        {
            InitializeComponent();
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
    }
}
