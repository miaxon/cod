namespace dcim.views
{
    partial class DCCod
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
            this.pb = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.DataSource = null;
            this.dataView.Location = new System.Drawing.Point(3, 14);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(945, 434);
            this.dataView.TabIndex = 0;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(3, 3);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(545, 434);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pb);
            this.panel1.Location = new System.Drawing.Point(1029, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 257);
            this.panel1.TabIndex = 2;
            // 
            // DCCod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataView);
            this.Name = "DCCod";
            this.Size = new System.Drawing.Size(1502, 698);
            this.Load += new System.EventHandler(this.DCCod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private controls.DCDataView dataView;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Panel panel1;
    }
}
