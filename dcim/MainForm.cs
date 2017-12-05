using System;
using System.Windows.Forms;

namespace dcim
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            dcTabControl.AddView((sender as ToolStripMenuItem).Name);
        }
    }
}
