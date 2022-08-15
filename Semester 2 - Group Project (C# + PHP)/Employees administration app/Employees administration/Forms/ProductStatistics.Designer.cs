namespace Employees_administration
{
    partial class ProductStatistics
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
            this.btnSingleProductStatistics = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDateSingle = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDateSingle = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnViewOverallStatistics = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAmountSold = new System.Windows.Forms.Label();
            this.lblProductTurnover = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalTurnover = new System.Windows.Forms.Label();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSingleProductStatistics
            // 
            this.btnSingleProductStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleProductStatistics.Location = new System.Drawing.Point(102, 288);
            this.btnSingleProductStatistics.Name = "btnSingleProductStatistics";
            this.btnSingleProductStatistics.Size = new System.Drawing.Size(110, 37);
            this.btnSingleProductStatistics.TabIndex = 61;
            this.btnSingleProductStatistics.Text = "View";
            this.btnSingleProductStatistics.UseVisualStyleBackColor = true;
            this.btnSingleProductStatistics.Click += new System.EventHandler(this.ViewTimePeriodStatistics_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Overall turnover:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(96, 69);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDate.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 18);
            this.label13.TabIndex = 54;
            this.label13.Text = "Start : ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(96, 97);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 22);
            this.dtpEndDate.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 18);
            this.label12.TabIndex = 52;
            this.label12.Text = "Finish:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 18);
            this.label6.TabIndex = 47;
            this.label6.Text = "Select Time Period: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "Turnover of the product:";
            // 
            // dtpStartDateSingle
            // 
            this.dtpStartDateSingle.Location = new System.Drawing.Point(92, 121);
            this.dtpStartDateSingle.Name = "dtpStartDateSingle";
            this.dtpStartDateSingle.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDateSingle.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 66;
            this.label2.Text = "Start : ";
            // 
            // dtpEndDateSingle
            // 
            this.dtpEndDateSingle.Location = new System.Drawing.Point(92, 149);
            this.dtpEndDateSingle.Name = "dtpEndDateSingle";
            this.dtpEndDateSingle.Size = new System.Drawing.Size(200, 22);
            this.dtpEndDateSingle.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 64;
            this.label3.Text = "Finish:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 18);
            this.label4.TabIndex = 63;
            this.label4.Text = "Select Time Period : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 17);
            this.label7.TabIndex = 69;
            this.label7.Text = "Number of items sold:";
            // 
            // lbProducts
            // 
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.ItemHeight = 16;
            this.lbProducts.Location = new System.Drawing.Point(28, 72);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(244, 340);
            this.lbProducts.TabIndex = 70;
            this.lbProducts.SelectedIndexChanged += new System.EventHandler(this.lbProducts_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(105, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 24);
            this.label8.TabIndex = 71;
            this.label8.Text = "Products";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 17);
            this.label9.TabIndex = 73;
            this.label9.Text = "ID:";
            // 
            // tbProductID
            // 
            this.tbProductID.Location = new System.Drawing.Point(67, 53);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.Size = new System.Drawing.Size(113, 22);
            this.tbProductID.TabIndex = 72;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(35, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 18);
            this.label10.TabIndex = 74;
            this.label10.Text = "Enter product\'s id: ";
            // 
            // btnViewOverallStatistics
            // 
            this.btnViewOverallStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOverallStatistics.Location = new System.Drawing.Point(120, 223);
            this.btnViewOverallStatistics.Name = "btnViewOverallStatistics";
            this.btnViewOverallStatistics.Size = new System.Drawing.Size(110, 37);
            this.btnViewOverallStatistics.TabIndex = 75;
            this.btnViewOverallStatistics.Text = "View";
            this.btnViewOverallStatistics.UseVisualStyleBackColor = true;
            this.btnViewOverallStatistics.Click += new System.EventHandler(this.btnViewOverallStatistics_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAmountSold);
            this.groupBox1.Controls.Add(this.lblProductTurnover);
            this.groupBox1.Controls.Add(this.dtpStartDateSingle);
            this.groupBox1.Controls.Add(this.btnSingleProductStatistics);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbProductID);
            this.groupBox1.Controls.Add(this.dtpEndDateSingle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(298, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 340);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Individual statistics";
            // 
            // lblAmountSold
            // 
            this.lblAmountSold.AutoSize = true;
            this.lblAmountSold.Location = new System.Drawing.Point(213, 234);
            this.lblAmountSold.Name = "lblAmountSold";
            this.lblAmountSold.Size = new System.Drawing.Size(0, 17);
            this.lblAmountSold.TabIndex = 76;
            // 
            // lblProductTurnover
            // 
            this.lblProductTurnover.AutoSize = true;
            this.lblProductTurnover.Location = new System.Drawing.Point(213, 207);
            this.lblProductTurnover.Name = "lblProductTurnover";
            this.lblProductTurnover.Size = new System.Drawing.Size(0, 17);
            this.lblProductTurnover.TabIndex = 75;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalTurnover);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.btnViewOverallStatistics);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(637, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 331);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Overall statistics";
            // 
            // lblTotalTurnover
            // 
            this.lblTotalTurnover.AutoSize = true;
            this.lblTotalTurnover.Location = new System.Drawing.Point(172, 149);
            this.lblTotalTurnover.Name = "lblTotalTurnover";
            this.lblTotalTurnover.Size = new System.Drawing.Size(0, 17);
            this.lblTotalTurnover.TabIndex = 76;
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(102, 15);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(121, 24);
            this.cmbDepartments.TabIndex = 78;
            this.cmbDepartments.SelectedIndexChanged += new System.EventHandler(this.cmbDepartments_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 79;
            this.label11.Text = "Department:";
            // 
            // ProductStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 431);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbDepartments);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbProducts);
            this.Name = "ProductStatistics";
            this.Text = "ProductStatistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductStatistics_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSingleProductStatistics;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDateSingle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDateSingle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbProducts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnViewOverallStatistics;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAmountSold;
        private System.Windows.Forms.Label lblProductTurnover;
        private System.Windows.Forms.Label lblTotalTurnover;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.Label label11;
    }
}