using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static dcim.Program;
namespace dcim.views
{
    public partial class DCLog : dcim.views.DCView
    {
        public DCLog()
        {
            InitializeComponent();
        }

        private void DCLog_Load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.GetTable("select * from log_view");
            dataView.DataSource = dt;
        }
    }
}
