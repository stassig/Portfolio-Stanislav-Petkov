namespace ProjectStudentHousing
{
    partial class AdminForm
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
            this.btnShowComplains = new System.Windows.Forms.Button();
            this.btnExitAccount = new System.Windows.Forms.Button();
            this.btnShowTenants = new System.Windows.Forms.Button();
            this.btnShowRules = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowComplains
            // 
            this.btnShowComplains.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnShowComplains.FlatAppearance.BorderSize = 0;
            this.btnShowComplains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowComplains.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowComplains.ForeColor = System.Drawing.Color.White;
            this.btnShowComplains.Location = new System.Drawing.Point(12, 164);
            this.btnShowComplains.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowComplains.Name = "btnShowComplains";
            this.btnShowComplains.Size = new System.Drawing.Size(225, 54);
            this.btnShowComplains.TabIndex = 2;
            this.btnShowComplains.Text = "Complaints";
            this.btnShowComplains.UseVisualStyleBackColor = false;
            this.btnShowComplains.Click += new System.EventHandler(this.btnShowComplains_Click);
            // 
            // btnExitAccount
            // 
            this.btnExitAccount.BackColor = System.Drawing.Color.Red;
            this.btnExitAccount.FlatAppearance.BorderSize = 0;
            this.btnExitAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExitAccount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExitAccount.Location = new System.Drawing.Point(184, 0);
            this.btnExitAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExitAccount.Name = "btnExitAccount";
            this.btnExitAccount.Size = new System.Drawing.Size(65, 43);
            this.btnExitAccount.TabIndex = 8;
            this.btnExitAccount.Text = "X";
            this.btnExitAccount.UseVisualStyleBackColor = false;
            this.btnExitAccount.Click += new System.EventHandler(this.btnQuitAccount_Click);
            // 
            // btnShowTenants
            // 
            this.btnShowTenants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnShowTenants.FlatAppearance.BorderSize = 0;
            this.btnShowTenants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowTenants.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowTenants.ForeColor = System.Drawing.Color.White;
            this.btnShowTenants.Location = new System.Drawing.Point(12, 227);
            this.btnShowTenants.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowTenants.Name = "btnShowTenants";
            this.btnShowTenants.Size = new System.Drawing.Size(225, 53);
            this.btnShowTenants.TabIndex = 19;
            this.btnShowTenants.Text = "Tenants";
            this.btnShowTenants.UseVisualStyleBackColor = false;
            this.btnShowTenants.Click += new System.EventHandler(this.btnShowTenants_Click);
            // 
            // btnShowRules
            // 
            this.btnShowRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnShowRules.FlatAppearance.BorderSize = 0;
            this.btnShowRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRules.ForeColor = System.Drawing.Color.White;
            this.btnShowRules.Location = new System.Drawing.Point(12, 102);
            this.btnShowRules.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowRules.Name = "btnShowRules";
            this.btnShowRules.Size = new System.Drawing.Size(225, 53);
            this.btnShowRules.TabIndex = 20;
            this.btnShowRules.Text = "Rules";
            this.btnShowRules.UseVisualStyleBackColor = false;
            this.btnShowRules.Click += new System.EventHandler(this.btnShowRules_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExitAccount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 43);
            this.panel1.TabIndex = 21;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Harlow Solid Italic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "Admin";
            // 
            // AdminForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(249, 355);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnShowRules);
            this.Controls.Add(this.btnShowTenants);
            this.Controls.Add(this.btnShowComplains);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnShowComplains;
        private System.Windows.Forms.Button btnExitAccount;
        private System.Windows.Forms.Button btnShowTenants;
        private System.Windows.Forms.Button btnShowRules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}