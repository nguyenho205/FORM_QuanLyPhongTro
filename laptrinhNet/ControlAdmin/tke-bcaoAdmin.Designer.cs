namespace laptrinhNet.ControlAdmin
{
    partial class tke_bcaoAdmin
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
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.crystalViewTKDT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_XemThongKe = new System.Windows.Forms.Button();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 419);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.crystalViewTKDT);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1001, 354);
            this.panel3.TabIndex = 241;
            // 
            // crystalViewTKDT
            // 
            this.crystalViewTKDT.ActiveViewIndex = -1;
            this.crystalViewTKDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalViewTKDT.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalViewTKDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalViewTKDT.Location = new System.Drawing.Point(0, 0);
            this.crystalViewTKDT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crystalViewTKDT.Name = "crystalViewTKDT";
            this.crystalViewTKDT.Size = new System.Drawing.Size(1001, 354);
            this.crystalViewTKDT.TabIndex = 239;
            this.crystalViewTKDT.ToolPanelWidth = 133;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btn_XemThongKe);
            this.panel2.Controls.Add(this.dtpThang);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1001, 65);
            this.panel2.TabIndex = 240;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 23);
            this.label9.TabIndex = 235;
            this.label9.Text = "Tổng doanh thu";
            // 
            // btn_XemThongKe
            // 
            this.btn_XemThongKe.Location = new System.Drawing.Point(301, 17);
            this.btn_XemThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_XemThongKe.Name = "btn_XemThongKe";
            this.btn_XemThongKe.Size = new System.Drawing.Size(142, 31);
            this.btn_XemThongKe.TabIndex = 239;
            this.btn_XemThongKe.Text = "Xem thống kê";
            this.btn_XemThongKe.UseVisualStyleBackColor = true;
            this.btn_XemThongKe.Click += new System.EventHandler(this.btn_XemThongKe_Click_1);
            // 
            // dtpThang
            // 
            this.dtpThang.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(175, 23);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(95, 20);
            this.dtpThang.TabIndex = 236;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(129, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 19);
            this.label10.TabIndex = 237;
            this.label10.Text = "Tháng";
            // 
            // tke_bcaoAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "tke_bcaoAdmin";
            this.Size = new System.Drawing.Size(1001, 419);
            this.Load += new System.EventHandler(this.tke_bcaoAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_XemThongKe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpThang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalViewTKDT;
        private System.Windows.Forms.Panel panel2;
    }
}
