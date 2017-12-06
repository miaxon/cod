using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dcim.Program;
namespace dcim.pages
{
    public partial class DCPage : UserControl
    {
        protected string m_title = "Base view for DC objects";
        protected string m_view_name;
        public DCPage()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

        }
        public string Title
        {
            get { return m_title; }
        }        
        
    }
}
