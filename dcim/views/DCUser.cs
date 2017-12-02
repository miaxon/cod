using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dcim.views
{
    public partial class DCUser : dcim.views.DCView
    {
        public DCUser()
        {
            InitializeComponent();
            m_title = "Users";
        }
    }
}
