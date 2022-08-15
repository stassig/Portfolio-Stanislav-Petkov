namespace Employees_administration
{
    partial class ModifyDepartment
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
            this.btnEditCancelD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEditDname = new System.Windows.Forms.TextBox();
            this.btnModifyD = new System.Windows.Forms.Button();
            this.lbSelectManager = new System.Windows.Forms.ListBox();
            this.btnSearchManager = new System.Windows.Forms.Button();
            this.tbsearchManager = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEditCancelD
            // 
            this.btnEditCancelD.Location = new System.Drawing.Point(461, 507);
            this.btnEditCancelD.Name = "btnEditCancelD";
            this.btnEditCancelD.Size = new System.Drawing.Size(74, 36);
            this.btnEditCancelD.TabIndex = 11;
            this.btnEditCancelD.Text = "Cancel";
            this.btnEditCancelD.UseVisualStyleBackColor = true;
            this.btnEditCancelD.Click += new System.EventHandler(this.btnEditCancelD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name of Department :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select a manager \r\n";
            // 
            // tbEditDname
            // 
            this.tbEditDname.Location = new System.Drawing.Point(255, 40);
            this.tbEditDname.Name = "tbEditDname";
            this.tbEditDname.Size = new System.Drawing.Size(144, 22);
            this.tbEditDname.TabIndex = 8;
            // 
            // btnModifyD
            // 
            this.btnModifyD.Location = new System.Drawing.Point(65, 456);
            this.btnModifyD.Name = "btnModifyD";
            this.btnModifyD.Size = new System.Drawing.Size(112, 36);
            this.btnModifyD.TabIndex = 6;
            this.btnModifyD.Text = "Done";
            this.btnModifyD.UseVisualStyleBackColor = true;
            this.btnModifyD.Click += new System.EventHandler(this.btnModifyD_Click);
            // 
            // lbSelectManager
            // 
            this.lbSelectManager.FormattingEnabled = true;
            this.lbSelectManager.ItemHeight = 16;
            this.lbSelectManager.Location = new System.Drawing.Point(47, 129);
            this.lbSelectManager.Name = "lbSelectManager";
            this.lbSelectManager.Size = new System.Drawing.Size(442, 308);
            this.lbSelectManager.TabIndex = 12;
            // 
            // btnSearchManager
            // 
            this.btnSearchManager.Location = new System.Drawing.Point(192, 456);
            this.btnSearchManager.Name = "btnSearchManager";
            this.btnSearchManager.Size = new System.Drawing.Size(112, 36);
            this.btnSearchManager.TabIndex = 13;
            this.btnSearchManager.Text = "Search";
            this.btnSearchManager.UseVisualStyleBackColor = true;
            this.btnSearchManager.Click += new System.EventHandler(this.btnSearchManager_Click);
            // 
            // tbsearchManager
            // 
            this.tbsearchManager.Location = new System.Drawing.Point(365, 463);
            this.tbsearchManager.Name = "tbsearchManager";
            this.tbsearchManager.Size = new System.Drawing.Size(72, 22);
            this.tbsearchManager.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "ID :";
            // 
            // ModifyDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 555);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbsearchManager);
            this.Controls.Add(this.btnSearchManager);
            this.Controls.Add(this.lbSelectManager);
            this.Controls.Add(this.btnEditCancelD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEditDname);
            this.Controls.Add(this.btnModifyD);
            this.Name = "ModifyDepartment";
            this.Text = "ModifyDepartment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditCancelD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEditDname;
        private System.Windows.Forms.Button btnModifyD;
        private System.Windows.Forms.ListBox lbSelectManager;
        private System.Windows.Forms.Button btnSearchManager;
        private System.Windows.Forms.TextBox tbsearchManager;
        private System.Windows.Forms.Label label3;
    }
}