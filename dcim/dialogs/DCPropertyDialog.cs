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
        private Dictionary<string, Tuple<object, object>> EditList = new Dictionary<string, Tuple<object, object>>();
        public DCPropertyDialog()
        {
            InitializeComponent();
        }
        public object GetNewValue(string property)
        {
            if (EditList.ContainsKey(property))
                return EditList[property].Item1;
            return null;
        }
        public object GetOldValue(string property)
        {
            if (EditList.ContainsKey(property))
                return EditList[property].Item2;
            return null;
        }
        public bool IsEdit(string property)
        {
            return EditList.ContainsKey(property);
        }
        public bool HasEdit
        {
            get
            {
                return EditList.Count > 0;
            }
        }
        public string EditString
        {
            get
            {
                string str = "";
                foreach (var s in EditList)
                {
                    str += string.Format("{0}:{1}[{2}]; ", s.Key, s.Value.Item2, s.Value.Item1);
                }
                return str;
            }
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
        protected virtual void pgrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string str = e.ChangedItem.Label;
            if (!EditList.ContainsKey(str))
                EditList.Add(str, Tuple.Create(e.OldValue, e.ChangedItem.Value));
            else
            {
                Tuple<object, object> values = Tuple.Create(EditList[str].Item1, e.ChangedItem.Value);
                EditList[str] = values;
            }
        }
    }
}
