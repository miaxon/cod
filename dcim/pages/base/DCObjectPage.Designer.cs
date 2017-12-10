namespace dcim.pages
{
    partial class DCObjectPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCObjectPage));
            this.view = new dcim.controls.DCObjectView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbtn_refresh = new System.Windows.Forms.ToolStripButton();
            this.tbtn_create = new System.Windows.Forms.ToolStripButton();
            this.tbtn_edit = new System.Windows.Forms.ToolStripButton();
            this.tbtn_delete = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.DataSource = null;
            this.view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view.Location = new System.Drawing.Point(3, 3);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(1462, 584);
            this.view.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_refresh,
            this.tbtn_create,
            this.tbtn_edit,
            this.tbtn_delete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1468, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
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
            this.tbtn_refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
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
            this.tbtn_create.Click += new System.EventHandler(this.Btn_Create_Click);
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
            this.tbtn_edit.Click += new System.EventHandler(this.Btn_Edit_Click);
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
            this.tbtn_delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.view, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1468, 590);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // DCObjectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "DCObjectPage";
            this.Size = new System.Drawing.Size(1468, 615);
            this.Load += new System.EventHandler(this.DCObjectPage_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected controls.DCObjectView view;
        private System.Windows.Forms.ToolStripButton tbtn_create;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbtn_refresh;
        private System.Windows.Forms.ToolStripButton tbtn_edit;
        private System.Windows.Forms.ToolStripButton tbtn_delete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}
