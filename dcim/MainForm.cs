using dcim.dialogs.msgboxs;
using dcim.pages;
using System;
using System.Reflection;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace dcim
{
    public partial class MainForm : Form
    {
        private VS2015LightTheme theme = new VS2015LightTheme();
        private DCPropertyPage propertyPage = new DCPropertyPage();
        public MainForm()
        {
            InitializeComponent();
            this.dockPanel.Theme = this.theme;
            vsToolStripExtender.SetStyle(mainMenu, VisualStudioToolStripExtender.VsVersion.Vs2015, theme);
            vsToolStripExtender.SetStyle(toolBar, VisualStudioToolStripExtender.VsVersion.Vs2015, theme);
            vsToolStripExtender.SetStyle(statusBar, VisualStudioToolStripExtender.VsVersion.Vs2015, theme);
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            AddView((sender as ToolStripMenuItem).Name);
        }
        public void AddView(string name)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Type t = null;
            try
            {
                t = asm.GetType("dcim.pages." + name, true, true);
            }
            catch (Exception e)
            {
                DCMessageBox.Error(e.Message);
                return;
            }
            ConstructorInfo ci = t.GetConstructor(System.Type.EmptyTypes);
            DCDockPage view = ci.Invoke(new object[] { }) as DCDockPage;
            view.Show(dockPanel);
        }

        private void tbtn_refresh_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveDocument != null)
            {
                DCObjectPage p = dockPanel.ActiveDocument as DCObjectPage;
                if (p != null)
                    p.Upadate();
            }
        }

        private void tbtn_create_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveDocument != null)
            {
                DCObjectPage p = dockPanel.ActiveDocument as DCObjectPage;
                if (p != null)
                    p.Create();
            }
        }

        private void tbtn_edit_Click(object sender, EventArgs e)
        {
            object o = null;
            if (dockPanel.ActiveDocument != null)
            {
                DCObjectPage p = dockPanel.ActiveDocument as DCObjectPage;
                if (p != null)
                    o = p.GetCurrentObject();
            }
            if (propertyPage.VisibleState == DockState.Unknown)
                propertyPage.Show(dockPanel);            
            else
                propertyPage.VisibleState = DockState.DockRight;
            propertyPage.Select();
            propertyPage.PropertyObject = o;

        }

        private void tbtn_delete_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveDocument != null)
            {
                DCObjectPage p = dockPanel.ActiveDocument as DCObjectPage;
                if (p != null)
                    p.Delete();
            }
        }
    }
}
