namespace dcim.pages
{
    partial class DCLogPage
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
            this.view = new dcim.controls.DCDataView();
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.DataSource = null;
            this.view.Location = new System.Drawing.Point(56, 60);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(1384, 590);
            this.view.TabIndex = 0;
            // 
            // DCLogPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.view);
            this.Name = "DCLogPage";
            this.Size = new System.Drawing.Size(1468, 698);
            this.Load += new System.EventHandler(this.DCLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private controls.DCDataView view;
    }
}
