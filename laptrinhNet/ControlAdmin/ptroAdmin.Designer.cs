namespace laptrinhNet.ControlAdmin
{
    partial class ptroAdmin
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
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_ChuaThue = new System.Windows.Forms.CheckBox();
            this.chk_DaThue = new System.Windows.Forms.CheckBox();
            this.grid_PhongTro = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_TrangThai_PT = new System.Windows.Forms.ComboBox();
            this.btn_XoaPhong = new System.Windows.Forms.Button();
            this.btn_SuaPhong = new System.Windows.Forms.Button();
            this.btn_ThemPhong = new System.Windows.Forms.Button();
            this.txt_SoPhong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbo_TenLoai_PT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SoNGHienTai = new System.Windows.Forms.TextBox();
            this.txt_MaPhong_PT = new System.Windows.Forms.TextBox();
            this.txt_GhiChu_PT = new System.Windows.Forms.TextBox();
            this.btn_LamMoi_PT = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhongTro)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(601, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 29);
            this.label6.TabIndex = 90;
            this.label6.Text = "Trạng thái";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chk_ChuaThue);
            this.groupBox1.Controls.Add(this.chk_DaThue);
            this.groupBox1.Controls.Add(this.grid_PhongTro);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 226);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1489, 896);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phòng trọ";
            // 
            // chk_ChuaThue
            // 
            this.chk_ChuaThue.AutoSize = true;
            this.chk_ChuaThue.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ChuaThue.Location = new System.Drawing.Point(126, 45);
            this.chk_ChuaThue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk_ChuaThue.Name = "chk_ChuaThue";
            this.chk_ChuaThue.Size = new System.Drawing.Size(120, 33);
            this.chk_ChuaThue.TabIndex = 2;
            this.chk_ChuaThue.Text = "Chưa thuê";
            this.chk_ChuaThue.UseVisualStyleBackColor = true;
            this.chk_ChuaThue.CheckedChanged += new System.EventHandler(this.chk_ChuaThue_CheckedChanged);
            // 
            // chk_DaThue
            // 
            this.chk_DaThue.AutoSize = true;
            this.chk_DaThue.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_DaThue.Location = new System.Drawing.Point(14, 45);
            this.chk_DaThue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk_DaThue.Name = "chk_DaThue";
            this.chk_DaThue.Size = new System.Drawing.Size(100, 33);
            this.chk_DaThue.TabIndex = 1;
            this.chk_DaThue.Text = "Đã thuê";
            this.chk_DaThue.UseVisualStyleBackColor = true;
            this.chk_DaThue.CheckedChanged += new System.EventHandler(this.chk_DaThue_CheckedChanged);
            // 
            // grid_PhongTro
            // 
            this.grid_PhongTro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.grid_PhongTro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_PhongTro.Location = new System.Drawing.Point(14, 98);
            this.grid_PhongTro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_PhongTro.Name = "grid_PhongTro";
            this.grid_PhongTro.RowHeadersWidth = 62;
            this.grid_PhongTro.Size = new System.Drawing.Size(1432, 798);
            this.grid_PhongTro.TabIndex = 0;
            this.grid_PhongTro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_PhongTro_CellClick_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(1005, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 29);
            this.label4.TabIndex = 80;
            this.label4.Text = "Ghi chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(218, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 29);
            this.label3.TabIndex = 79;
            this.label3.Text = "Số phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(214, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 29);
            this.label2.TabIndex = 78;
            this.label2.Text = "Mã phòng";
            // 
            // cbo_TrangThai_PT
            // 
            this.cbo_TrangThai_PT.FormattingEnabled = true;
            this.cbo_TrangThai_PT.Location = new System.Drawing.Point(743, 48);
            this.cbo_TrangThai_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_TrangThai_PT.Name = "cbo_TrangThai_PT";
            this.cbo_TrangThai_PT.Size = new System.Drawing.Size(201, 28);
            this.cbo_TrangThai_PT.TabIndex = 91;
            // 
            // btn_XoaPhong
            // 
            this.btn_XoaPhong.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaPhong.Location = new System.Drawing.Point(625, 170);
            this.btn_XoaPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_XoaPhong.Name = "btn_XoaPhong";
            this.btn_XoaPhong.Size = new System.Drawing.Size(128, 41);
            this.btn_XoaPhong.TabIndex = 85;
            this.btn_XoaPhong.Text = "Xóa";
            this.btn_XoaPhong.UseVisualStyleBackColor = true;
            this.btn_XoaPhong.Click += new System.EventHandler(this.btn_XoaPhong_Click);
            // 
            // btn_SuaPhong
            // 
            this.btn_SuaPhong.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SuaPhong.Location = new System.Drawing.Point(489, 170);
            this.btn_SuaPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_SuaPhong.Name = "btn_SuaPhong";
            this.btn_SuaPhong.Size = new System.Drawing.Size(128, 41);
            this.btn_SuaPhong.TabIndex = 84;
            this.btn_SuaPhong.Text = "Sửa";
            this.btn_SuaPhong.UseVisualStyleBackColor = true;
            this.btn_SuaPhong.Click += new System.EventHandler(this.btn_SuaPhong_Click);
            // 
            // btn_ThemPhong
            // 
            this.btn_ThemPhong.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemPhong.Location = new System.Drawing.Point(347, 170);
            this.btn_ThemPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ThemPhong.Name = "btn_ThemPhong";
            this.btn_ThemPhong.Size = new System.Drawing.Size(134, 41);
            this.btn_ThemPhong.TabIndex = 83;
            this.btn_ThemPhong.Text = "Thêm ";
            this.btn_ThemPhong.UseVisualStyleBackColor = true;
            this.btn_ThemPhong.Click += new System.EventHandler(this.btn_ThemPhong_Click);
            // 
            // txt_SoPhong
            // 
            this.txt_SoPhong.Location = new System.Drawing.Point(356, 89);
            this.txt_SoPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SoPhong.Name = "txt_SoPhong";
            this.txt_SoPhong.Size = new System.Drawing.Size(198, 26);
            this.txt_SoPhong.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(601, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 29);
            this.label8.TabIndex = 95;
            this.label8.Text = "Mã loại";
            // 
            // cbo_TenLoai_PT
            // 
            this.cbo_TenLoai_PT.FormattingEnabled = true;
            this.cbo_TenLoai_PT.Location = new System.Drawing.Point(743, 91);
            this.cbo_TenLoai_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_TenLoai_PT.Name = "cbo_TenLoai_PT";
            this.cbo_TenLoai_PT.Size = new System.Drawing.Size(198, 28);
            this.cbo_TenLoai_PT.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(1005, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 103;
            this.label1.Text = "Số người ở ";
            // 
            // txt_SoNGHienTai
            // 
            this.txt_SoNGHienTai.Location = new System.Drawing.Point(1147, 37);
            this.txt_SoNGHienTai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SoNGHienTai.Name = "txt_SoNGHienTai";
            this.txt_SoNGHienTai.Size = new System.Drawing.Size(201, 26);
            this.txt_SoNGHienTai.TabIndex = 104;
            // 
            // txt_MaPhong_PT
            // 
            this.txt_MaPhong_PT.Location = new System.Drawing.Point(356, 43);
            this.txt_MaPhong_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MaPhong_PT.Name = "txt_MaPhong_PT";
            this.txt_MaPhong_PT.Size = new System.Drawing.Size(198, 26);
            this.txt_MaPhong_PT.TabIndex = 106;
            // 
            // txt_GhiChu_PT
            // 
            this.txt_GhiChu_PT.Location = new System.Drawing.Point(1147, 89);
            this.txt_GhiChu_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_GhiChu_PT.Name = "txt_GhiChu_PT";
            this.txt_GhiChu_PT.Size = new System.Drawing.Size(201, 26);
            this.txt_GhiChu_PT.TabIndex = 107;
            // 
            // btn_LamMoi_PT
            // 
            this.btn_LamMoi_PT.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LamMoi_PT.Location = new System.Drawing.Point(761, 170);
            this.btn_LamMoi_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_LamMoi_PT.Name = "btn_LamMoi_PT";
            this.btn_LamMoi_PT.Size = new System.Drawing.Size(128, 41);
            this.btn_LamMoi_PT.TabIndex = 108;
            this.btn_LamMoi_PT.Text = "Làm mới";
            this.btn_LamMoi_PT.UseVisualStyleBackColor = true;
            this.btn_LamMoi_PT.Click += new System.EventHandler(this.btn_LamMoi_PT_Click);
            // 
            // ptroAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_LamMoi_PT);
            this.Controls.Add(this.txt_GhiChu_PT);
            this.Controls.Add(this.txt_MaPhong_PT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_SoNGHienTai);
            this.Controls.Add(this.cbo_TenLoai_PT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_TrangThai_PT);
            this.Controls.Add(this.btn_XoaPhong);
            this.Controls.Add(this.btn_SuaPhong);
            this.Controls.Add(this.btn_ThemPhong);
            this.Controls.Add(this.txt_SoPhong);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ptroAdmin";
            this.Size = new System.Drawing.Size(1530, 926);
            this.Load += new System.EventHandler(this.ptroAdmin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhongTro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_ChuaThue;
        private System.Windows.Forms.CheckBox chk_DaThue;
        private System.Windows.Forms.DataGridView grid_PhongTro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_TrangThai_PT;
        private System.Windows.Forms.Button btn_XoaPhong;
        private System.Windows.Forms.Button btn_SuaPhong;
        private System.Windows.Forms.Button btn_ThemPhong;
        private System.Windows.Forms.TextBox txt_SoPhong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbo_TenLoai_PT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SoNGHienTai;
        private System.Windows.Forms.TextBox txt_MaPhong_PT;
        private System.Windows.Forms.TextBox txt_GhiChu_PT;
        private System.Windows.Forms.Button btn_LamMoi_PT;
    }
}
