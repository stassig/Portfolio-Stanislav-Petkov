namespace ProjectStudentHousing
{
    partial class fmComplaints
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
            this.cbAnonymously = new System.Windows.Forms.CheckBox();
            this.btnSubmitComplain = new System.Windows.Forms.Button();
            this.rtxtComplain = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbComplains = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbAnonymously
            // 
            this.cbAnonymously.AutoSize = true;
            this.cbAnonymously.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAnonymously.ForeColor = System.Drawing.Color.White;
            this.cbAnonymously.Location = new System.Drawing.Point(12, 321);
            this.cbAnonymously.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbAnonymously.Name = "cbAnonymously";
            this.cbAnonymously.Size = new System.Drawing.Size(174, 33);
            this.cbAnonymously.TabIndex = 11;
            this.cbAnonymously.Text = "Anonymously";
            this.cbAnonymously.UseVisualStyleBackColor = true;
            // 
            // btnSubmitComplain
            // 
            this.btnSubmitComplain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnSubmitComplain.FlatAppearance.BorderSize = 0;
            this.btnSubmitComplain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitComplain.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmitComplain.ForeColor = System.Drawing.Color.White;
            this.btnSubmitComplain.Location = new System.Drawing.Point(12, 362);
            this.btnSubmitComplain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmitComplain.Name = "btnSubmitComplain";
            this.btnSubmitComplain.Size = new System.Drawing.Size(710, 56);
            this.btnSubmitComplain.TabIndex = 10;
            this.btnSubmitComplain.Text = "Submit";
            this.btnSubmitComplain.UseVisualStyleBackColor = false;
            this.btnSubmitComplain.Click += new System.EventHandler(this.btnSubmitComplain_Click);
            // 
            // rtxtComplain
            // 
            this.rtxtComplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxtComplain.Location = new System.Drawing.Point(12, 168);
            this.rtxtComplain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtComplain.Name = "rtxtComplain";
            this.rtxtComplain.Size = new System.Drawing.Size(710, 145);
            this.rtxtComplain.TabIndex = 9;
            this.rtxtComplain.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 39);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tell us more about it.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 39);
            this.label2.TabIndex = 7;
            this.label2.Text = "What is the complaint related to?";
            // 
            // cmbComplains
            // 
            this.cmbComplains.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplains.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbComplains.FormattingEnabled = true;
            this.cmbComplains.Items.AddRange(new object[] {
            "Noise",
            "Cleaning",
            "Paying ",
            "Other"});
            this.cmbComplains.Location = new System.Drawing.Point(17, 62);
            this.cmbComplains.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbComplains.Name = "cmbComplains";
            this.cmbComplains.Size = new System.Drawing.Size(705, 47);
            this.cmbComplains.TabIndex = 12;
            // 
            // fmComplaints
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(734, 431);
            this.Controls.Add(this.cmbComplains);
            this.Controls.Add(this.cbAnonymously);
            this.Controls.Add(this.btnSubmitComplain);
            this.Controls.Add(this.rtxtComplain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fmComplaints";
            this.Text = "frmComplaints";
            this.Load += new System.EventHandler(this.frmComplaints_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAnonymously;
        private System.Windows.Forms.Button btnSubmitComplain;
        private System.Windows.Forms.RichTextBox rtxtComplain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbComplains;
    }
}