namespace dcim.pages
{
	partial class DCPropertyPage
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
            this.pgrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // pgrid
            // 
            this.pgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pgrid.Location = new System.Drawing.Point(0, 0);
            this.pgrid.Name = "pgrid";
            this.pgrid.Size = new System.Drawing.Size(284, 262);
            this.pgrid.TabIndex = 0;
            // 
            // DCPropertyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pgrid);
            this.Name = "DCPropertyPage";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.PropertyGrid pgrid;
    }
}
