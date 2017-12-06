using dcim.dialogs;
using dcim.objects;
using System;
using System.Collections.Generic;

namespace dcim.pages
{
    public partial class DCUserPage : DCObjectPage
    {
        public DCUserPage()
        {
            InitializeComponent();
            m_title = "Users";
            m_view_name = "user_view";
        }
        protected override void tbtn_create_Click(object sender, EventArgs e)
        {
            DCUserObject o = new DCUserObject();
            DCUserDialog dlg = new DCUserDialog();
            dlg.PropertyObject = o;
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                o.Create();
                Upadate();
            }
        }
        protected override void tbtn_edit_Click(object sender, EventArgs e)
        {
            List<DCUserObject> list = view.SelectedObjects<DCUserObject>();
            if (list.Count == 0)
                return;
            DCUserObject o = list[0];
            if (o == null)
                return;
            DCUserDialog dlg = new DCUserDialog();
            dlg.PropertyObject = o;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                o.Save();
                Upadate();
            }
        }
        protected override void tbtn_delete_Click(object sender, EventArgs e)
        {
            List<DCUserObject> list = view.SelectedObjects<DCUserObject>();
            if (list.Count == 0)
                return;
            DCUserObject o = list[0];
            o.Delete();
            Upadate();
        }
    }
}
