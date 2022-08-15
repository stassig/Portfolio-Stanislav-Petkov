namespace ProjectStudentHousing
{
    partial class fmAgr
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
            this.lbAgreements = new System.Windows.Forms.ListBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddAgreement = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemoveAgreement = new System.Windows.Forms.Button();
            this.tbAgreement = new System.Windows.Forms.RichTextBox();
            this.tbEditAgreement = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbAgreements
            // 
            this.lbAgreements.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAgreements.FormattingEnabled = true;
            this.lbAgreements.ItemHeight = 25;
            this.lbAgreements.Location = new System.Drawing.Point(12, 82);
            this.lbAgreements.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbAgreements.Name = "lbAgreements";
            this.lbAgreements.Size = new System.Drawing.Size(266, 329);
            this.lbAgreements.TabIndex = 19;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(321, 374);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(401, 37);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(284, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 0);
            this.label10.TabIndex = 16;
            this.label10.Text = "Edit Agreement";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Click += new System.EventHandler(this.label10_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Harlow Solid Italic", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(312, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(410, 51);
            this.label8.TabIndex = 15;
            this.label8.Text = "Agreement\'s description";
            // 
            // btnAddAgreement
            // 
            this.btnAddAgreement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnAddAgreement.FlatAppearance.BorderSize = 0;
            this.btnAddAgreement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAgreement.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddAgreement.ForeColor = System.Drawing.Color.White;
            this.btnAddAgreement.Location = new System.Drawing.Point(321, 199);
            this.btnAddAgreement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddAgreement.Name = "btnAddAgreement";
            this.btnAddAgreement.Size = new System.Drawing.Size(199, 51);
            this.btnAddAgreement.TabIndex = 13;
            this.btnAddAgreement.Text = "Add";
            this.btnAddAgreement.UseVisualStyleBackColor = false;
            this.btnAddAgreement.Click += new System.EventHandler(this.btnAddAgreement_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Harlow Solid Italic", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 51);
            this.label4.TabIndex = 12;
            this.label4.Text = "Agreements";
            // 
            // btnRemoveAgreement
            // 
            this.btnRemoveAgreement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnRemoveAgreement.FlatAppearance.BorderSize = 0;
            this.btnRemoveAgreement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAgreement.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveAgreement.ForeColor = System.Drawing.Color.White;
            this.btnRemoveAgreement.Location = new System.Drawing.Point(526, 199);
            this.btnRemoveAgreement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveAgreement.Name = "btnRemoveAgreement";
            this.btnRemoveAgreement.Size = new System.Drawing.Size(196, 51);
            this.btnRemoveAgreement.TabIndex = 20;
            this.btnRemoveAgreement.Text = "Remove";
            this.btnRemoveAgreement.UseVisualStyleBackColor = false;
            this.btnRemoveAgreement.Click += new System.EventHandler(this.btnRemoveAgreement_Click);
            // 
            // tbAgreement
            // 
            this.tbAgreement.Location = new System.Drawing.Point(321, 257);
            this.tbAgreement.Name = "tbAgreement";
            this.tbAgreement.Size = new System.Drawing.Size(401, 110);
            this.tbAgreement.TabIndex = 21;
            this.tbAgreement.Text = "";
            // 
            // tbEditAgreement
            // 
            this.tbEditAgreement.Location = new System.Drawing.Point(321, 82);
            this.tbEditAgreement.Name = "tbEditAgreement";
            this.tbEditAgreement.Size = new System.Drawing.Size(401, 110);
            this.tbEditAgreement.TabIndex = 22;
            this.tbEditAgreement.Text = "";
            // 
            // fmAgr
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(734, 431);
            this.Controls.Add(this.tbEditAgreement);
            this.Controls.Add(this.tbAgreement);
            this.Controls.Add(this.btnRemoveAgreement);
            this.Controls.Add(this.lbAgreements);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAddAgreement);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fmAgr";
            this.Text = "fmAgr";
            this.Load += new System.EventHandler(this.fmAgr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAgreements;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddAgreement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveAgreement;
        private System.Windows.Forms.RichTextBox tbAgreement;
        private System.Windows.Forms.RichTextBox tbEditAgreement;
    }
}