using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcim.dialogs.msgboxs
{
    public static class DCMessageBox
    {
        public static DialogResult Error(object message)
        {
            return MessageBox.Show(message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Warning(object message)
        {
            return MessageBox.Show(message.ToString(), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}
