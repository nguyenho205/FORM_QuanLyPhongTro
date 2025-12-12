namespace laptrinhNet.ControlNhanvien
{
    partial class phoi_htroNhanvien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaYeuCau = new System.Windows.Forms.TextBox();
            this.btnGuiPhanHoi = new System.Windows.Forms.Button();
            this.dgvYeuCau = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.rtbPhanHoi = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(435, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 23);
            this.label9.TabIndex = 190;
            this.label9.Text = "Yêu cầu hỗ trợ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(556, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 186;
            this.label4.Text = "Phản hồi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(76, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 180;
            this.label3.Text = "Mã yêu cầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(379, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 179;
            this.label2.Text = "Nội dung khách hỏi";
            // 
            // txtMaYeuCau
            // 
            this.txtMaYeuCau.Location = new System.Drawing.Point(151, 54);
            this.txtMaYeuCau.Name = "txtMaYeuCau";
            this.txtMaYeuCau.ReadOnly = true;
            this.txtMaYeuCau.Size = new System.Drawing.Size(168, 20);
            this.txtMaYeuCau.TabIndex = 181;
            // 
            // btnGuiPhanHoi
            // 
            this.btnGuiPhanHoi.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiPhanHoi.Location = new System.Drawing.Point(457, 349);
            this.btnGuiPhanHoi.Name = "btnGuiPhanHoi";
            this.btnGuiPhanHoi.Size = new System.Drawing.Size(103, 47);
            this.btnGuiPhanHoi.TabIndex = 192;
            this.btnGuiPhanHoi.Text = "Gừi phản hồi";
            this.btnGuiPhanHoi.UseVisualStyleBackColor = true;
            this.btnGuiPhanHoi.Click += new System.EventHandler(this.btnGuiPhanHoi_Click);
            // 
            // dgvYeuCau
            // 
            this.dgvYeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYeuCau.Location = new System.Drawing.Point(78, 114);
            this.dgvYeuCau.Name = "dgvYeuCau";
            this.dgvYeuCau.Size = new System.Drawing.Size(374, 221);
            this.dgvYeuCau.TabIndex = 302;
            this.dgvYeuCau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYeuCau_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(74, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 19);
            this.label6.TabIndex = 301;
            this.label6.Text = "Danh sách phản hồi";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(497, 54);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.Size = new System.Drawing.Size(168, 20);
            this.txtNoiDung.TabIndex = 303;
            // 
            // rtbPhanHoi
            // 
            this.rtbPhanHoi.Location = new System.Drawing.Point(560, 114);
            this.rtbPhanHoi.Name = "rtbPhanHoi";
            this.rtbPhanHoi.Size = new System.Drawing.Size(316, 221);
            this.rtbPhanHoi.TabIndex = 304;
            this.rtbPhanHoi.Text = "";
            this.rtbPhanHoi.TextChanged += new System.EventHandler(this.rtbPhanHoi_TextChanged);
            // 
            // phoi_htroNhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbPhanHoi);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.dgvYeuCau);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGuiPhanHoi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaYeuCau);
            this.Name = "phoi_htroNhanvien";
            this.Size = new System.Drawing.Size(1001, 419);
            this.Load += new System.EventHandler(this.phoi_htroNhanvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaYeuCau;
        private System.Windows.Forms.Button btnGuiPhanHoi;
        private System.Windows.Forms.DataGridView dgvYeuCau;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.RichTextBox rtbPhanHoi;
    }
}
