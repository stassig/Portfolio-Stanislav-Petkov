using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_administration
{
    public partial class CashierForm : Form
    {
        private ProductManager productManager;
        private RequestManager requestManager;
        private SaleMediator saleMediator;

        public CashierForm(ApplicationManager applicationManager)
        {
            InitializeComponent();
            this.productManager = applicationManager.ProductManager;
            this.requestManager = applicationManager.RequestManager;
            this.saleMediator = new SaleMediator();
        }

        private void CashierForm_Load(object sender, EventArgs e)
        {
            this.productGridView.ColumnCount = 3;
            this.productGridView.Columns[0].Name = "Item";
            this.productGridView.Columns[1].Name = "Price";
            this.productGridView.Columns[2].Name = "Available";

            this.productGridView.Columns[0].Width = 140;
            this.productGridView.Columns[1].Width = 65;

            this.productGridView.BackgroundColor = this.productGridView.DefaultCellStyle.BackColor;
            this.productGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.productGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.tbxProductName.BackColor = Color.White;
            this.tbxProductPrice.BackColor = Color.White;

            this.RefreshTable();
        }


        private void productGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.productGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = this.productGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.productGridView.Rows[selectedRowIndex];

                this.tbxProductName.Text = selectedRow.Cells["Item"].Value.ToString();
                this.tbxProductPrice.Text = selectedRow.Cells["Price"].Value.ToString();
                //this.numQuantity.Maximum = Convert.ToInt32(selectedRow.Cells["Available"].Value);
            }
        }




        private void SendRestockRequest(Product product)
        {
            RestockRequest request = new RestockRequest(product);
            if (!this.requestManager.CheckRequestAlreadySent(request))
            {
                this.requestManager.Add(request);
                this.LowAmountLeftNotification(product);
            }
            else
            {
                if (product.InStock != 0)
                {
                    MessageBox.Show($"Low amount left from product: {product.Name}, a restock request has already been sent.");
                }
                else if (product.InStock == 0)
                {
                    MessageBox.Show($"{product.Name} has been sold out. A restock request has already been sent.");
                }
            }
            

        }

        private void LowAmountLeftNotification(Product product)
        {
            if (product.InStock != 0)
            {
                MessageBox.Show($"Only a low amount left from product: {product.Name}. A restock request has been sent.");
            }
            else { MessageBox.Show($"{product.Name} has been sold out. A new restock request has been sent."); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Gets newest data related to products
            this.productManager.Load();

            Product product = this.productManager.Get(this.tbxProductName.Text);
            if (product != null)
            {
                int quantity = Convert.ToInt32(this.numQuantity.Value);
                if (quantity > 0)
                {
                    product.ProductOutOfStock += this.SendRestockRequest;                    

                    if (product.SellProduct(quantity))
                    {
                        decimal profit = (product.SellingPrice - product.CostPrice) * quantity;                  
                        Sale sale = new Sale(product.ID, quantity, DateTime.Now.ToString("MM/dd/yyyy"), Math.Round(profit, 2));
                        this.saleMediator.Add(sale);

                        MessageBox.Show($"Successfull sale for " + (quantity * product.SellingPrice).ToString("##.00") + " €");
                    }
                    else { MessageBox.Show("Not enough amount from selected item in stock!"); }

                    product.ProductOutOfStock -= this.SendRestockRequest;
                    
                    this.productManager.Update(product);
                    this.RefreshTable();
                }
                else { MessageBox.Show("Please, select an amount you want to sell."); }

            }
            else { MessageBox.Show("Error"); }

        }

        private void RefreshTable()
        {
            //save current row index and product name
            int rowIndex = -1;
            string name = "";

            if (this.productGridView.CurrentCell != null)
            {
                rowIndex = this.productGridView.CurrentCell.RowIndex;
                name = this.productGridView.Rows[rowIndex].Cells[0].Value.ToString();
            }

            //Refresh with newest product data
            this.productGridView.Rows.Clear();

            foreach (Product product in this.productManager.GetAll())
            {
                this.productGridView.Rows.Add(product.Name, product.SellingPrice + " €", product.InStock.ToString());
            }

            //Goes back to the same selected row index if there has been one before the refresh
            if (rowIndex != -1)
            {
                this.productGridView.FirstDisplayedScrollingRowIndex = rowIndex;
                //Checks if it's still the same product on the row, selected before the refresh
                if (this.productGridView.Rows[rowIndex].Cells[0].Value.ToString() == name)
                {
                    this.productGridView.CurrentCell = this.productGridView.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numQuantity_Enter(object sender, EventArgs e)
        {

        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            int rowIndex = -1;

            if (this.tbxName.Text != "")
            {
                foreach (DataGridViewRow row in this.productGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(this.tbxName.Text))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if (rowIndex != -1)
                {
                    this.productGridView.ClearSelection();
                    this.productGridView.CurrentCell = this.productGridView.Rows[rowIndex].Cells[0];
                }
                else { MessageBox.Show("Product with this name has not been found."); }
            }
            else { MessageBox.Show("Please enter the name of the product you want to find."); }

            this.tbxName.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshTable();
        }

        private void productGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 1)
            {
                string value1 = e.CellValue1.ToString();
                value1 = value1.Remove(value1.Length - 2, 2);

                string value2 = e.CellValue2.ToString();
                value2 = value2.Remove(value2.Length - 2, 2);

                e.SortResult = decimal.Parse(value1).CompareTo(decimal.Parse(value2));
                e.Handled = true;
            }
            else if (e.Column.Index == 2)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }

        private void CashierForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
