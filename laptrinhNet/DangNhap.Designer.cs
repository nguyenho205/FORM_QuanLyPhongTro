namespace laptrinhNet
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.rdAdmin = new System.Windows.Forms.RadioButton();
            this.rdNhanVien = new System.Windows.Forms.RadioButton();
            this.rdNguoiThue = new System.Windows.Forms.RadioButton();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtDangNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelErrorNull = new System.Windows.Forms.Label();
            this.tbnDangKy = new System.Windows.Forms.Button();
            this.labelDangky = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 


            // rdAdmin
            // 
            this.rdAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdAdmin.AutoSize = true;
            this.rdAdmin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rdAdmin.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F);
            this.rdAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            this.rdAdmin.Location = new System.Drawing.Point(642, 258);

            this.rdAdmin.Name = "rdAdmin";
            this.rdAdmin.Size = new System.Drawing.Size(60, 23);
            this.rdAdmin.TabIndex = 71;
            this.rdAdmin.TabStop = true;
            this.rdAdmin.Text = "Admin";
            this.rdAdmin.UseVisualStyleBackColor = false;
            this.rdAdmin.CheckedChanged += new System.EventHandler(this.rdAdmin_CheckedChanged);
            // 
            // rdNhanVien
            // 
            this.rdNhanVien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdNhanVien.AutoSize = true;
            this.rdNhanVien.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rdNhanVien.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F);
            this.rdNhanVien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
   this.rdNhanVien.Location = new System.Drawing.Point(552, 258);
            this.rdNhanVien.Name = "rdNhanVien";
            this.rdNhanVien.Size = new System.Drawing.Size(79, 23);

            this.rdNhanVien.TabIndex = 70;
            this.rdNhanVien.TabStop = true;
            this.rdNhanVien.Text = "Nhân viên";
            this.rdNhanVien.UseVisualStyleBackColor = false;
            this.rdNhanVien.CheckedChanged += new System.EventHandler(this.rdNhanVien_CheckedChanged);
            // 
            // rdNguoiThue
            // 
            this.rdNguoiThue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdNguoiThue.AutoSize = true;
            this.rdNguoiThue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rdNguoiThue.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F);
            this.rdNguoiThue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            this.rdNguoiThue.Location = new System.Drawing.Point(458, 258);
            this.rdNguoiThue.Name = "rdNguoiThue";
            this.rdNguoiThue.Size = new System.Drawing.Size(85, 23);

            this.rdNguoiThue.TabIndex = 69;
            this.rdNguoiThue.TabStop = true;
            this.rdNguoiThue.Text = "Người thuê";
            this.rdNguoiThue.UseVisualStyleBackColor = false;
            this.rdNguoiThue.CheckedChanged += new System.EventHandler(this.rdNguoiThue_CheckedChanged);
            // 

            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;

            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(61, 144);

            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(254, 245);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 73;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnThoat.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            this.btnThoat.Location = new System.Drawing.Point(579, 314);

            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(116, 37);
            this.btnThoat.TabIndex = 74;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangNhap.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnDangNhap.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            this.btnDangNhap.Location = new System.Drawing.Point(405, 314);

            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(116, 37);
            this.btnDangNhap.TabIndex = 72;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtMatKhau
            // 

            this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMatKhau.Location = new System.Drawing.Point(498, 216);

            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(197, 20);
            this.txtMatKhau.TabIndex = 68;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // txtDangNhap
            // 

            this.txtDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDangNhap.Location = new System.Drawing.Point(498, 173);

            this.txtDangNhap.Name = "txtDangNhap";
            this.txtDangNhap.Size = new System.Drawing.Size(197, 20);
            this.txtDangNhap.TabIndex = 67;
            this.txtDangNhap.TextChanged += new System.EventHandler(this.txtDangNhap_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            this.label4.Location = new System.Drawing.Point(401, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 19);

            this.label4.TabIndex = 66;
            this.label4.Text = "Bạn là?";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            this.label3.Location = new System.Drawing.Point(401, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);

            this.label3.TabIndex = 65;
            this.label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            this.label2.Location = new System.Drawing.Point(401, 173);

            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 64;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(250, 40);
            this.label1.Name = "label1";

            this.label1.Size = new System.Drawing.Size(278, 47);

            this.label1.TabIndex = 63;
            this.label1.Text = "Đăng nhập tài khoản";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.pictureBox1.Location = new System.Drawing.Point(357, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(378, 245);

            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // labelErrorNull
            // 
            this.labelErrorNull.AutoSize = true;
            this.labelErrorNull.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelErrorNull.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorNull.ForeColor = System.Drawing.Color.Red;
            this.labelErrorNull.Location = new System.Drawing.Point(438, 351);
            this.labelErrorNull.Name = "labelErrorNull";
            this.labelErrorNull.Size = new System.Drawing.Size(251, 19);
            this.labelErrorNull.TabIndex = 80;
            this.labelErrorNull.Text = "Tên đăng nhập/mật khẩu không được để trống";
            // 
            // tbnDangKy
            // 
            this.tbnDangKy.BackColor = System.Drawing.SystemColors.GrayText;
            this.tbnDangKy.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnDangKy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbnDangKy.Location = new System.Drawing.Point(573, 268);
            this.tbnDangKy.Name = "tbnDangKy";
            this.tbnDangKy.Size = new System.Drawing.Size(116, 37);
            this.tbnDangKy.TabIndex = 81;
            this.tbnDangKy.Text = "Đăng ký";
            this.tbnDangKy.UseVisualStyleBackColor = false;
            this.tbnDangKy.Click += new System.EventHandler(this.tbnDangKy_Click);
            // 
            // labelDangky
            // 
            this.labelDangky.AutoSize = true;
            this.labelDangky.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelDangky.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDangky.ForeColor = System.Drawing.Color.White;
            this.labelDangky.Location = new System.Drawing.Point(435, 351);
            this.labelDangky.Name = "labelDangky";
            this.labelDangky.Size = new System.Drawing.Size(254, 19);
            this.labelDangky.TabIndex = 82;
            this.labelDangky.Text = "Bạn là người thuê mới? Vui lòng nhấn Đăng ký";
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));

            this.ClientSize = new System.Drawing.Size(901, 474);
            this.Controls.Add(this.rdAdmin);
            this.Controls.Add(this.rdNhanVien);
            this.Controls.Add(this.rdNguoiThue);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtDangNhap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DangNhap_FormClosing);
            this.Load += new System.EventHandler(this.DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rdAdmin;
        private System.Windows.Forms.RadioButton rdNhanVien;
        private System.Windows.Forms.RadioButton rdNguoiThue;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtDangNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelErrorNull;
        private System.Windows.Forms.Button tbnDangKy;
        private System.Windows.Forms.Label labelDangky;
    }
}

