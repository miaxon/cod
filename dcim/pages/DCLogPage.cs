using System;
using System.Data;
using static dcim.Program;
namespace dcim.pages
{
    public partial class DCLogPage : DCDockPage
    {
        public DCLogPage()
        {
            InitializeComponent();
            m_title = "Log";
        }

        private void DCLog_Load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.GetView("log_view");
            view.DataSource = dt;
        }
    }
}
