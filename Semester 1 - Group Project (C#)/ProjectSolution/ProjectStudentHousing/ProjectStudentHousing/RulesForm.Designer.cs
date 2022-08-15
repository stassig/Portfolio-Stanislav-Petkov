namespace ProjectStudentHousing
{
    partial class RulesForm
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
            this.btnRemoveRule = new System.Windows.Forms.Button();
            this.lbRules = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbSuggestions = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtNewDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.rtxtRule = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemoveRule
            // 
            this.btnRemoveRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnRemoveRule.FlatAppearance.BorderSize = 0;
            this.btnRemoveRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRule.ForeColor = System.Drawing.Color.White;
            this.btnRemoveRule.Location = new System.Drawing.Point(594, 209);
            this.btnRemoveRule.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveRule.Name = "btnRemoveRule";
            this.btnRemoveRule.Size = new System.Drawing.Size(168, 50);
            this.btnRemoveRule.TabIndex = 29;
            this.btnRemoveRule.Text = "Remove";
            this.btnRemoveRule.UseVisualStyleBackColor = false;
            this.btnRemoveRule.Click += new System.EventHandler(this.btnRemoveRule_Click);
            // 
            // lbRules
            // 
            this.lbRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbRules.FormattingEnabled = true;
            this.lbRules.ItemHeight = 25;
            this.lbRules.Location = new System.Drawing.Point(22, 97);
            this.lbRules.Margin = new System.Windows.Forms.Padding(4);
            this.lbRules.Name = "lbRules";
            this.lbRules.Size = new System.Drawing.Size(320, 379);
            this.lbRules.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(853, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 35);
            this.label4.TabIndex = 27;
            this.label4.Text = "Suggestions by tenants:";
            // 
            // lbSuggestions
            // 
            this.lbSuggestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSuggestions.FormattingEnabled = true;
            this.lbSuggestions.ItemHeight = 25;
            this.lbSuggestions.Location = new System.Drawing.Point(859, 97);
            this.lbSuggestions.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lbSuggestions.Name = "lbSuggestions";
            this.lbSuggestions.Size = new System.Drawing.Size(309, 379);
            this.lbSuggestions.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(421, 274);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 29);
            this.label3.TabIndex = 25;
            this.label3.Text = "Change the description of a rule:";
            // 
            // rtxtNewDescription
            // 
            this.rtxtNewDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxtNewDescription.Location = new System.Drawing.Point(427, 316);
            this.rtxtNewDescription.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtNewDescription.Name = "rtxtNewDescription";
            this.rtxtNewDescription.Size = new System.Drawing.Size(335, 112);
            this.rtxtNewDescription.TabIndex = 24;
            this.rtxtNewDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 35);
            this.label5.TabIndex = 19;
            this.label5.Text = "Current House Rules:";
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnChange.FlatAppearance.BorderSize = 0;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Location = new System.Drawing.Point(427, 434);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(335, 50);
            this.btnChange.TabIndex = 23;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(420, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 35);
            this.label1.TabIndex = 20;
            this.label1.Text = "Add a new Rule:";
            // 
            // btnAddRule
            // 
            this.btnAddRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.btnAddRule.FlatAppearance.BorderSize = 0;
            this.btnAddRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRule.ForeColor = System.Drawing.Color.White;
            this.btnAddRule.Location = new System.Drawing.Point(426, 209);
            this.btnAddRule.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(160, 50);
            this.btnAddRule.TabIndex = 22;
            this.btnAddRule.Text = "Add";
            this.btnAddRule.UseVisualStyleBackColor = false;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // rtxtRule
            // 
            this.rtxtRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxtRule.Location = new System.Drawing.Point(426, 97);
            this.rtxtRule.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtRule.Name = "rtxtRule";
            this.rtxtRule.Size = new System.Drawing.Size(335, 105);
            this.rtxtRule.TabIndex = 21;
            this.rtxtRule.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(96)))), ((int)(((byte)(130)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1205, 44);
            this.panel1.TabIndex = 30;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Harlow Solid Italic", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rules";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(1126, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RulesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1205, 516);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRemoveRule);
            this.Controls.Add(this.lbRules);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbSuggestions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtxtNewDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddRule);
            this.Controls.Add(this.rtxtRule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RulesForm";
            this.Text = "Rules";
            this.Load += new System.EventHandler(this.RulesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveRule;
        private System.Windows.Forms.ListBox lbRules;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbSuggestions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtNewDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.RichTextBox rtxtRule;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}