namespace laptrinhNet.ControlAdmin
{
    partial class phoi_htroAdmin
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
            this.chk_DangXuLy = new System.Windows.Forms.CheckBox();
            this.chk_ChuaXuLy = new System.Windows.Forms.CheckBox();
            this.chkTatCa = new System.Windows.Forms.CheckBox();
            this.chk_DaXuLy = new System.Windows.Forms.CheckBox();
            this.grid_PhanHoi = new System.Windows.Forms.DataGridView();
            this.soPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SoPhong = new System.Windows.Forms.TextBox();
            this.txt_TenNguoiGui = new System.Windows.Forms.TextBox();
            this.txt_NoiDung = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_PhanHoi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_MaPhanHoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_TrangThai = new System.Windows.Forms.ComboBox();
            this.cbo_NhanVienXuLy = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhanHoi)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(169, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 35);
            this.label9.TabIndex = 168;
            this.label9.Text = "Danh sách phản hồi";
            // 
            // chk_DangXuLy
            // 
            this.chk_DangXuLy.AutoSize = true;
            this.chk_DangXuLy.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_DangXuLy.Location = new System.Drawing.Point(286, 64);
            this.chk_DangXuLy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk_DangXuLy.Name = "chk_DangXuLy";
            this.chk_DangXuLy.Size = new System.Drawing.Size(125, 33);
            this.chk_DangXuLy.TabIndex = 171;
            this.chk_DangXuLy.Text = "Đang xử lý";
            this.chk_DangXuLy.UseVisualStyleBackColor = true;
            this.chk_DangXuLy.CheckedChanged += new System.EventHandler(this.chk_DangXuLy_CheckedChanged);
            // 
            // chk_ChuaXuLy
            // 
            this.chk_ChuaXuLy.AutoSize = true;
            this.chk_ChuaXuLy.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ChuaXuLy.Location = new System.Drawing.Point(144, 64);
            this.chk_ChuaXuLy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk_ChuaXuLy.Name = "chk_ChuaXuLy";
            this.chk_ChuaXuLy.Size = new System.Drawing.Size(125, 33);
            this.chk_ChuaXuLy.TabIndex = 170;
            this.chk_ChuaXuLy.Text = "Chưa xử lý";
            this.chk_ChuaXuLy.UseVisualStyleBackColor = true;
            this.chk_ChuaXuLy.CheckedChanged += new System.EventHandler(this.chk_ChuaXuLy_CheckedChanged);
            // 
            // chkTatCa
            // 
            this.chkTatCa.AutoSize = true;
            this.chkTatCa.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTatCa.Location = new System.Drawing.Point(42, 64);
            this.chkTatCa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTatCa.Name = "chkTatCa";
            this.chkTatCa.Size = new System.Drawing.Size(86, 33);
            this.chkTatCa.TabIndex = 169;
            this.chkTatCa.Text = "Tất cả";
            this.chkTatCa.UseVisualStyleBackColor = true;
            this.chkTatCa.CheckedChanged += new System.EventHandler(this.chkTatCa_CheckedChanged);
            // 
            // chk_DaXuLy
            // 
            this.chk_DaXuLy.AutoSize = true;
            this.chk_DaXuLy.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_DaXuLy.Location = new System.Drawing.Point(419, 64);
            this.chk_DaXuLy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk_DaXuLy.Name = "chk_DaXuLy";
            this.chk_DaXuLy.Size = new System.Drawing.Size(105, 33);
            this.chk_DaXuLy.TabIndex = 172;
            this.chk_DaXuLy.Text = "Đã xử lý";
            this.chk_DaXuLy.UseVisualStyleBackColor = true;
            this.chk_DaXuLy.CheckedChanged += new System.EventHandler(this.chk_DaXuLy_CheckedChanged);
            // 
            // grid_PhanHoi
            // 
            this.grid_PhanHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_PhanHoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.soPhong,
            this.trangThai});
            this.grid_PhanHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_PhanHoi.GridColor = System.Drawing.Color.White;
            this.grid_PhanHoi.Location = new System.Drawing.Point(0, 0);
            this.grid_PhanHoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_PhanHoi.Name = "grid_PhanHoi";
            this.grid_PhanHoi.RowHeadersWidth = 62;
            this.grid_PhanHoi.Size = new System.Drawing.Size(1307, 672);
            this.grid_PhanHoi.TabIndex = 173;
            this.grid_PhanHoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_PhanHoi_CellContentClick);
            // 
            // soPhong
            // 
            this.soPhong.HeaderText = "Số phòng";
            this.soPhong.MinimumWidth = 8;
            this.soPhong.Name = "soPhong";
            this.soPhong.ReadOnly = true;
            this.soPhong.Visible = false;
            this.soPhong.Width = 150;
            // 
            // trangThai
            // 
            this.trangThai.HeaderText = "Trạng thái";
            this.trangThai.MinimumWidth = 8;
            this.trangThai.Name = "trangThai";
            this.trangThai.ReadOnly = true;
            this.trangThai.Visible = false;
            this.trangThai.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(7, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 29);
            this.label2.TabIndex = 174;
            this.label2.Text = "Mã phản hồi";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 176;
            this.label1.Text = "Tên người gửi";
            // 
            // txt_SoPhong
            // 
            this.txt_SoPhong.Location = new System.Drawing.Point(380, 97);
            this.txt_SoPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SoPhong.Name = "txt_SoPhong";
            this.txt_SoPhong.Size = new System.Drawing.Size(89, 26);
            this.txt_SoPhong.TabIndex = 178;
            // 
            // txt_TenNguoiGui
            // 
            this.txt_TenNguoiGui.Location = new System.Drawing.Point(140, 147);
            this.txt_TenNguoiGui.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TenNguoiGui.Name = "txt_TenNguoiGui";
            this.txt_TenNguoiGui.Size = new System.Drawing.Size(329, 26);
            this.txt_TenNguoiGui.TabIndex = 179;
            // 
            // txt_NoiDung
            // 
            this.txt_NoiDung.Location = new System.Drawing.Point(140, 192);
            this.txt_NoiDung.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NoiDung.Multiline = true;
            this.txt_NoiDung.Name = "txt_NoiDung";
            this.txt_NoiDung.Size = new System.Drawing.Size(329, 73);
            this.txt_NoiDung.TabIndex = 181;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(7, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 29);
            this.label4.TabIndex = 180;
            this.label4.Text = "Nội dung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(7, 289);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 29);
            this.label5.TabIndex = 182;
            this.label5.Text = "NV xử lý";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(7, 336);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 29);
            this.label6.TabIndex = 184;
            this.label6.Text = "Trạng thái";
            // 
            // txt_PhanHoi
            // 
            this.txt_PhanHoi.Location = new System.Drawing.Point(140, 378);
            this.txt_PhanHoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PhanHoi.Multiline = true;
            this.txt_PhanHoi.Name = "txt_PhanHoi";
            this.txt_PhanHoi.Size = new System.Drawing.Size(329, 149);
            this.txt_PhanHoi.TabIndex = 187;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(7, 398);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 29);
            this.label7.TabIndex = 186;
            this.label7.Text = "Ghi chú";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1307, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(543, 803);
            this.panel1.TabIndex = 237;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_NoiDung);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txt_MaPhanHoi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_PhanHoi);
            this.groupBox1.Controls.Add(this.txt_SoPhong);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo_TrangThai);
            this.groupBox1.Controls.Add(this.txt_TenNguoiGui);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbo_NhanVienXuLy);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 763);
            this.groupBox1.TabIndex = 237;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiếp nhận yêu cầu";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(215, 560);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 44);
            this.button2.TabIndex = 234;
            this.button2.Text = "Thông báo nhân viên";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_MaPhanHoi
            // 
            this.txt_MaPhanHoi.Location = new System.Drawing.Point(140, 97);
            this.txt_MaPhanHoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MaPhanHoi.Name = "txt_MaPhanHoi";
            this.txt_MaPhanHoi.Size = new System.Drawing.Size(115, 26);
            this.txt_MaPhanHoi.TabIndex = 236;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(274, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 29);
            this.label3.TabIndex = 177;
            this.label3.Text = "Số phòng";
            // 
            // cbo_TrangThai
            // 
            this.cbo_TrangThai.FormattingEnabled = true;
            this.cbo_TrangThai.Location = new System.Drawing.Point(140, 336);
            this.cbo_TrangThai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_TrangThai.Name = "cbo_TrangThai";
            this.cbo_TrangThai.Size = new System.Drawing.Size(329, 28);
            this.cbo_TrangThai.TabIndex = 185;
            // 
            // cbo_NhanVienXuLy
            // 
            this.cbo_NhanVienXuLy.FormattingEnabled = true;
            this.cbo_NhanVienXuLy.Location = new System.Drawing.Point(140, 290);
            this.cbo_NhanVienXuLy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_NhanVienXuLy.Name = "cbo_NhanVienXuLy";
            this.cbo_NhanVienXuLy.Size = new System.Drawing.Size(329, 28);
            this.cbo_NhanVienXuLy.TabIndex = 183;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1307, 803);
            this.panel2.TabIndex = 238;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.grid_PhanHoi);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 131);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1307, 672);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.chk_ChuaXuLy);
            this.panel3.Controls.Add(this.chkTatCa);
            this.panel3.Controls.Add(this.chk_DaXuLy);
            this.panel3.Controls.Add(this.chk_DangXuLy);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(1307, 131);
            this.panel3.TabIndex = 0;
            // 
            // phoi_htroAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "phoi_htroAdmin";
            this.Size = new System.Drawing.Size(1850, 803);
            this.Load += new System.EventHandler(this.phoi_htroAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhanHoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chk_DangXuLy;
        private System.Windows.Forms.CheckBox chk_ChuaXuLy;
        private System.Windows.Forms.CheckBox chkTatCa;
        private System.Windows.Forms.CheckBox chk_DaXuLy;
        private System.Windows.Forms.DataGridView grid_PhanHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SoPhong;
        private System.Windows.Forms.TextBox txt_TenNguoiGui;
        private System.Windows.Forms.TextBox txt_NoiDung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_PhanHoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_MaPhanHoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_TrangThai;
        private System.Windows.Forms.ComboBox cbo_NhanVienXuLy;
    }
}
