namespace laptrinhNet.ControlKhachhang
{
    partial class phoi_htroKhachhang
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
            this.btnGui = new System.Windows.Forms.Button();
            this.txtNoidung = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSophong = new System.Windows.Forms.TextBox();
            this.trangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkDaXL = new System.Windows.Forms.CheckBox();
            this.checkDangXL = new System.Windows.Forms.CheckBox();
            this.checkChuaXL = new System.Windows.Forms.CheckBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.txtMaPhanHoi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGui
            // 
            this.btnGui.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGui.Location = new System.Drawing.Point(1289, 506);
            this.btnGui.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(146, 74);
            this.btnGui.TabIndex = 257;
            this.btnGui.Text = "Gửi ";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // txtNoidung
            // 
            this.txtNoidung.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoidung.Location = new System.Drawing.Point(839, 196);
            this.txtNoidung.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNoidung.Multiline = true;
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.Size = new System.Drawing.Size(596, 302);
            this.txtNoidung.TabIndex = 249;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(748, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 29);
            this.label4.TabIndex = 248;
            this.label4.Text = "Nội dung";
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(876, 152);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(238, 35);
            this.txtTen.TabIndex = 247;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(1139, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 29);
            this.label3.TabIndex = 245;
            this.label3.Text = "Số phòng";
            // 
            // txtSophong
            // 
            this.txtSophong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSophong.Location = new System.Drawing.Point(1233, 132);
            this.txtSophong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSophong.Name = "txtSophong";
            this.txtSophong.Size = new System.Drawing.Size(202, 35);
            this.txtSophong.TabIndex = 246;
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
            // soPhong
            // 
            this.soPhong.HeaderText = "Số phòng";
            this.soPhong.MinimumWidth = 8;
            this.soPhong.Name = "soPhong";
            this.soPhong.ReadOnly = true;
            this.soPhong.Visible = false;
            this.soPhong.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(748, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 244;
            this.label1.Text = "Tên người gửi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.soPhong,
            this.trangThai});
            this.dataGridView1.Location = new System.Drawing.Point(64, 152);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(582, 458);
            this.dataGridView1.TabIndex = 241;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // checkDaXL
            // 
            this.checkDaXL.AutoSize = true;
            this.checkDaXL.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDaXL.Location = new System.Drawing.Point(453, 108);
            this.checkDaXL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkDaXL.Name = "checkDaXL";
            this.checkDaXL.Size = new System.Drawing.Size(105, 33);
            this.checkDaXL.TabIndex = 240;
            this.checkDaXL.Text = "Đã xử lý";
            this.checkDaXL.UseVisualStyleBackColor = true;
            this.checkDaXL.CheckedChanged += new System.EventHandler(this.checkDaXL_CheckedChanged);
            // 
            // checkDangXL
            // 
            this.checkDangXL.AutoSize = true;
            this.checkDangXL.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDangXL.Location = new System.Drawing.Point(309, 108);
            this.checkDangXL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkDangXL.Name = "checkDangXL";
            this.checkDangXL.Size = new System.Drawing.Size(125, 33);
            this.checkDangXL.TabIndex = 239;
            this.checkDangXL.Text = "Đang xử lý";
            this.checkDangXL.UseVisualStyleBackColor = true;
            this.checkDangXL.CheckedChanged += new System.EventHandler(this.checkDangXL_CheckedChanged);
            // 
            // checkChuaXL
            // 
            this.checkChuaXL.AutoSize = true;
            this.checkChuaXL.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkChuaXL.Location = new System.Drawing.Point(166, 108);
            this.checkChuaXL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkChuaXL.Name = "checkChuaXL";
            this.checkChuaXL.Size = new System.Drawing.Size(125, 33);
            this.checkChuaXL.TabIndex = 238;
            this.checkChuaXL.Text = "Chưa xử lý";
            this.checkChuaXL.UseVisualStyleBackColor = true;
            this.checkChuaXL.CheckedChanged += new System.EventHandler(this.checkChuaXL_CheckedChanged);
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAll.Location = new System.Drawing.Point(64, 108);
            this.checkAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(86, 33);
            this.checkAll.TabIndex = 237;
            this.checkAll.Text = "Tất cả";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(232, 34);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 35);
            this.label9.TabIndex = 236;
            this.label9.Text = "Danh sách phản hồi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(748, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 29);
            this.label2.TabIndex = 242;
            this.label2.Text = "Mã phản hồi";
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(1064, 506);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(202, 74);
            this.btnClean.TabIndex = 258;
            this.btnClean.Text = "&Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // txtMaPhanHoi
            // 
            this.txtMaPhanHoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhanHoi.Location = new System.Drawing.Point(876, 113);
            this.txtMaPhanHoi.Name = "txtMaPhanHoi";
            this.txtMaPhanHoi.Size = new System.Drawing.Size(238, 35);
            this.txtMaPhanHoi.TabIndex = 259;
            // 
            // phoi_htroKhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMaPhanHoi);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.txtNoidung);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSophong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkDaXL);
            this.Controls.Add(this.checkDangXL);
            this.Controls.Add(this.checkChuaXL);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "phoi_htroKhachhang";
            this.Size = new System.Drawing.Size(1502, 645);
            this.Load += new System.EventHandler(this.phoi_htroKhachhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.TextBox txtNoidung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSophong;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn soPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkDaXL;
        private System.Windows.Forms.CheckBox checkDangXL;
        private System.Windows.Forms.CheckBox checkChuaXL;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.TextBox txtMaPhanHoi;
    }
}
