namespace OneFiDiRoad_Fleet_System
{
    partial class UC_Vehicles
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
            this.PL_UserBar = new System.Windows.Forms.Panel();
            this.LB_DisplayUserName = new System.Windows.Forms.Label();
            this.PL_UserBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // PL_UserBar
            // 
            this.PL_UserBar.Controls.Add(this.LB_DisplayUserName);
            this.PL_UserBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PL_UserBar.Location = new System.Drawing.Point(0, 0);
            this.PL_UserBar.Name = "PL_UserBar";
            this.PL_UserBar.Size = new System.Drawing.Size(1299, 140);
            this.PL_UserBar.TabIndex = 8;
            this.PL_UserBar.Visible = false;
            // 
            // LB_DisplayUserName
            // 
            this.LB_DisplayUserName.AutoSize = true;
            this.LB_DisplayUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_DisplayUserName.Location = new System.Drawing.Point(445, 57);
            this.LB_DisplayUserName.Name = "LB_DisplayUserName";
            this.LB_DisplayUserName.Size = new System.Drawing.Size(350, 25);
            this.LB_DisplayUserName.TabIndex = 4;
            this.LB_DisplayUserName.Text = "DONT PUT ANYTHNG IN THIS AREA";
            // 
            // UC_Vehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PL_UserBar);
            this.Name = "UC_Vehicles";
            this.Size = new System.Drawing.Size(1299, 951);
            this.PL_UserBar.ResumeLayout(false);
            this.PL_UserBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PL_UserBar;
        private System.Windows.Forms.Label LB_DisplayUserName;
    }
}
