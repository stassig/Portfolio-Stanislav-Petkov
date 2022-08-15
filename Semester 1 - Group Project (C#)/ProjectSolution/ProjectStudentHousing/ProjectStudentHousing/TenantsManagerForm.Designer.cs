namespace ProjectStudentHousing
{
    partial class TenantsManagerForm
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
            this.lbTenants = new System.Windows.Forms.ListBox();
            this.btnAddTenant = new System.Windows.Forms.Button();
            this.btnRemoveTenant = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnGetAllData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTenants
            // 
            this.lbTenants.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenants.FormattingEnabled = true;
            this.lbTenants.ItemHeight = 25;
            this.lbTenants.Location = new System.Drawing.Point(255, 110);
            this.lbTenants.Margin = new System.Windows.Forms.Padding(4);
            this.lbTenants.Name = "lbTenants";
            this.lbTenants.Size = new System.Drawing.Size(243, 329);
            this.lbTenants.TabIndex = 0;
            // 
            // btnAddTenant
            // 
            this.btnAddTenant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnAddTenant.FlatAppearance.BorderSize = 0;
            this.btnAddTenant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTenant.ForeColor = System.Drawing.Color.White;
            this.btnAddTenant.Location = new System.Drawing.Point(7, 172);
            this.btnAddTenant.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTenant.Name = "btnAddTenant";
            this.btnAddTenant.Size = new System.Drawing.Size(228, 36);
            this.btnAddTenant.TabIndex = 1;
            this.btnAddTenant.Text = "Add";
            this.btnAddTenant.UseVisualStyleBackColor = false;
            this.btnAddTenant.Click += new System.EventHandler(this.btnAddTenant_Click);
            // 
            // btnRemoveTenant
            // 
            this.btnRemoveTenant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnRemoveTenant.FlatAppearance.BorderSize = 0;
            this.btnRemoveTenant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveTenant.ForeColor = System.Drawing.Color.White;
            this.btnRemoveTenant.Location = new System.Drawing.Point(255, 455);
            this.btnRemoveTenant.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveTenant.Name = "btnRemoveTenant";
            this.btnRemoveTenant.Size = new System.Drawing.Size(243, 52);
            this.btnRemoveTenant.TabIndex = 2;
            this.btnRemoveTenant.Text = "Remove";
            this.btnRemoveTenant.UseVisualStyleBackColor = false;
            this.btnRemoveTenant.Click += new System.EventHandler(this.btnRemoveTenant_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Harlow Solid Italic", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(249, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Tenants";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(4, 38);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(231, 26);
            this.txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(7, 114);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(228, 26);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnGetAllData
            // 
            this.btnGetAllData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnGetAllData.FlatAppearance.BorderSize = 0;
            this.btnGetAllData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAllData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAllData.ForeColor = System.Drawing.Color.White;
            this.btnGetAllData.Location = new System.Drawing.Point(255, 515);
            this.btnGetAllData.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetAllData.Name = "btnGetAllData";
            this.btnGetAllData.Size = new System.Drawing.Size(243, 52);
            this.btnGetAllData.TabIndex = 8;
            this.btnGetAllData.Text = "Get All Data";
            this.btnGetAllData.UseVisualStyleBackColor = false;
            this.btnGetAllData.Click += new System.EventHandler(this.btnGetAllData_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 39);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Harlow Solid Italic", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 35);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tenant Manager";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExit.Location = new System.Drawing.Point(448, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 39);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Harlow Solid Italic", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 35);
            this.label5.TabIndex = 10;
            this.label5.Text = "Add a new tenant:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(51)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.btnAddTenant);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Location = new System.Drawing.Point(9, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 242);
            this.panel2.TabIndex = 11;
            // 
            // TenantsManagerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(511, 580);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGetAllData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveTenant);
            this.Controls.Add(this.lbTenants);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TenantsManagerForm";
            this.Text = "Tenants";
            this.Load += new System.EventHandler(this.Tenants_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTenants;
        private System.Windows.Forms.Button btnAddTenant;
        private System.Windows.Forms.Button btnRemoveTenant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnGetAllData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
    }
}