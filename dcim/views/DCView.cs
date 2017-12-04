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
namespace dcim.views
{
    public partial class DCView : UserControl
    {

        protected string m_title = "Base view for DC objects";
        public DCView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

        }
        public string Title
        {
            get { return m_title; }
        }
        public virtual void DGClick(string name)
        {
            
        }
    }
}
