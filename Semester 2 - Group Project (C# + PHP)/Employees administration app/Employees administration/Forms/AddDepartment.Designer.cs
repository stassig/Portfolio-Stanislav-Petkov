namespace Employees_administration
{
    partial class AddDepartment
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
            this.btnAddD = new System.Windows.Forms.Button();
            this.tbDname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddD
            // 
            this.btnAddD.Location = new System.Drawing.Point(143, 124);
            this.btnAddD.Name = "btnAddD";
            this.btnAddD.Size = new System.Drawing.Size(112, 36);
            this.btnAddD.TabIndex = 0;
            this.btnAddD.Text = "Add";
            this.btnAddD.UseVisualStyleBackColor = true;
            this.btnAddD.Click += new System.EventHandler(this.btnAddD_Click);
            // 
            // tbDname
            // 
            this.tbDname.Location = new System.Drawing.Point(221, 62);
            this.tbDname.Name = "tbDname";
            this.tbDname.Size = new System.Drawing.Size(144, 22);
            this.tbDname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name of Department :";
            // 
            // btnCancelD
            // 
            this.btnCancelD.Location = new System.Drawing.Point(143, 166);
            this.btnCancelD.Name = "btnCancelD";
            this.btnCancelD.Size = new System.Drawing.Size(112, 36);
            this.btnCancelD.TabIndex = 5;
            this.btnCancelD.Text = "Cancel";
            this.btnCancelD.UseVisualStyleBackColor = true;
            this.btnCancelD.Click += new System.EventHandler(this.btnCancelD_Click);
            // 
            // AddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 231);
            this.Controls.Add(this.btnCancelD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDname);
            this.Controls.Add(this.btnAddD);
            this.Name = "AddDepartment";
            this.Text = "Add Department";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddD;
        private System.Windows.Forms.TextBox tbDname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelD;
    }
}