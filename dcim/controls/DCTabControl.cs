using dcim.dialogs;
using dcim.views;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace dcim.controls
{
    public partial class DCTabControl : TabControlEx
    {
        public DCTabControl()
        {
            InitializeComponent();
            MenuItem item = new MenuItem("Close", Item_Click);
            
            m_pageMenu.MenuItems.Add(item);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            switch(item.Index)
            {
                case 0: //Close
                    TabClosed(SelectedIndex);
                    break;
                default:
                    break;
            }
        }

        protected override void TabClosed(int index)
        {
            TabPages.RemoveAt(index);
        }
        public void AddView(string name)
        {
            bool d = this.TabPages.ContainsKey(name);
            Assembly asm = Assembly.GetExecutingAssembly();
            Type t = null;
            try
            {
                t = asm.GetType("dcim.views." + name, true, true);
            }
            catch (Exception e)
            {
                DCMessageBox.OkFail(e.Message);
                return;
            }
            ConstructorInfo ci = t.GetConstructor(System.Type.EmptyTypes);
            DCView view = ci.Invoke(new object[] { }) as DCView;
            TabPage p = CreatePage(view, name);
            this.TabPages.Add(p);
            this.SelectedTab = p;
        }
        private TabPage CreatePage(DCView view, string name)
        {
            TabPage p = new TabPage(view.Title);
            p.Name = name;
            p.Controls.Add(view);
            return p;
        }
    }
}
