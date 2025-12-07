namespace laptrinhNet
{
    partial class OTP
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.btnGuiOTP = new System.Windows.Forms.Button();
            this.btnXacthuc = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OTP";
            // 
            // txtOTP
            // 
            this.txtOTP.Location = new System.Drawing.Point(78, 83);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(182, 20);
            this.txtOTP.TabIndex = 3;
            // 
            // btnGuiOTP
            // 
            this.btnGuiOTP.Location = new System.Drawing.Point(266, 80);
            this.btnGuiOTP.Name = "btnGuiOTP";
            this.btnGuiOTP.Size = new System.Drawing.Size(75, 23);
            this.btnGuiOTP.TabIndex = 2;
            this.btnGuiOTP.Text = "Gửi mã OTP";
            this.btnGuiOTP.UseVisualStyleBackColor = true;
            this.btnGuiOTP.Click += new System.EventHandler(this.btnGuiOTP_Click);
            // 
            // btnXacthuc
            // 
            this.btnXacthuc.Location = new System.Drawing.Point(161, 124);
            this.btnXacthuc.Name = "btnXacthuc";
            this.btnXacthuc.Size = new System.Drawing.Size(75, 23);
            this.btnXacthuc.TabIndex = 4;
            this.btnXacthuc.Text = "Xác thực";
            this.btnXacthuc.UseVisualStyleBackColor = true;
            this.btnXacthuc.Click += new System.EventHandler(this.btnXacthuc_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(78, 57);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(263, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Email";
            // 
            // OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 204);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXacthuc);
            this.Controls.Add(this.btnGuiOTP);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.label1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "OTP";
            this.Text = "Xác thực tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnGuiOTP;
        private System.Windows.Forms.Button btnXacthuc;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
    }
}