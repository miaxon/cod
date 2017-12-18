using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dcim.pages;
using dcim.objects;

namespace dcim.controls
{
    public partial class DCDataView : UserControl
    {
        public DCDataView()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = true;
            
        }
        private void DataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        public object DataSource
        {
            get
            {
                return bs.DataSource as DataTable;
            }
            set
            {
                if (value != null)
                {
                    bs.DataSource = value;
                    
                    foreach (DataGridViewColumn c in dgv.Columns)
                    {
                        c.Visible = !c.Name.StartsWith("_");
                        dgv.AutoResizeColumn(c.Index, DataGridViewAutoSizeColumnMode.AllCells);
                    }
                    dgv.Columns[dgv.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                
            }
        }
        public List<int> SelectedIndexes
        {
            get
            {
                List<int> list = new List<int>();
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    DataRowView dataRow = row.DataBoundItem as DataRowView;
                    list.Add((int)dataRow.Row.ItemArray[0]);
                }
                return list;
            }
        }
        
    }
}
