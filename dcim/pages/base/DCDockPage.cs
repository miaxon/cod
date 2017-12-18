using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace dcim.pages
{
    public partial class DCDockPage : DockContent
    {
        protected string m_title = "Base view for DC objects";
        protected string m_view_name;
        public DCDockPage()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }
        public string Title
        {
            get { return m_title; }
        }
    }
}
