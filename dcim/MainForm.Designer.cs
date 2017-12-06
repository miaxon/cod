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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DCUserPage = new System.Windows.Forms.ToolStripMenuItem();
            this.DCLogPage = new System.Windows.Forms.ToolStripMenuItem();
            this.DCCodPage = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.dcTabControl = new dcim.controls.DCTabControl();
            this.mainMenu.SuspendLayout();
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
            this.DCUserPage.Size = new System.Drawing.Size(152, 22);
            this.DCUserPage.Text = "Users";
            this.DCUserPage.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // DCLogPage
            // 
            this.DCLogPage.Name = "DCLogPage";
            this.DCLogPage.Size = new System.Drawing.Size(152, 22);
            this.DCLogPage.Text = "Log";
            this.DCLogPage.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // DCCodPage
            // 
            this.DCCodPage.Name = "DCCodPage";
            this.DCCodPage.Size = new System.Drawing.Size(152, 22);
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
            // dcTabControl
            // 
            this.dcTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.dcTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dcTabControl.ItemSize = new System.Drawing.Size(60, 24);
            this.dcTabControl.Location = new System.Drawing.Point(0, 24);
            this.dcTabControl.Name = "dcTabControl";
            this.dcTabControl.SelectedIndex = 0;
            this.dcTabControl.Size = new System.Drawing.Size(1462, 559);
            this.dcTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.dcTabControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 605);
            this.Controls.Add(this.dcTabControl);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DCUserPage;
        private System.Windows.Forms.StatusStrip statusBar;
        private controls.DCTabControl dcTabControl;
        private System.Windows.Forms.ToolStripMenuItem DCLogPage;
        private System.Windows.Forms.ToolStripMenuItem DCCodPage;
    }
}

