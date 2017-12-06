using System;
using System.Data;
using static dcim.Program;
namespace dcim.pages
{
    public partial class DCObjectPage : DCPage
    {
        public DCObjectPage()
        {
            InitializeComponent();
        }
        public  void Upadate()
        {
            DataTable dt = DataProvider.GetView(m_view_name);
            view.DataSource = dt;
        }        

        private void tbtn_refresh_Click(object sender, EventArgs e)
        {
            Upadate();
        }

        private void DCObjectPage_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            Upadate();
        }

        protected virtual void tbtn_create_Click(object sender, EventArgs e)
        {

        }

        protected virtual void tbtn_edit_Click(object sender, EventArgs e)
        {

        }

        protected virtual void tbtn_delete_Click(object sender, EventArgs e)
        {

        }
    }
}
