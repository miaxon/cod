using System;
using System.Data;
using static dcim.Program;
namespace dcim.pages
{
    public partial class DCObjectPage : DCDockPage
    {
        public DCObjectPage()
        {
            InitializeComponent();
        }
        public void Upadate()
        {
            DataTable dt = DataProvider.GetView(m_view_name);
            view.DataSource = dt;
        }
        public virtual object GetCurrentObject()
        {
            return null;
        }
        public virtual void Create() { }
        public virtual void Edit() { }
        public virtual void Delete() { }

        private void DCObjectPage_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                Upadate();
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            Upadate();
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
