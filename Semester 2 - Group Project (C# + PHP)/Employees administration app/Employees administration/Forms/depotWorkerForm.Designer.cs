namespace Employees_administration
{
    partial class depotWorkerForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvRestockRequest = new System.Windows.Forms.DataGridView();
            this.btnRejectRequest = new System.Windows.Forms.Button();
            this.btnAcceptRequest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timerTable = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestockRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRestockRequest
            // 
            this.dgvRestockRequest.AllowUserToAddRows = false;
            this.dgvRestockRequest.AllowUserToDeleteRows = false;
            this.dgvRestockRequest.AllowUserToResizeColumns = false;
            this.dgvRestockRequest.AllowUserToResizeRows = false;
            this.dgvRestockRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestockRequest.Location = new System.Drawing.Point(12, 64);
            this.dgvRestockRequest.Name = "dgvRestockRequest";
            this.dgvRestockRequest.RowHeadersWidth = 51;
            this.dgvRestockRequest.RowTemplate.Height = 24;
            this.dgvRestockRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRestockRequest.Size = new System.Drawing.Size(601, 357);
            this.dgvRestockRequest.TabIndex = 8;
            // 
            // btnRejectRequest
            // 
            this.btnRejectRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRejectRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejectRequest.Location = new System.Drawing.Point(691, 219);
            this.btnRejectRequest.Name = "btnRejectRequest";
            this.btnRejectRequest.Size = new System.Drawing.Size(128, 44);
            this.btnRejectRequest.TabIndex = 7;
            this.btnRejectRequest.Text = "Reject";
            this.btnRejectRequest.UseVisualStyleBackColor = false;
            this.btnRejectRequest.Click += new System.EventHandler(this.btnRejectRequest_Click);
            // 
            // btnAcceptRequest
            // 
            this.btnAcceptRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAcceptRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptRequest.Location = new System.Drawing.Point(691, 143);
            this.btnAcceptRequest.Name = "btnAcceptRequest";
            this.btnAcceptRequest.Size = new System.Drawing.Size(128, 46);
            this.btnAcceptRequest.TabIndex = 6;
            this.btnAcceptRequest.Text = "Accept";
            this.btnAcceptRequest.UseVisualStyleBackColor = false;
            this.btnAcceptRequest.Click += new System.EventHandler(this.btnAcceptRequest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Restock requests";
            // 
            // timerTable
            // 
            this.timerTable.Interval = 1000;
            this.timerTable.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // depotWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.dgvRestockRequest);
            this.Controls.Add(this.btnRejectRequest);
            this.Controls.Add(this.btnAcceptRequest);
            this.Controls.Add(this.label1);
            this.Name = "depotWorkerForm";
            this.Text = "depot Worker Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.depotWorkerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestockRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRestockRequest;
        private System.Windows.Forms.Button btnRejectRequest;
        private System.Windows.Forms.Button btnAcceptRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerTable;
    }
}