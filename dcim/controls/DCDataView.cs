using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcim.controls
{
    public partial class DCDataView : UserControl
    {
        public DCDataView()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = true;
            dgv.ColumnHeadersVisible = true;
        }
        public DataTable DataSource
        {
            get
            {
                return bs.DataSource as DataTable;
            }
            set
            {
                bs.DataSource = value;
                dgv.Columns[dgv.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                foreach (DataGridViewColumn c in dgv.Columns)
                    c.Visible = !c.Name.Contains("_");
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "num";
                col.HeaderText = "№";
                dgv.Columns.Insert(0, col);
            }
        }
        private void SetRowNumber()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells[0].Value = "dddddddddd";// (row.Index + 1).ToString();
            }
            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

        }
    }
}
