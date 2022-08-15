namespace Employees_administration
{
    partial class ScheduleEmployeeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbAssignedEmployees = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbAvailablemployees = new System.Windows.Forms.ListBox();
            this.lblScheduleDate = new System.Windows.Forms.Label();
            this.lblRequiredEmployees = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Schedule for:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(239, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minimum required employees:";
            // 
            // btnAssign
            // 
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(115, 438);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(102, 58);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(606, 438);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(102, 58);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbAssignedEmployees
            // 
            this.lbAssignedEmployees.FormattingEnabled = true;
            this.lbAssignedEmployees.ItemHeight = 16;
            this.lbAssignedEmployees.Location = new System.Drawing.Point(528, 144);
            this.lbAssignedEmployees.Name = "lbAssignedEmployees";
            this.lbAssignedEmployees.Size = new System.Drawing.Size(250, 276);
            this.lbAssignedEmployees.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Available Employees";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(574, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Assigned Employees";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(359, 246);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 62);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbAvailablemployees
            // 
            this.lbAvailablemployees.FormattingEnabled = true;
            this.lbAvailablemployees.ItemHeight = 16;
            this.lbAvailablemployees.Location = new System.Drawing.Point(47, 144);
            this.lbAvailablemployees.Name = "lbAvailablemployees";
            this.lbAvailablemployees.Size = new System.Drawing.Size(250, 276);
            this.lbAvailablemployees.TabIndex = 10;
            // 
            // lblScheduleDate
            // 
            this.lblScheduleDate.AutoSize = true;
            this.lblScheduleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheduleDate.Location = new System.Drawing.Point(364, 31);
            this.lblScheduleDate.Name = "lblScheduleDate";
            this.lblScheduleDate.Size = new System.Drawing.Size(53, 20);
            this.lblScheduleDate.TabIndex = 11;
            this.lblScheduleDate.Text = "label5";
            // 
            // lblRequiredEmployees
            // 
            this.lblRequiredEmployees.AutoSize = true;
            this.lblRequiredEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiredEmployees.Location = new System.Drawing.Point(490, 61);
            this.lblRequiredEmployees.Name = "lblRequiredEmployees";
            this.lblRequiredEmployees.Size = new System.Drawing.Size(53, 20);
            this.lblRequiredEmployees.TabIndex = 12;
            this.lblRequiredEmployees.Text = "label6";
            // 
            // ScheduleEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 542);
            this.Controls.Add(this.lblRequiredEmployees);
            this.Controls.Add(this.lblScheduleDate);
            this.Controls.Add(this.lbAvailablemployees);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lbAssignedEmployees);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ScheduleEmployeeForm";
            this.Text = "ScheduleEmployeeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScheduleEmployeeForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbAssignedEmployees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListBox lbAvailablemployees;
        private System.Windows.Forms.Label lblScheduleDate;
        private System.Windows.Forms.Label lblRequiredEmployees;
    }
}