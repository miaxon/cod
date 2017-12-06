namespace dcim.dialogs
{
    partial class DCUserDialog
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
            this.pgrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pgrid.Location = new System.Drawing.Point(12, 12);
            this.pgrid.Name = "pgrid";
            this.pgrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgrid.Size = new System.Drawing.Size(383, 358);
            this.pgrid.TabIndex = 10;
            // 
            // DCUserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(409, 415);
            this.Controls.Add(this.pgrid);
            this.Name = "DCUserDialog";
            this.Controls.SetChildIndex(this.pgrid, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgrid;
    }
}
