namespace Loccassion2._0
{
    partial class StartUpWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUpWindow));
            this.LabelLoccassion = new System.Windows.Forms.Label();
            this.PictureBoxStartUpWindow = new System.Windows.Forms.PictureBox();
            this.panelStartUp2 = new System.Windows.Forms.Panel();
            this.lblVersionNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartUpWindow)).BeginInit();
            this.panelStartUp2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelLoccassion
            // 
            this.LabelLoccassion.AutoSize = true;
            this.LabelLoccassion.Font = new System.Drawing.Font("Microsoft YaHei UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelLoccassion.ForeColor = System.Drawing.SystemColors.Control;
            this.LabelLoccassion.Location = new System.Drawing.Point(27, 282);
            this.LabelLoccassion.Name = "LabelLoccassion";
            this.LabelLoccassion.Size = new System.Drawing.Size(294, 72);
            this.LabelLoccassion.TabIndex = 1;
            this.LabelLoccassion.Text = "Locassion";
            this.LabelLoccassion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBoxStartUpWindow
            // 
            this.PictureBoxStartUpWindow.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxStartUpWindow.ErrorImage")));
            this.PictureBoxStartUpWindow.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxStartUpWindow.Image")));
            this.PictureBoxStartUpWindow.Location = new System.Drawing.Point(39, 53);
            this.PictureBoxStartUpWindow.Name = "PictureBoxStartUpWindow";
            this.PictureBoxStartUpWindow.Size = new System.Drawing.Size(252, 255);
            this.PictureBoxStartUpWindow.TabIndex = 2;
            this.PictureBoxStartUpWindow.TabStop = false;
            // 
            // panelStartUp2
            // 
            this.panelStartUp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelStartUp2.Controls.Add(this.lblVersionNumber);
            this.panelStartUp2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStartUp2.Location = new System.Drawing.Point(0, 436);
            this.panelStartUp2.Name = "panelStartUp2";
            this.panelStartUp2.Size = new System.Drawing.Size(340, 18);
            this.panelStartUp2.TabIndex = 4;
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.AutoSize = true;
            this.lblVersionNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVersionNumber.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVersionNumber.Location = new System.Drawing.Point(295, 0);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(45, 16);
            this.lblVersionNumber.TabIndex = 8;
            this.lblVersionNumber.Text = "ver: 1.0";
            // 
            // StartUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.ClientSize = new System.Drawing.Size(340, 454);
            this.Controls.Add(this.LabelLoccassion);
            this.Controls.Add(this.PictureBoxStartUpWindow);
            this.Controls.Add(this.panelStartUp2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartUpWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStartUpWindow)).EndInit();
            this.panelStartUp2.ResumeLayout(false);
            this.panelStartUp2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelLoccassion;
        private System.Windows.Forms.Panel panelStartUp2;
        private System.Windows.Forms.PictureBox PictureBoxStartUpWindow;
        private System.Windows.Forms.Label lblVersionNumber;
    }
}

