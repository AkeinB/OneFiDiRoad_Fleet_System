namespace OneFiDiRoad_Fleet_System
{
    partial class Login
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LB_UserName = new System.Windows.Forms.Label();
            this.TB_UserName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LB_Password = new System.Windows.Forms.Label();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.CHB_ShowPassword = new System.Windows.Forms.CheckBox();
            this.LB_IncorretCredentials = new System.Windows.Forms.Label();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTN_Login);
            this.groupBox1.Controls.Add(this.LB_IncorretCredentials);
            this.groupBox1.Controls.Add(this.CHB_ShowPassword);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(15, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 304);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOGIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LB_UserName);
            this.groupBox2.Controls.Add(this.TB_UserName);
            this.groupBox2.Location = new System.Drawing.Point(14, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 60);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // LB_UserName
            // 
            this.LB_UserName.AutoSize = true;
            this.LB_UserName.Location = new System.Drawing.Point(16, 23);
            this.LB_UserName.Name = "LB_UserName";
            this.LB_UserName.Size = new System.Drawing.Size(55, 13);
            this.LB_UserName.TabIndex = 4;
            this.LB_UserName.Text = "Username";
            // 
            // TB_UserName
            // 
            this.TB_UserName.Location = new System.Drawing.Point(75, 20);
            this.TB_UserName.Name = "TB_UserName";
            this.TB_UserName.Size = new System.Drawing.Size(251, 20);
            this.TB_UserName.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LB_Password);
            this.groupBox3.Controls.Add(this.TB_Password);
            this.groupBox3.Location = new System.Drawing.Point(14, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 60);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // LB_Password
            // 
            this.LB_Password.AutoSize = true;
            this.LB_Password.Location = new System.Drawing.Point(16, 23);
            this.LB_Password.Name = "LB_Password";
            this.LB_Password.Size = new System.Drawing.Size(53, 13);
            this.LB_Password.TabIndex = 4;
            this.LB_Password.Text = "Password";
            // 
            // TB_Password
            // 
            this.TB_Password.Location = new System.Drawing.Point(75, 20);
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.PasswordChar = '*';
            this.TB_Password.Size = new System.Drawing.Size(251, 20);
            this.TB_Password.TabIndex = 3;
            // 
            // CHB_ShowPassword
            // 
            this.CHB_ShowPassword.AutoSize = true;
            this.CHB_ShowPassword.Location = new System.Drawing.Point(14, 189);
            this.CHB_ShowPassword.Name = "CHB_ShowPassword";
            this.CHB_ShowPassword.Size = new System.Drawing.Size(102, 17);
            this.CHB_ShowPassword.TabIndex = 2;
            this.CHB_ShowPassword.Text = "Show Password";
            this.CHB_ShowPassword.UseVisualStyleBackColor = true;
            this.CHB_ShowPassword.CheckedChanged += new System.EventHandler(this.CB_ShowPassword_CheckedChanged);
            // 
            // LB_IncorretCredentials
            // 
            this.LB_IncorretCredentials.AutoSize = true;
            this.LB_IncorretCredentials.Location = new System.Drawing.Point(147, 189);
            this.LB_IncorretCredentials.Name = "LB_IncorretCredentials";
            this.LB_IncorretCredentials.Size = new System.Drawing.Size(185, 13);
            this.LB_IncorretCredentials.TabIndex = 3;
            this.LB_IncorretCredentials.Text = "Incorrect Credentials! Please try again";
            this.LB_IncorretCredentials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_IncorretCredentials.Visible = false;
            // 
            // BTN_Login
            // 
            this.BTN_Login.Location = new System.Drawing.Point(126, 253);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(99, 33);
            this.BTN_Login.TabIndex = 4;
            this.BTN_Login.Text = "Login";
            this.BTN_Login.UseVisualStyleBackColor = true;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.BTN_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 439);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(422, 478);
            this.MinimumSize = new System.Drawing.Size(422, 478);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTN_Login;
        private System.Windows.Forms.Label LB_IncorretCredentials;
        private System.Windows.Forms.CheckBox CHB_ShowPassword;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LB_Password;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LB_UserName;
        private System.Windows.Forms.TextBox TB_UserName;
        private System.Windows.Forms.Label label1;
    }
}

