namespace dcim
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DCUserPage = new System.Windows.Forms.ToolStripMenuItem();
            this.DCLogPage = new System.Windows.Forms.ToolStripMenuItem();
            this.DCCodPage = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.vsToolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.tbtn_refresh = new System.Windows.Forms.ToolStripButton();
            this.tbtn_create = new System.Windows.Forms.ToolStripButton();
            this.tbtn_edit = new System.Windows.Forms.ToolStripButton();
            this.tbtn_delete = new System.Windows.Forms.ToolStripButton();
            this.mainMenu.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrationToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1462, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DCUserPage,
            this.DCLogPage,
            this.DCCodPage});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.administrationToolStripMenuItem.Text = "Administration";
            // 
            // DCUserPage
            // 
            this.DCUserPage.Name = "DCUserPage";
            this.DCUserPage.Size = new System.Drawing.Size(102, 22);
            this.DCUserPage.Text = "Users";
            this.DCUserPage.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // DCLogPage
            // 
            this.DCLogPage.Name = "DCLogPage";
            this.DCLogPage.Size = new System.Drawing.Size(102, 22);
            this.DCLogPage.Text = "Log";
            this.DCLogPage.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // DCCodPage
            // 
            this.DCCodPage.Name = "DCCodPage";
            this.DCCodPage.Size = new System.Drawing.Size(102, 22);
            this.DCCodPage.Text = "Cod";
            this.DCCodPage.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 583);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1462, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // vsToolStripExtender
            // 
            this.vsToolStripExtender.DefaultRenderer = null;
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_refresh,
            this.tbtn_create,
            this.tbtn_edit,
            this.tbtn_delete});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1462, 25);
            this.toolBar.TabIndex = 6;
            this.toolBar.Text = "toolStrip1";
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 49);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1462, 534);
            this.dockPanel.TabIndex = 7;
            // 
            // tbtn_refresh
            // 
            this.tbtn_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_refresh.Image")));
            this.tbtn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_refresh.Name = "tbtn_refresh";
            this.tbtn_refresh.Size = new System.Drawing.Size(23, 22);
            this.tbtn_refresh.Text = "toolStripButton1";
            this.tbtn_refresh.ToolTipText = "refresh";
            this.tbtn_refresh.Click += new System.EventHandler(this.tbtn_refresh_Click);
            // 
            // tbtn_create
            // 
            this.tbtn_create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_create.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_create.Image")));
            this.tbtn_create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_create.Name = "tbtn_create";
            this.tbtn_create.Size = new System.Drawing.Size(23, 22);
            this.tbtn_create.Text = "toolStripButton1";
            this.tbtn_create.ToolTipText = "create";
            this.tbtn_create.Click += new System.EventHandler(this.tbtn_create_Click);
            // 
            // tbtn_edit
            // 
            this.tbtn_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_edit.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_edit.Image")));
            this.tbtn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_edit.Name = "tbtn_edit";
            this.tbtn_edit.Size = new System.Drawing.Size(23, 22);
            this.tbtn_edit.Text = "toolStripButton1";
            this.tbtn_edit.ToolTipText = "edit";
            this.tbtn_edit.Click += new System.EventHandler(this.tbtn_edit_Click);
            // 
            // tbtn_delete
            // 
            this.tbtn_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtn_delete.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_delete.Image")));
            this.tbtn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_delete.Name = "tbtn_delete";
            this.tbtn_delete.Size = new System.Drawing.Size(23, 22);
            this.tbtn_delete.Text = "toolStripButton1";
            this.tbtn_delete.ToolTipText = "delete";
            this.tbtn_delete.Click += new System.EventHandler(this.tbtn_delete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 605);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DCUserPage;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem DCLogPage;
        private System.Windows.Forms.ToolStripMenuItem DCCodPage;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender vsToolStripExtender;
        private System.Windows.Forms.ToolStrip toolBar;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripButton tbtn_refresh;
        private System.Windows.Forms.ToolStripButton tbtn_create;
        private System.Windows.Forms.ToolStripButton tbtn_edit;
        private System.Windows.Forms.ToolStripButton tbtn_delete;
    }
}

