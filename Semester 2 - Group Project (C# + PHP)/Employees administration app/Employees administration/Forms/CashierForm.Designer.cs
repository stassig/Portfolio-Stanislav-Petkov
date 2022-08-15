namespace Employees_administration
{
    partial class CashierForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.tbxProductPrice = new System.Windows.Forms.TextBox();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.productGridView = new System.Windows.Forms.DataGridView();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFindProduct = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LimeGreen;
            this.button1.Location = new System.Drawing.Point(584, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 56);
            this.button1.TabIndex = 19;
            this.button1.Text = "Sell";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.Location = new System.Drawing.Point(572, 278);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(231, 34);
            this.numQuantity.TabIndex = 18;
            this.numQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            this.numQuantity.Enter += new System.EventHandler(this.numQuantity_Enter);
            // 
            // tbxProductPrice
            // 
            this.tbxProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProductPrice.Location = new System.Drawing.Point(572, 231);
            this.tbxProductPrice.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProductPrice.Name = "tbxProductPrice";
            this.tbxProductPrice.ReadOnly = true;
            this.tbxProductPrice.Size = new System.Drawing.Size(231, 36);
            this.tbxProductPrice.TabIndex = 17;
            this.tbxProductPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxProductName
            // 
            this.tbxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProductName.Location = new System.Drawing.Point(572, 187);
            this.tbxProductName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.ReadOnly = true;
            this.tbxProductName.Size = new System.Drawing.Size(231, 36);
            this.tbxProductName.TabIndex = 16;
            this.tbxProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(471, 283);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(91, 25);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Quantity:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(471, 238);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 25);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Price :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(471, 194);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 25);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "Item : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.productGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 426);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Items";
            // 
            // productGridView
            // 
            this.productGridView.AllowUserToAddRows = false;
            this.productGridView.AllowUserToDeleteRows = false;
            this.productGridView.AllowUserToResizeColumns = false;
            this.productGridView.AllowUserToResizeRows = false;
            this.productGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGridView.Location = new System.Drawing.Point(16, 24);
            this.productGridView.Name = "productGridView";
            this.productGridView.RowHeadersWidth = 51;
            this.productGridView.RowTemplate.Height = 24;
            this.productGridView.Size = new System.Drawing.Size(436, 396);
            this.productGridView.TabIndex = 0;
            this.productGridView.SelectionChanged += new System.EventHandler(this.productGridView_SelectionChanged);
            this.productGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.productGridView_SortCompare);
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(572, 34);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(231, 36);
            this.tbxName.TabIndex = 21;
            this.tbxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(471, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Product: ";
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindProduct.ForeColor = System.Drawing.Color.Black;
            this.btnFindProduct.Location = new System.Drawing.Point(572, 87);
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Size = new System.Drawing.Size(169, 37);
            this.btnFindProduct.TabIndex = 22;
            this.btnFindProduct.Text = "Find";
            this.btnFindProduct.UseVisualStyleBackColor = true;
            this.btnFindProduct.Click += new System.EventHandler(this.btnFindProduct_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(153, 445);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(169, 37);
            this.btnRefresh.TabIndex = 23;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // CashierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 494);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFindProduct);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.tbxProductPrice);
            this.Controls.Add(this.tbxProductName);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CashierForm";
            this.Text = "CashierForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CashierForm_FormClosing);
            this.Load += new System.EventHandler(this.CashierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numQuantity;
        internal System.Windows.Forms.TextBox tbxProductPrice;
        internal System.Windows.Forms.TextBox tbxProductName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView productGridView;
        internal System.Windows.Forms.TextBox tbxName;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFindProduct;
        private System.Windows.Forms.Button btnRefresh;
    }
}