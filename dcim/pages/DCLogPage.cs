using System;
using System.Data;
using System.Globalization;
using System.Linq;
using static dcim.Program;
namespace dcim.pages
{
    public partial class DCLogPage : DCDockPage
    {
        public DCLogPage()
        {
            InitializeComponent();
            m_title = "Log";
            Text = m_title;
        }

        private void DCLog_Load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.GetView("log_view");
            DataView dv = dt.DefaultView;
            var filter = string.Format(
                @"Convert(Время, 'System.DateTime') <= #{0:M/dd/yyyy h:mm:ss tt}# 
                  AND
                  Convert(Время, 'System.DateTime') >= #{1:M/dd/yyyy h:mm:ss tt}#",
                  DateTime.Now, 
                  DateTime.Now.AddDays(-1)
                  );
            dv.RowFilter = filter;
            view.DataSource = dv.ToTable();//.Rows.Cast<System.Data.DataRow>().Take(600).CopyToDataTable();
        }
    }
}
