namespace FileShare
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.create_button = new Bunifu.Framework.UI.BunifuThinButton2();
            this.join_button = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.status = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 49);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "FileShare";
            // 
            // create_button
            // 
            this.create_button.ActiveBorderThickness = 1;
            this.create_button.ActiveCornerRadius = 20;
            this.create_button.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.create_button.ActiveForecolor = System.Drawing.Color.DarkGreen;
            this.create_button.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.create_button.BackColor = System.Drawing.SystemColors.Control;
            this.create_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("create_button.BackgroundImage")));
            this.create_button.ButtonText = "CREATE";
            this.create_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create_button.Font = new System.Drawing.Font("Leelawadee UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_button.ForeColor = System.Drawing.Color.SeaGreen;
            this.create_button.IdleBorderThickness = 1;
            this.create_button.IdleCornerRadius = 20;
            this.create_button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.create_button.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.create_button.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.create_button.Location = new System.Drawing.Point(36, 127);
            this.create_button.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(201, 44);
            this.create_button.TabIndex = 2;
            this.create_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.create_button.Click += new System.EventHandler(this.create_button_Click);
            // 
            // join_button
            // 
            this.join_button.ActiveBorderThickness = 1;
            this.join_button.ActiveCornerRadius = 20;
            this.join_button.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.join_button.ActiveForecolor = System.Drawing.Color.DarkGreen;
            this.join_button.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.join_button.BackColor = System.Drawing.SystemColors.Control;
            this.join_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("join_button.BackgroundImage")));
            this.join_button.ButtonText = "JOIN";
            this.join_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.join_button.Font = new System.Drawing.Font("Leelawadee UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.join_button.ForeColor = System.Drawing.Color.SeaGreen;
            this.join_button.IdleBorderThickness = 1;
            this.join_button.IdleCornerRadius = 20;
            this.join_button.IdleFillColor = System.Drawing.Color.Cyan;
            this.join_button.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.join_button.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.join_button.Location = new System.Drawing.Point(36, 235);
            this.join_button.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.join_button.Name = "join_button";
            this.join_button.Size = new System.Drawing.Size(201, 44);
            this.join_button.TabIndex = 3;
            this.join_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.join_button.Click += new System.EventHandler(this.join_button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.status);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 42);
            this.panel2.TabIndex = 4;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.Color.White;
            this.status.Location = new System.Drawing.Point(12, 7);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 26);
            this.status.TabIndex = 0;
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 488);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.join_button);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 create_button;
        private Bunifu.Framework.UI.BunifuThinButton2 join_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label status;
    }
}

