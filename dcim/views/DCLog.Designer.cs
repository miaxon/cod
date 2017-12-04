namespace dcim.views
{
    partial class DCLog
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
            this.dataView = new dcim.controls.DCDataView();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataView.Location = new System.Drawing.Point(0, 0);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(1502, 706);
            this.dataView.TabIndex = 0;
            // 
            // DCLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.dataView);
            this.Name = "DCLog";
            this.Size = new System.Drawing.Size(1502, 706);
            this.Load += new System.EventHandler(this.DCLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private controls.DCDataView dataView;
    }
}
