namespace ProjectStudentHousing
{
    partial class fmRules
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
            this.reasoningLabel = new System.Windows.Forms.Label();
            this.rtxtHouseRules = new System.Windows.Forms.RichTextBox();
            this.rtxReason = new System.Windows.Forms.RichTextBox();
            this.btnSumbitRuleSuggestion = new System.Windows.Forms.Button();
            this.rtxSuggestion = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reasoningLabel
            // 
            this.reasoningLabel.AutoSize = true;
            this.reasoningLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reasoningLabel.ForeColor = System.Drawing.Color.White;
            this.reasoningLabel.Location = new System.Drawing.Point(364, 195);
            this.reasoningLabel.Name = "reasoningLabel";
            this.reasoningLabel.Size = new System.Drawing.Size(91, 29);
            this.reasoningLabel.TabIndex = 19;
            this.reasoningLabel.Text = "Reason:";
            this.reasoningLabel.Click += new System.EventHandler(this.reasoningLabel_Click);
            // 
            // rtxtHouseRules
            // 
            this.rtxtHouseRules.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtHouseRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxtHouseRules.Location = new System.Drawing.Point(12, 55);
            this.rtxtHouseRules.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtHouseRules.Name = "rtxtHouseRules";
            this.rtxtHouseRules.ReadOnly = true;
            this.rtxtHouseRules.Size = new System.Drawing.Size(333, 363);
            this.rtxtHouseRules.TabIndex = 14;
            this.rtxtHouseRules.Text = "";
            this.rtxtHouseRules.TextChanged += new System.EventHandler(this.rtxtHouseRules_TextChanged);
            // 
            // rtxReason
            // 
            this.rtxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxReason.Location = new System.Drawing.Point(369, 228);
            this.rtxReason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxReason.Name = "rtxReason";
            this.rtxReason.Size = new System.Drawing.Size(353, 131);
            this.rtxReason.TabIndex = 18;
            this.rtxReason.Text = "";
            // 
            // btnSumbitRuleSuggestion
            // 
            this.btnSumbitRuleSuggestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnSumbitRuleSuggestion.FlatAppearance.BorderSize = 0;
            this.btnSumbitRuleSuggestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumbitRuleSuggestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSumbitRuleSuggestion.ForeColor = System.Drawing.Color.White;
            this.btnSumbitRuleSuggestion.Location = new System.Drawing.Point(369, 367);
            this.btnSumbitRuleSuggestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSumbitRuleSuggestion.Name = "btnSumbitRuleSuggestion";
            this.btnSumbitRuleSuggestion.Size = new System.Drawing.Size(353, 51);
            this.btnSumbitRuleSuggestion.TabIndex = 17;
            this.btnSumbitRuleSuggestion.Text = "Submit";
            this.btnSumbitRuleSuggestion.UseVisualStyleBackColor = false;
            this.btnSumbitRuleSuggestion.Click += new System.EventHandler(this.btnSumbitRuleSuggestion_Click);
            // 
            // rtxSuggestion
            // 
            this.rtxSuggestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxSuggestion.Location = new System.Drawing.Point(369, 55);
            this.rtxSuggestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxSuggestion.Name = "rtxSuggestion";
            this.rtxSuggestion.Size = new System.Drawing.Size(353, 127);
            this.rtxSuggestion.TabIndex = 16;
            this.rtxSuggestion.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Harlow Solid Italic", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(360, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 51);
            this.label11.TabIndex = 15;
            this.label11.Text = "Suggest a rule";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Harlow Solid Italic", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 51);
            this.label5.TabIndex = 13;
            this.label5.Text = "House Rules";
            // 
            // fmRules
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(734, 431);
            this.Controls.Add(this.reasoningLabel);
            this.Controls.Add(this.rtxtHouseRules);
            this.Controls.Add(this.rtxReason);
            this.Controls.Add(this.btnSumbitRuleSuggestion);
            this.Controls.Add(this.rtxSuggestion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fmRules";
            this.Text = "fmRules";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label reasoningLabel;
        private System.Windows.Forms.RichTextBox rtxtHouseRules;
        private System.Windows.Forms.RichTextBox rtxReason;
        private System.Windows.Forms.Button btnSumbitRuleSuggestion;
        private System.Windows.Forms.RichTextBox rtxSuggestion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
    }
}