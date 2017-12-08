using dcim.dialogs.msgboxs;
using dcim.objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace dcim.dialogs
{
    public partial class DCUserDialog : DCPropertyDialog
    {
        public DCUserDialog()
        {
            InitializeComponent();
        }
        protected override void pgrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            base.pgrid_PropertyValueChanged(s, e);
            string str = e.ChangedItem.PropertyDescriptor.Name;
            if (str == "AllowWinAuth")
            {
                DCUserObject o = PropertyObject as DCUserObject;
                if (o.AllowWinAuth && o.Name != "")
                {
                    try
                    {
                        using (DirectoryEntry domain = new DirectoryEntry(string.Format("WinNT://{0}/{1}", Environment.UserDomainName, o.Name)))
                        {
                            o.FullName = domain.Properties["fullname"].Value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        DCMessageBox.Error(ex);
                    }
                }
            }
        }

    }
}
