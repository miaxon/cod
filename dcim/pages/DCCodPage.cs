using dcim.dialogs.msgboxs;
using dcim.objects;
using System.Collections.Generic;
using System.Windows.Forms;
using dcim.dialogs;
namespace dcim.pages
{
    public partial class DCCodPage : DCObjectPage
    {
        public DCCodPage()
        {
            InitializeComponent();
            m_title = "Cod";
            m_view_name = "cod_view";
        }
        protected override void Create()
        {
            DCCodObject o = new DCCodObject();
            DCCodDialog dlg = new DCCodDialog();
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
            DCCodObject o = DCCodObject.Get(list[0]);
            if (o == null)
                return;
            DCCodDialog dlg = new DCCodDialog();
            dlg.PropertyObject = o;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.HasEdit)
                {
                    o.Update();
                    Upadate();                    
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
                    DCCodObject.Delete(id);
                Upadate();
            }
        }
    }
}
