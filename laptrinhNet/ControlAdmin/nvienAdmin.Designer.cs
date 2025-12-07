namespace laptrinhNet.ControlAdmin
{
    partial class nvienAdmin
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
            this.txt_SoDT = new System.Windows.Forms.TextBox();
            this.txt_TenNV = new System.Windows.Forms.TextBox();
            this.grid_PhanCong = new System.Windows.Forms.DataGridView();
            this.btn_xoapc = new System.Windows.Forms.Button();
            this.btn_PhanCong = new System.Windows.Forms.Button();
            this.cbo_TenCV = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_XoaNV = new System.Windows.Forms.Button();
            this.btn_SuaNV = new System.Windows.Forms.Button();
            this.btn_ThemNV = new System.Windows.Forms.Button();
            this.cbo_TenNV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPick_NhanVien = new System.Windows.Forms.DateTimePicker();
            this.gridNhanVien = new System.Windows.Forms.DataGridView();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbo_GioiTinh = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_MaNV = new System.Windows.Forms.TextBox();
            this.txt_CCCD = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_MaPC = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhanCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_SoDT
            // 
            this.txt_SoDT.Location = new System.Drawing.Point(477, 223);
            this.txt_SoDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SoDT.Name = "txt_SoDT";
            this.txt_SoDT.Size = new System.Drawing.Size(199, 26);
            this.txt_SoDT.TabIndex = 168;
            // 
            // txt_TenNV
            // 
            this.txt_TenNV.Location = new System.Drawing.Point(182, 129);
            this.txt_TenNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TenNV.Name = "txt_TenNV";
            this.txt_TenNV.Size = new System.Drawing.Size(494, 26);
            this.txt_TenNV.TabIndex = 167;
            // 
            // grid_PhanCong
            // 
            this.grid_PhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_PhanCong.Location = new System.Drawing.Point(1196, 372);
            this.grid_PhanCong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_PhanCong.Name = "grid_PhanCong";
            this.grid_PhanCong.RowHeadersWidth = 62;
            this.grid_PhanCong.Size = new System.Drawing.Size(615, 345);
            this.grid_PhanCong.TabIndex = 163;
            this.grid_PhanCong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_PhanCong_CellContentClick);
            // 
            // btn_xoapc
            // 
            this.btn_xoapc.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoapc.Location = new System.Drawing.Point(1656, 266);
            this.btn_xoapc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_xoapc.Name = "btn_xoapc";
            this.btn_xoapc.Size = new System.Drawing.Size(154, 72);
            this.btn_xoapc.TabIndex = 162;
            this.btn_xoapc.Text = "Xóa";
            this.btn_xoapc.UseVisualStyleBackColor = true;
            this.btn_xoapc.Click += new System.EventHandler(this.btn_xoapc_Click);
            // 
            // btn_PhanCong
            // 
            this.btn_PhanCong.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PhanCong.Location = new System.Drawing.Point(1288, 266);
            this.btn_PhanCong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_PhanCong.Name = "btn_PhanCong";
            this.btn_PhanCong.Size = new System.Drawing.Size(154, 72);
            this.btn_PhanCong.TabIndex = 160;
            this.btn_PhanCong.Text = "Phân công";
            this.btn_PhanCong.UseVisualStyleBackColor = true;
            this.btn_PhanCong.Click += new System.EventHandler(this.btn_PhanCong_Click);
            // 
            // cbo_TenCV
            // 
            this.cbo_TenCV.FormattingEnabled = true;
            this.cbo_TenCV.Location = new System.Drawing.Point(1288, 223);
            this.cbo_TenCV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_TenCV.Name = "cbo_TenCV";
            this.cbo_TenCV.Size = new System.Drawing.Size(522, 28);
            this.cbo_TenCV.TabIndex = 159;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1468, 73);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 35);
            this.label10.TabIndex = 158;
            this.label10.Text = "Phân công";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(273, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 35);
            this.label9.TabIndex = 157;
            this.label9.Text = "Thông tin nhân viên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(353, 223);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 29);
            this.label7.TabIndex = 155;
            this.label7.Text = "Số điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(48, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 29);
            this.label6.TabIndex = 154;
            this.label6.Text = "Tên nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(1190, 339);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 29);
            this.label4.TabIndex = 153;
            this.label4.Text = "Bảng phân công";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(1190, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 152;
            this.label3.Text = "Công việc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(51, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 151;
            this.label2.Text = "Mã nhân viên";
            // 
            // btn_XoaNV
            // 
            this.btn_XoaNV.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaNV.Location = new System.Drawing.Point(523, 363);
            this.btn_XoaNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_XoaNV.Name = "btn_XoaNV";
            this.btn_XoaNV.Size = new System.Drawing.Size(154, 72);
            this.btn_XoaNV.TabIndex = 173;
            this.btn_XoaNV.Text = "Xóa";
            this.btn_XoaNV.UseVisualStyleBackColor = true;
            this.btn_XoaNV.Click += new System.EventHandler(this.btn_XoaNV_Click);
            // 
            // btn_SuaNV
            // 
            this.btn_SuaNV.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SuaNV.Location = new System.Drawing.Point(320, 363);
            this.btn_SuaNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_SuaNV.Name = "btn_SuaNV";
            this.btn_SuaNV.Size = new System.Drawing.Size(154, 72);
            this.btn_SuaNV.TabIndex = 172;
            this.btn_SuaNV.Text = "Sửa";
            this.btn_SuaNV.UseVisualStyleBackColor = true;
            this.btn_SuaNV.Click += new System.EventHandler(this.btn_SuaNV_Click);
            // 
            // btn_ThemNV
            // 
            this.btn_ThemNV.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemNV.Location = new System.Drawing.Point(121, 363);
            this.btn_ThemNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ThemNV.Name = "btn_ThemNV";
            this.btn_ThemNV.Size = new System.Drawing.Size(154, 72);
            this.btn_ThemNV.TabIndex = 171;
            this.btn_ThemNV.Text = "Thêm";
            this.btn_ThemNV.UseVisualStyleBackColor = true;
            this.btn_ThemNV.Click += new System.EventHandler(this.btn_ThemNV_Click);
            // 
            // cbo_TenNV
            // 
            this.cbo_TenNV.FormattingEnabled = true;
            this.cbo_TenNV.Location = new System.Drawing.Point(1322, 185);
            this.cbo_TenNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_TenNV.Name = "cbo_TenNV";
            this.cbo_TenNV.Size = new System.Drawing.Size(488, 28);
            this.cbo_TenNV.TabIndex = 175;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(1192, 182);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 174;
            this.label1.Text = "Tên nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(51, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 29);
            this.label5.TabIndex = 176;
            this.label5.Text = "Ngày sinh";
            // 
            // dtPick_NhanVien
            // 
            this.dtPick_NhanVien.CustomFormat = "dd/MM/yyyy";
            this.dtPick_NhanVien.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPick_NhanVien.Location = new System.Drawing.Point(182, 174);
            this.dtPick_NhanVien.Name = "dtPick_NhanVien";
            this.dtPick_NhanVien.Size = new System.Drawing.Size(154, 26);
            this.dtPick_NhanVien.TabIndex = 177;
            // 
            // gridNhanVien
            // 
            this.gridNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNhanVien.Location = new System.Drawing.Point(56, 453);
            this.gridNhanVien.Name = "gridNhanVien";
            this.gridNhanVien.RowHeadersWidth = 62;
            this.gridNhanVien.RowTemplate.Height = 28;
            this.gridNhanVien.Size = new System.Drawing.Size(915, 304);
            this.gridNhanVien.TabIndex = 178;
            this.gridNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNhanVien_CellClick);
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Location = new System.Drawing.Point(182, 271);
            this.txt_DiaChi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(494, 26);
            this.txt_DiaChi.TabIndex = 180;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(51, 266);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 29);
            this.label11.TabIndex = 179;
            this.label11.Text = "Địa chỉ";
            // 
            // cbo_GioiTinh
            // 
            this.cbo_GioiTinh.FormattingEnabled = true;
            this.cbo_GioiTinh.Location = new System.Drawing.Point(522, 171);
            this.cbo_GioiTinh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_GioiTinh.Name = "cbo_GioiTinh";
            this.cbo_GioiTinh.Size = new System.Drawing.Size(154, 28);
            this.cbo_GioiTinh.TabIndex = 182;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(391, 171);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 29);
            this.label12.TabIndex = 181;
            this.label12.Text = "Giới tính";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(182, 312);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(494, 26);
            this.txt_Email.TabIndex = 184;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(51, 312);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 29);
            this.label8.TabIndex = 183;
            this.label8.Text = "Email";
            // 
            // txt_MaNV
            // 
            this.txt_MaNV.Location = new System.Drawing.Point(182, 83);
            this.txt_MaNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MaNV.Name = "txt_MaNV";
            this.txt_MaNV.Size = new System.Drawing.Size(494, 26);
            this.txt_MaNV.TabIndex = 185;
            // 
            // txt_CCCD
            // 
            this.txt_CCCD.Location = new System.Drawing.Point(182, 223);
            this.txt_CCCD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_CCCD.Name = "txt_CCCD";
            this.txt_CCCD.Size = new System.Drawing.Size(154, 26);
            this.txt_CCCD.TabIndex = 187;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(51, 223);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 29);
            this.label13.TabIndex = 186;
            this.label13.Text = "Số CMND_CCCD";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(1193, 149);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 29);
            this.label14.TabIndex = 188;
            this.label14.Text = "Mã phân công";
            // 
            // txt_MaPC
            // 
            this.txt_MaPC.Location = new System.Drawing.Point(1322, 149);
            this.txt_MaPC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MaPC.Name = "txt_MaPC";
            this.txt_MaPC.Size = new System.Drawing.Size(494, 26);
            this.txt_MaPC.TabIndex = 189;
            // 
            // nvienAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_MaPC);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_CCCD);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_MaNV);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbo_GioiTinh);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_DiaChi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gridNhanVien);
            this.Controls.Add(this.dtPick_NhanVien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbo_TenNV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_XoaNV);
            this.Controls.Add(this.btn_SuaNV);
            this.Controls.Add(this.btn_ThemNV);
            this.Controls.Add(this.txt_SoDT);
            this.Controls.Add(this.txt_TenNV);
            this.Controls.Add(this.grid_PhanCong);
            this.Controls.Add(this.btn_xoapc);
            this.Controls.Add(this.btn_PhanCong);
            this.Controls.Add(this.cbo_TenCV);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "nvienAdmin";
            this.Size = new System.Drawing.Size(1916, 760);
            this.Load += new System.EventHandler(this.nvienAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhanCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_SoDT;
        private System.Windows.Forms.TextBox txt_TenNV;
        private System.Windows.Forms.DataGridView grid_PhanCong;
        private System.Windows.Forms.Button btn_xoapc;
        private System.Windows.Forms.Button btn_PhanCong;
        private System.Windows.Forms.ComboBox cbo_TenCV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_XoaNV;
        private System.Windows.Forms.Button btn_SuaNV;
        private System.Windows.Forms.Button btn_ThemNV;
        private System.Windows.Forms.ComboBox cbo_TenNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtPick_NhanVien;
        private System.Windows.Forms.DataGridView gridNhanVien;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbo_GioiTinh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_MaNV;
        private System.Windows.Forms.TextBox txt_CCCD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_MaPC;
    }
}
