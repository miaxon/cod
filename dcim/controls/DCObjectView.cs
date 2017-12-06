using dcim.objects;
using dcim.pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dcim.controls
{
    public partial class DCObjectView : dcim.controls.DCDataView
    {
        public DCObjectView()
        {
            InitializeComponent();
        }        

        public List<T> SelectedObjects<T>() where T : IDCObject, new()
        {
            List<T> list = new List<T>();
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                DataRowView dataRow = row.DataBoundItem as DataRowView;
                T o = new T();
                o.FromArray(dataRow.Row.ItemArray);
                list.Add(o);
            }
            return list;
        }
    }
}
