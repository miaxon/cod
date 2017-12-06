using dcim.objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dcim.dialogs
{
    public partial class DCUserDialog : dcim.dialogs.DCBaseDialog
    {
        public DCUserDialog()
        {
            InitializeComponent();
        }
        public DCUserObject PropertyObject
        {
            get
            {
                return pgrid.SelectedObject as DCUserObject;
            }
            set
            {
                pgrid.SelectedObject = value;
            }
        }
    }
}
