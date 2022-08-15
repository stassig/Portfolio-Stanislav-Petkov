namespace ProjectStudentHousing
{
    partial class TenantForm
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
            this.btnExitAccount = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbnBackToHome = new FontAwesome.Sharp.IconButton();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnRules = new FontAwesome.Sharp.IconButton();
            this.btnAgreements = new FontAwesome.Sharp.IconButton();
            this.btnComplaints = new FontAwesome.Sharp.IconButton();
            this.btnEvents = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTabName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlFormLoader = new System.Windows.Forms.Panel();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlFormLoader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExitAccount
            // 
            this.btnExitAccount.BackColor = System.Drawing.Color.Red;
            this.btnExitAccount.FlatAppearance.BorderSize = 0;
            this.btnExitAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitAccount.Location = new System.Drawing.Point(681, 0);
            this.btnExitAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExitAccount.Name = "btnExitAccount";
            this.btnExitAccount.Size = new System.Drawing.Size(77, 47);
            this.btnExitAccount.TabIndex = 7;
            this.btnExitAccount.Text = "X";
            this.btnExitAccount.UseVisualStyleBackColor = false;
            this.btnExitAccount.Click += new System.EventHandler(this.btnExitAccount_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(51)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.tbnBackToHome);
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnRules);
            this.panel1.Controls.Add(this.btnAgreements);
            this.panel1.Controls.Add(this.btnComplaints);
            this.panel1.Controls.Add(this.btnEvents);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 497);
            this.panel1.TabIndex = 8;
            // 
            // tbnBackToHome
            // 
            this.tbnBackToHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbnBackToHome.FlatAppearance.BorderSize = 0;
            this.tbnBackToHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbnBackToHome.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnBackToHome.ForeColor = System.Drawing.Color.White;
            this.tbnBackToHome.IconChar = FontAwesome.Sharp.IconChar.HouseUser;
            this.tbnBackToHome.IconColor = System.Drawing.Color.Black;
            this.tbnBackToHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.tbnBackToHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbnBackToHome.Location = new System.Drawing.Point(0, 440);
            this.tbnBackToHome.Name = "tbnBackToHome";
            this.tbnBackToHome.Padding = new System.Windows.Forms.Padding(9, 0, 18, 0);
            this.tbnBackToHome.Size = new System.Drawing.Size(280, 57);
            this.tbnBackToHome.TabIndex = 6;
            this.tbnBackToHome.Text = "Back to Home";
            this.tbnBackToHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tbnBackToHome.UseVisualStyleBackColor = true;
            this.tbnBackToHome.Click += new System.EventHandler(this.tbnBackToHome_Click);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.pnlNav.Location = new System.Drawing.Point(-6, 138);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(9, 230);
            this.pnlNav.TabIndex = 5;
            this.pnlNav.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNav_Paint);
            // 
            // btnRules
            // 
            this.btnRules.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRules.FlatAppearance.BorderSize = 0;
            this.btnRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRules.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRules.ForeColor = System.Drawing.Color.White;
            this.btnRules.IconChar = FontAwesome.Sharp.IconChar.ListOl;
            this.btnRules.IconColor = System.Drawing.Color.Black;
            this.btnRules.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRules.Location = new System.Drawing.Point(0, 309);
            this.btnRules.Name = "btnRules";
            this.btnRules.Padding = new System.Windows.Forms.Padding(9, 0, 18, 0);
            this.btnRules.Size = new System.Drawing.Size(280, 57);
            this.btnRules.TabIndex = 4;
            this.btnRules.Text = "Rules";
            this.btnRules.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            this.btnRules.Leave += new System.EventHandler(this.btnRules_Leave);
            // 
            // btnAgreements
            // 
            this.btnAgreements.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgreements.FlatAppearance.BorderSize = 0;
            this.btnAgreements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgreements.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgreements.ForeColor = System.Drawing.Color.White;
            this.btnAgreements.IconChar = FontAwesome.Sharp.IconChar.Handshake;
            this.btnAgreements.IconColor = System.Drawing.Color.Black;
            this.btnAgreements.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgreements.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgreements.Location = new System.Drawing.Point(0, 252);
            this.btnAgreements.Name = "btnAgreements";
            this.btnAgreements.Padding = new System.Windows.Forms.Padding(9, 0, 18, 0);
            this.btnAgreements.Size = new System.Drawing.Size(280, 57);
            this.btnAgreements.TabIndex = 3;
            this.btnAgreements.Text = "Agreements";
            this.btnAgreements.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgreements.UseVisualStyleBackColor = true;
            this.btnAgreements.Click += new System.EventHandler(this.btnAgreements_Click);
            this.btnAgreements.Leave += new System.EventHandler(this.btnAgreements_Leave);
            // 
            // btnComplaints
            // 
            this.btnComplaints.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnComplaints.FlatAppearance.BorderSize = 0;
            this.btnComplaints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplaints.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplaints.ForeColor = System.Drawing.Color.White;
            this.btnComplaints.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnComplaints.IconColor = System.Drawing.Color.Black;
            this.btnComplaints.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnComplaints.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComplaints.Location = new System.Drawing.Point(0, 195);
            this.btnComplaints.Name = "btnComplaints";
            this.btnComplaints.Padding = new System.Windows.Forms.Padding(9, 0, 18, 0);
            this.btnComplaints.Size = new System.Drawing.Size(280, 57);
            this.btnComplaints.TabIndex = 2;
            this.btnComplaints.Text = "File a complaint";
            this.btnComplaints.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComplaints.UseVisualStyleBackColor = true;
            this.btnComplaints.Click += new System.EventHandler(this.btnComplaints_Click);
            this.btnComplaints.Leave += new System.EventHandler(this.btnComplaints_Leave);
            // 
            // btnEvents
            // 
            this.btnEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEvents.FlatAppearance.BorderSize = 0;
            this.btnEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvents.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvents.ForeColor = System.Drawing.Color.White;
            this.btnEvents.IconChar = FontAwesome.Sharp.IconChar.CalendarDay;
            this.btnEvents.IconColor = System.Drawing.Color.Black;
            this.btnEvents.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEvents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEvents.Location = new System.Drawing.Point(0, 138);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Padding = new System.Windows.Forms.Padding(9, 0, 18, 0);
            this.btnEvents.Size = new System.Drawing.Size(280, 57);
            this.btnEvents.TabIndex = 1;
            this.btnEvents.Text = "Events";
            this.btnEvents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            this.btnEvents.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnEvents_KeyUp);
            this.btnEvents.Leave += new System.EventHandler(this.btnEvents_Leave);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ProjectStudentHousing.Properties.Resources.Logo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 138);
            this.panel2.TabIndex = 0;
            // 
            // lblTabName
            // 
            this.lblTabName.AutoSize = true;
            this.lblTabName.Font = new System.Drawing.Font("Harlow Solid Italic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTabName.Location = new System.Drawing.Point(3, 0);
            this.lblTabName.Name = "lblTabName";
            this.lblTabName.Size = new System.Drawing.Size(112, 45);
            this.lblTabName.TabIndex = 9;
            this.lblTabName.Text = "Home";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.panel3.Controls.Add(this.btnExitAccount);
            this.panel3.Controls.Add(this.lblTabName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(280, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(757, 47);
            this.panel3.TabIndex = 10;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // pnlFormLoader
            // 
            this.pnlFormLoader.Controls.Add(this.lbWelcome);
            this.pnlFormLoader.Location = new System.Drawing.Point(291, 54);
            this.pnlFormLoader.Name = "pnlFormLoader";
            this.pnlFormLoader.Size = new System.Drawing.Size(734, 431);
            this.pnlFormLoader.TabIndex = 11;
            this.pnlFormLoader.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.White;
            this.lbWelcome.Location = new System.Drawing.Point(86, 84);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(0, 88);
            this.lbWelcome.TabIndex = 0;
            // 
            // TenantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1037, 497);
            this.Controls.Add(this.pnlFormLoader);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TenantForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tenant";
            this.Load += new System.EventHandler(this.TenantForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlFormLoader.ResumeLayout(false);
            this.pnlFormLoader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExitAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnRules;
        private FontAwesome.Sharp.IconButton btnAgreements;
        private FontAwesome.Sharp.IconButton btnComplaints;
        private FontAwesome.Sharp.IconButton btnEvents;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lblTabName;
        private FontAwesome.Sharp.IconButton tbnBackToHome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlFormLoader;
        private System.Windows.Forms.Label lbWelcome;
    }
}