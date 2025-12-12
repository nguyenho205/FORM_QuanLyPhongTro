namespace laptrinhNet.ControlKhachhang
{
    partial class ptroKhachhang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBaoTri = new System.Windows.Forms.CheckBox();
            this.chkChuaThue = new System.Windows.Forms.CheckBox();
            this.dgvDanhSachPhong = new System.Windows.Forms.DataGridView();
            this.soPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDangKyThue = new System.Windows.Forms.Button();
            this.txtTenNguoiDangKy = new System.Windows.Forms.TextBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgayThue = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLoaiPhong = new System.Windows.Forms.TextBox();
            this.txtGiaPhong = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBaoTri);
            this.groupBox1.Controls.Add(this.chkChuaThue);
            this.groupBox1.Controls.Add(this.dgvDanhSachPhong);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(42, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(615, 615);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phòng";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkBaoTri
            // 
            this.chkBaoTri.AutoSize = true;
            this.chkBaoTri.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBaoTri.Location = new System.Drawing.Point(190, 39);
            this.chkBaoTri.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBaoTri.Name = "chkBaoTri";
            this.chkBaoTri.Size = new System.Drawing.Size(104, 31);
            this.chkBaoTri.TabIndex = 3;
            this.chkBaoTri.Text = "Bảo trì";
            this.chkBaoTri.UseVisualStyleBackColor = true;
            // 
            // chkChuaThue
            // 
            this.chkChuaThue.AutoSize = true;
            this.chkChuaThue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChuaThue.Location = new System.Drawing.Point(32, 39);
            this.chkChuaThue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkChuaThue.Name = "chkChuaThue";
            this.chkChuaThue.Size = new System.Drawing.Size(138, 31);
            this.chkChuaThue.TabIndex = 2;
            this.chkChuaThue.Text = "Chưa thuê";
            this.chkChuaThue.UseVisualStyleBackColor = true;
            // 
            // dgvDanhSachPhong
            // 
            this.dgvDanhSachPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.soPhong,
            this.trangThai});
            this.dgvDanhSachPhong.Location = new System.Drawing.Point(9, 80);
            this.dgvDanhSachPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDanhSachPhong.Name = "dgvDanhSachPhong";
            this.dgvDanhSachPhong.RowHeadersWidth = 62;
            this.dgvDanhSachPhong.Size = new System.Drawing.Size(600, 529);
            this.dgvDanhSachPhong.TabIndex = 0;
            this.dgvDanhSachPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachPhong_CellClick);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(665, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 26);
            this.label4.TabIndex = 96;
            this.label4.Text = "Tên người đăng ký";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(1081, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 26);
            this.label3.TabIndex = 95;
            this.label3.Text = "Số phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(665, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 26);
            this.label2.TabIndex = 94;
            this.label2.Text = "Mã phòng";
            // 
            // btnDangKyThue
            // 
            this.btnDangKyThue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKyThue.Location = new System.Drawing.Point(1026, 543);
            this.btnDangKyThue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDangKyThue.Name = "btnDangKyThue";
            this.btnDangKyThue.Size = new System.Drawing.Size(156, 66);
            this.btnDangKyThue.TabIndex = 101;
            this.btnDangKyThue.Text = "Đăng ký thuê";
            this.btnDangKyThue.UseVisualStyleBackColor = true;
            this.btnDangKyThue.Click += new System.EventHandler(this.btnDangky_Click);
            // 
            // txtTenNguoiDangKy
            // 
            this.txtTenNguoiDangKy.Location = new System.Drawing.Point(826, 140);
            this.txtTenNguoiDangKy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenNguoiDangKy.Name = "txtTenNguoiDangKy";
            this.txtTenNguoiDangKy.Size = new System.Drawing.Size(242, 26);
            this.txtTenNguoiDangKy.TabIndex = 98;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhong.Location = new System.Drawing.Point(1211, 46);
            this.txtTenPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(277, 35);
            this.txtTenPhong.TabIndex = 97;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(1221, 139);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(267, 26);
            this.txtSDT.TabIndex = 178;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(1076, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 26);
            this.label7.TabIndex = 177;
            this.label7.Text = "Số điện thoại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(665, 234);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 26);
            this.label1.TabIndex = 102;
            this.label1.Text = "Thời gian thuê từ";
            // 
            // dtpNgayThue
            // 
            this.dtpNgayThue.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayThue.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayThue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayThue.Location = new System.Drawing.Point(862, 234);
            this.dtpNgayThue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpNgayThue.Name = "dtpNgayThue";
            this.dtpNgayThue.Size = new System.Drawing.Size(150, 26);
            this.dtpNgayThue.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(1027, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 27);
            this.label5.TabIndex = 104;
            this.label5.Text = "đến";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(1107, 235);
            this.dtpNgayKetThuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(165, 26);
            this.dtpNgayKetThuc.TabIndex = 105;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(723, 371);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(721, 162);
            this.txtMoTa.TabIndex = 179;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(673, 324);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 26);
            this.label6.TabIndex = 180;
            this.label6.Text = "Mô tả";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(1081, 186);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 26);
            this.label9.TabIndex = 190;
            this.label9.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(1221, 186);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(277, 26);
            this.txtEmail.TabIndex = 191;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(665, 185);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 26);
            this.label8.TabIndex = 188;
            this.label8.Text = "CCCD";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(826, 185);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(242, 26);
            this.txtCCCD.TabIndex = 189;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(665, 91);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 26);
            this.label10.TabIndex = 192;
            this.label10.Text = "Loại phòng";
            // 
            // txtLoaiPhong
            // 
            this.txtLoaiPhong.Location = new System.Drawing.Point(826, 94);
            this.txtLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLoaiPhong.Name = "txtLoaiPhong";
            this.txtLoaiPhong.Size = new System.Drawing.Size(635, 26);
            this.txtLoaiPhong.TabIndex = 193;
            // 
            // txtGiaPhong
            // 
            this.txtGiaPhong.Location = new System.Drawing.Point(862, 286);
            this.txtGiaPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGiaPhong.Name = "txtGiaPhong";
            this.txtGiaPhong.Size = new System.Drawing.Size(218, 26);
            this.txtGiaPhong.TabIndex = 253;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(665, 284);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 26);
            this.label11.TabIndex = 252;
            this.label11.Text = "Giá phòng/tháng";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhong.Location = new System.Drawing.Point(820, 38);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(248, 39);
            this.txtMaPhong.TabIndex = 254;
            // 
            // ptroKhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.txtGiaPhong);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtLoaiPhong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDangKyThue);
            this.Controls.Add(this.txtTenNguoiDangKy);
            this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpNgayThue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenPhong);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ptroKhachhang";
            this.Size = new System.Drawing.Size(1555, 645);
            this.Load += new System.EventHandler(this.ptroKhachhang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBaoTri;
        private System.Windows.Forms.CheckBox chkChuaThue;
        private System.Windows.Forms.DataGridView dgvDanhSachPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn soPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDangKyThue;
        private System.Windows.Forms.TextBox txtTenNguoiDangKy;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayThue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLoaiPhong;
        private System.Windows.Forms.TextBox txtGiaPhong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaPhong;
    }
}
