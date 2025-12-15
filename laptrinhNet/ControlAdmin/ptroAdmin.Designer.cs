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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid_PhongTro = new System.Windows.Forms.DataGridView();
            this.txt_SoPhong = new System.Windows.Forms.TextBox();
            this.btn_ThemPhong = new System.Windows.Forms.Button();
            this.btn_SuaPhong = new System.Windows.Forms.Button();
            this.btn_XoaPhong = new System.Windows.Forms.Button();
            this.cbo_TrangThai_PT = new System.Windows.Forms.ComboBox();
            this.cbo_TenLoai_PT = new System.Windows.Forms.ComboBox();
            this.txt_SoNGHienTai = new System.Windows.Forms.TextBox();
            this.txt_MaPhong_PT = new System.Windows.Forms.TextBox();
            this.txt_GhiChu_PT = new System.Windows.Forms.TextBox();
            this.btn_LamMoi_PT = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhongTro)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1416, 924);
            this.panel2.TabIndex = 110;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.grid_PhongTro);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(1416, 924);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phòng trọ";
            // 
            // grid_PhongTro
            // 
            this.grid_PhongTro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.grid_PhongTro.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grid_PhongTro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_PhongTro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_PhongTro.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_PhongTro.DefaultCellStyle = dataGridViewCellStyle4;
            this.grid_PhongTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_PhongTro.EnableHeadersVisualStyles = false;
            this.grid_PhongTro.Location = new System.Drawing.Point(10, 45);
            this.grid_PhongTro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_PhongTro.Name = "grid_PhongTro";
            this.grid_PhongTro.RowHeadersWidth = 62;
            this.grid_PhongTro.RowTemplate.Height = 35;
            this.grid_PhongTro.Size = new System.Drawing.Size(1396, 869);
            this.grid_PhongTro.TabIndex = 0;
            this.grid_PhongTro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_PhongTro_CellClick_1);
            // 
            // txt_SoPhong
            // 
            this.txt_SoPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_SoPhong.Location = new System.Drawing.Point(139, 105);
            this.txt_SoPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SoPhong.Name = "txt_SoPhong";
            this.txt_SoPhong.Size = new System.Drawing.Size(198, 32);
            this.txt_SoPhong.TabIndex = 112;
            // 
            // btn_ThemPhong
            // 
            this.btn_ThemPhong.BackColor = System.Drawing.Color.White;
            this.btn_ThemPhong.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_ThemPhong.FlatAppearance.BorderSize = 0;
            this.btn_ThemPhong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_ThemPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThemPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_ThemPhong.ForeColor = System.Drawing.Color.Black;
            this.btn_ThemPhong.Location = new System.Drawing.Point(41, 442);
            this.btn_ThemPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ThemPhong.Name = "btn_ThemPhong";
            this.btn_ThemPhong.Size = new System.Drawing.Size(134, 41);
            this.btn_ThemPhong.TabIndex = 113;
            this.btn_ThemPhong.Text = "Thêm ";
            this.btn_ThemPhong.UseVisualStyleBackColor = false;
            this.btn_ThemPhong.Click += new System.EventHandler(this.btn_ThemPhong_Click_1);
            // 
            // btn_SuaPhong
            // 
            this.btn_SuaPhong.BackColor = System.Drawing.Color.White;
            this.btn_SuaPhong.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SuaPhong.FlatAppearance.BorderSize = 0;
            this.btn_SuaPhong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_SuaPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SuaPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_SuaPhong.ForeColor = System.Drawing.Color.Black;
            this.btn_SuaPhong.Location = new System.Drawing.Point(209, 442);
            this.btn_SuaPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_SuaPhong.Name = "btn_SuaPhong";
            this.btn_SuaPhong.Size = new System.Drawing.Size(128, 41);
            this.btn_SuaPhong.TabIndex = 114;
            this.btn_SuaPhong.Text = "Sửa";
            this.btn_SuaPhong.UseVisualStyleBackColor = false;
            this.btn_SuaPhong.Click += new System.EventHandler(this.btn_SuaPhong_Click);
            // 
            // btn_XoaPhong
            // 
            this.btn_XoaPhong.BackColor = System.Drawing.Color.White;
            this.btn_XoaPhong.FlatAppearance.BorderColor = System.Drawing.Color.Violet;
            this.btn_XoaPhong.FlatAppearance.BorderSize = 0;
            this.btn_XoaPhong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_XoaPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_XoaPhong.ForeColor = System.Drawing.Color.Black;
            this.btn_XoaPhong.Location = new System.Drawing.Point(41, 507);
            this.btn_XoaPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_XoaPhong.Name = "btn_XoaPhong";
            this.btn_XoaPhong.Size = new System.Drawing.Size(134, 41);
            this.btn_XoaPhong.TabIndex = 115;
            this.btn_XoaPhong.Text = "Xóa";
            this.btn_XoaPhong.UseVisualStyleBackColor = false;
            this.btn_XoaPhong.Click += new System.EventHandler(this.btn_XoaPhong_Click);
            // 
            // cbo_TrangThai_PT
            // 
            this.cbo_TrangThai_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_TrangThai_PT.FormattingEnabled = true;
            this.cbo_TrangThai_PT.Location = new System.Drawing.Point(139, 158);
            this.cbo_TrangThai_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_TrangThai_PT.Name = "cbo_TrangThai_PT";
            this.cbo_TrangThai_PT.Size = new System.Drawing.Size(198, 34);
            this.cbo_TrangThai_PT.TabIndex = 117;
            // 
            // cbo_TenLoai_PT
            // 
            this.cbo_TenLoai_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_TenLoai_PT.FormattingEnabled = true;
            this.cbo_TenLoai_PT.Location = new System.Drawing.Point(139, 201);
            this.cbo_TenLoai_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_TenLoai_PT.Name = "cbo_TenLoai_PT";
            this.cbo_TenLoai_PT.Size = new System.Drawing.Size(198, 34);
            this.cbo_TenLoai_PT.TabIndex = 119;
            // 
            // txt_SoNGHienTai
            // 
            this.txt_SoNGHienTai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SoNGHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_SoNGHienTai.Location = new System.Drawing.Point(139, 250);
            this.txt_SoNGHienTai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SoNGHienTai.Name = "txt_SoNGHienTai";
            this.txt_SoNGHienTai.Size = new System.Drawing.Size(198, 32);
            this.txt_SoNGHienTai.TabIndex = 121;
            // 
            // txt_MaPhong_PT
            // 
            this.txt_MaPhong_PT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MaPhong_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_MaPhong_PT.Location = new System.Drawing.Point(139, 59);
            this.txt_MaPhong_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_MaPhong_PT.Name = "txt_MaPhong_PT";
            this.txt_MaPhong_PT.Size = new System.Drawing.Size(198, 32);
            this.txt_MaPhong_PT.TabIndex = 122;
            // 
            // txt_GhiChu_PT
            // 
            this.txt_GhiChu_PT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_GhiChu_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_GhiChu_PT.Location = new System.Drawing.Point(139, 302);
            this.txt_GhiChu_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_GhiChu_PT.Name = "txt_GhiChu_PT";
            this.txt_GhiChu_PT.Size = new System.Drawing.Size(198, 32);
            this.txt_GhiChu_PT.TabIndex = 123;
            // 
            // btn_LamMoi_PT
            // 
            this.btn_LamMoi_PT.BackColor = System.Drawing.Color.White;
            this.btn_LamMoi_PT.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_LamMoi_PT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_LamMoi_PT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LamMoi_PT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_LamMoi_PT.ForeColor = System.Drawing.Color.Black;
            this.btn_LamMoi_PT.Location = new System.Drawing.Point(209, 507);
            this.btn_LamMoi_PT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_LamMoi_PT.Name = "btn_LamMoi_PT";
            this.btn_LamMoi_PT.Size = new System.Drawing.Size(128, 41);
            this.btn_LamMoi_PT.TabIndex = 124;
            this.btn_LamMoi_PT.Text = "Làm mới";
            this.btn_LamMoi_PT.UseVisualStyleBackColor = false;
            this.btn_LamMoi_PT.Click += new System.EventHandler(this.btn_LamMoi_PT_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1416, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(413, 924);
            this.panel1.TabIndex = 109;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(17, 251);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 120;
            this.label1.Text = "Số người ở ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(17, 197);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 29);
            this.label8.TabIndex = 118;
            this.label8.Text = "Mã loại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(17, 154);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 29);
            this.label6.TabIndex = 116;
            this.label6.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(17, 305);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 29);
            this.label4.TabIndex = 111;
            this.label4.Text = "Ghi chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(21, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 29);
            this.label3.TabIndex = 110;
            this.label3.Text = "Số phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 29);
            this.label2.TabIndex = 109;
            this.label2.Text = "Mã phòng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_LamMoi_PT);
            this.groupBox2.Controls.Add(this.txt_GhiChu_PT);
            this.groupBox2.Controls.Add(this.txt_MaPhong_PT);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_SoNGHienTai);
            this.groupBox2.Controls.Add(this.cbo_TenLoai_PT);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbo_TrangThai_PT);
            this.groupBox2.Controls.Add(this.btn_XoaPhong);
            this.groupBox2.Controls.Add(this.btn_SuaPhong);
            this.groupBox2.Controls.Add(this.btn_ThemPhong);
            this.groupBox2.Controls.Add(this.txt_SoPhong);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(20, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 884);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phòng trọ";
            // 
            // ptroAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ptroAdmin";
            this.Size = new System.Drawing.Size(1829, 924);
            this.Load += new System.EventHandler(this.ptroAdmin_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_PhongTro)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_SoPhong;
        private System.Windows.Forms.Button btn_ThemPhong;
        private System.Windows.Forms.Button btn_SuaPhong;
        private System.Windows.Forms.Button btn_XoaPhong;
        private System.Windows.Forms.ComboBox cbo_TrangThai_PT;
        private System.Windows.Forms.ComboBox cbo_TenLoai_PT;
        private System.Windows.Forms.TextBox txt_SoNGHienTai;
        private System.Windows.Forms.TextBox txt_MaPhong_PT;
        private System.Windows.Forms.TextBox txt_GhiChu_PT;
        private System.Windows.Forms.Button btn_LamMoi_PT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid_PhongTro;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
