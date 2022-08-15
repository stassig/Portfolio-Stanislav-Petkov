namespace Employees_administration
{
    partial class CancellingEmployee_sContract
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
            this.dtpLastWorkingDate = new System.Windows.Forms.DateTimePicker();
            this.btnDoneCancelling = new System.Windows.Forms.Button();
            this.btnCancelContractCancelling = new System.Windows.Forms.Button();
            this.rtbReason = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Working Date :\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reason";
            // 
            // dtpLastWorkingDate
            // 
            this.dtpLastWorkingDate.Location = new System.Drawing.Point(176, 64);
            this.dtpLastWorkingDate.Name = "dtpLastWorkingDate";
            this.dtpLastWorkingDate.Size = new System.Drawing.Size(200, 22);
            this.dtpLastWorkingDate.TabIndex = 3;
            // 
            // btnDoneCancelling
            // 
            this.btnDoneCancelling.Location = new System.Drawing.Point(153, 361);
            this.btnDoneCancelling.Name = "btnDoneCancelling";
            this.btnDoneCancelling.Size = new System.Drawing.Size(89, 36);
            this.btnDoneCancelling.TabIndex = 4;
            this.btnDoneCancelling.Text = "Done";
            this.btnDoneCancelling.UseVisualStyleBackColor = true;
            this.btnDoneCancelling.Click += new System.EventHandler(this.btnDoneCancelling_Click);
            // 
            // btnCancelContractCancelling
            // 
            this.btnCancelContractCancelling.Location = new System.Drawing.Point(153, 403);
            this.btnCancelContractCancelling.Name = "btnCancelContractCancelling";
            this.btnCancelContractCancelling.Size = new System.Drawing.Size(89, 32);
            this.btnCancelContractCancelling.TabIndex = 5;
            this.btnCancelContractCancelling.Text = "Cancel";
            this.btnCancelContractCancelling.UseVisualStyleBackColor = true;
            this.btnCancelContractCancelling.Click += new System.EventHandler(this.btnCancelContractCancelling_Click);
            // 
            // rtbReason
            // 
            this.rtbReason.Location = new System.Drawing.Point(34, 160);
            this.rtbReason.Name = "rtbReason";
            this.rtbReason.Size = new System.Drawing.Size(342, 178);
            this.rtbReason.TabIndex = 6;
            this.rtbReason.Text = "";
            // 
            // CancellingEmployee_sContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 450);
            this.Controls.Add(this.rtbReason);
            this.Controls.Add(this.btnCancelContractCancelling);
            this.Controls.Add(this.btnDoneCancelling);
            this.Controls.Add(this.dtpLastWorkingDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CancellingEmployee_sContract";
            this.Text = "Cancel Employee\'s Contract";
            this.Load += new System.EventHandler(this.CancellingEmployee_sContract_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpLastWorkingDate;
        private System.Windows.Forms.Button btnDoneCancelling;
        private System.Windows.Forms.Button btnCancelContractCancelling;
        private System.Windows.Forms.RichTextBox rtbReason;
    }
}