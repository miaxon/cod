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
    public partial class DCCod : dcim.views.DCView
    {
        public DCCod()
        {
            InitializeComponent();
            m_title = "Cod";
        }

        private void DCCod_Load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.GetTable("select * from cod_view");
            dataView.DataSource = dt;
        }
        public override void DGClick(string name)
        {
            pb.Image = DataProvider.FileGet(name);
            
        }        
    }
}
