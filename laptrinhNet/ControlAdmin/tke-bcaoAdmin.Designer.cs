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
            this.label10 = new System.Windows.Forms.Label();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.crystalViewTKDT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btn_XemThongKe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(336, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 29);
            this.label10.TabIndex = 224;
            this.label10.Text = "Tháng";
            // 
            // dtpThang
            // 
            this.dtpThang.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(405, 17);
            this.dtpThang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(168, 26);
            this.dtpThang.TabIndex = 223;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(116, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 35);
            this.label9.TabIndex = 220;
            this.label9.Text = "Tổng doanh thu";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // crystalViewTKDT
            // 
            this.crystalViewTKDT.ActiveViewIndex = -1;
            this.crystalViewTKDT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.crystalViewTKDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalViewTKDT.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalViewTKDT.Location = new System.Drawing.Point(3, 74);
            this.crystalViewTKDT.Name = "crystalViewTKDT";
            this.crystalViewTKDT.Size = new System.Drawing.Size(1364, 431);
            this.crystalViewTKDT.TabIndex = 231;
            // 
            // btn_XemThongKe
            // 
            this.btn_XemThongKe.Location = new System.Drawing.Point(615, 10);
            this.btn_XemThongKe.Name = "btn_XemThongKe";
            this.btn_XemThongKe.Size = new System.Drawing.Size(140, 45);
            this.btn_XemThongKe.TabIndex = 234;
            this.btn_XemThongKe.Text = "Xem thống kê";
            this.btn_XemThongKe.UseVisualStyleBackColor = true;
            this.btn_XemThongKe.Click += new System.EventHandler(this.btn_XemThongKe_Click);
            // 
            // tke_bcaoAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_XemThongKe);
            this.Controls.Add(this.crystalViewTKDT);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpThang);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "tke_bcaoAdmin";
            this.Size = new System.Drawing.Size(1502, 645);
            this.Load += new System.EventHandler(this.tke_bcaoAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpThang;
        private System.Windows.Forms.Label label9;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalViewTKDT;
        private System.Windows.Forms.Button btn_XemThongKe;
    }
}
