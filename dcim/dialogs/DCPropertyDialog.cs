using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace dcim.dialogs
{
    public partial class DCPropertyDialog : dcim.dialogs.DCBaseDialog
    {
        public Dictionary<string, object> ChangedProperties = new Dictionary<string, object>();
        public DCPropertyDialog()
        {
            InitializeComponent();
        }
        public object PropertyObject
        {
            get
            {
                return pgrid.SelectedObject;
            }
            set
            {
                if (!DesignMode)
                {
                    pgrid.SelectedObject = value;

                }
            }
        }
        protected void ResizePropertyGridSplitter(PropertyGrid grid, int width)
        {
            Control view = (Control)grid.GetType().GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(grid);
            FieldInfo fieldInfo = view.GetType().GetField("labelWidth", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldInfo.SetValue(view, width);
            view.Invalidate();
        }
        protected virtual void pgrid_Paint(object sender, PaintEventArgs e)
        {
            ResizePropertyGridSplitter(pgrid, 130);
        }
        private void pgrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string str = e.ChangedItem.Label;
            ChangedProperties.Add(e.ChangedItem.Label, e.ChangedItem.Value);
        }
    }
}
