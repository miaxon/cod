using dcim.dialogs;
using dcim.dialogs.msgboxs;
using dcim.objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        protected override void Create()
        {
            DCUserObject o = new DCUserObject();
            DCUserDialog dlg = new DCUserDialog();
            dlg.PropertyObject = o;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                o.Create();
                Upadate();
            }
        }
        protected override void Edit()
        {
            List<int> list = view.SelectedIndexes;
            if (list.Count == 0)
                return;
            DCUserObject o = DCUserObject.Get(list[0]);
            if (o == null)
                return;
            DCUserDialog dlg = new DCUserDialog();
            dlg.PropertyObject = o;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.EditList.Count > 0)
                {
                    o.Update();
                    Upadate();
                    if (dlg.EditList.ContainsKey("Password"))
                    {
                        string passwd = dlg.EditList["Password"].ToString();
                        o.SetPassword(passwd);
                    }
                }
            }
        }
        protected override void Delete()
        {
            List<int> list = view.SelectedIndexes;
            if (list.Count == 0)
                return;
            string msg = string.Format("Number of object for deletion {0}. Continue?", list.Count);
            if (DCMessageBox.Warning(msg) == DialogResult.OK)
            {
                foreach (int id in list)
                    DCUserObject.Delete(id);
                Upadate();
            }
        }
    }
}
