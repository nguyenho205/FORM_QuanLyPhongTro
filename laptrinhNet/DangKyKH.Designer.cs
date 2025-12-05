namespace laptrinhNet
{
    partial class DangKyKH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptroKhachhang1 = new laptrinhNet.ControlKhachHang.ptroKhachhang();
            this.SuspendLayout();
            // 
            // ptroKhachhang1
            // 
            this.ptroKhachhang1.Location = new System.Drawing.Point(5, 7);
            this.ptroKhachhang1.Name = "ptroKhachhang1";
            this.ptroKhachhang1.Size = new System.Drawing.Size(1001, 419);
            this.ptroKhachhang1.TabIndex = 0;
            this.ptroKhachhang1.Load += new System.EventHandler(this.ptroKhachhang1_Load);
            // 
            // DangKyKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 438);
            this.Controls.Add(this.ptroKhachhang1);
            this.Name = "DangKyKH";
            this.Text = "DangKyKH";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlKhachHang.ptroKhachhang ptroKhachhang1;
    }
}