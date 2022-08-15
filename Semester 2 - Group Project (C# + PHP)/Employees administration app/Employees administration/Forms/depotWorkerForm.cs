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
    public partial class depotWorkerForm : Form
    {
        private RequestManager requestManager;
        private ProductManager productManager;

        public depotWorkerForm(ApplicationManager applicationManager)
        {
            this.productManager = applicationManager.ProductManager;
            this.requestManager = applicationManager.RequestManager;
            InitializeComponent();
            GridViewConfiguration();

            foreach (RestockRequest request in this.requestManager.GetAll())
            {
                this.dgvRestockRequest.Rows.Add(request.ID, request.RequestedAmount, request.SentTime, request.ProductName);
            }

            this.timerTable.Start();
        }

        private void GridViewConfiguration()
        {
            this.dgvRestockRequest.ColumnCount = 4;
            this.dgvRestockRequest.Columns[0].Name = "ID";
            this.dgvRestockRequest.Columns[1].Name = "Requested Amount";
            this.dgvRestockRequest.Columns[2].Name = "Sent Time";
            this.dgvRestockRequest.Columns[3].Name = "Product Name";
            this.dgvRestockRequest.Columns[0].Width = 50;

            this.dgvRestockRequest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewColumn column in this.dgvRestockRequest.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dgvRestockRequest.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvRestockRequest.BackgroundColor = this.dgvRestockRequest.DefaultCellStyle.BackColor;
        }

        private void btnAcceptRequest_Click(object sender, EventArgs e)
        {
            if (this.dgvRestockRequest.SelectedCells.Count > 0)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure you want to confirm this request?","Confirmation", MessageBoxButtons.OKCancel);
                if(confirmation == DialogResult.OK)
                {
                    RestockRequest request = this.GetRequest();
                    int quantity = request.RequestedAmount;
                    Product product = this.productManager.Get(request.ProductId);
                    if (this.requestManager.Remove(request))
                    {
                        product.RestockProduct(quantity);
                        this.productManager.Update(product);
                        MessageBox.Show("Request accepted successfully");
                    }
                    else { MessageBox.Show("Failed"); }
                }
            }
            else
            {
                MessageBox.Show("Please select a request!");
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.dgvRestockRequest.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRestockRequest.CurrentCell.RowIndex;
                int columnIndex = dgvRestockRequest.CurrentCell.ColumnIndex;

                this.dgvRestockRequest.Rows.Clear();

                foreach (RestockRequest request in this.requestManager.GetAll())
                {
                    this.dgvRestockRequest.Rows.Add(request.ID, request.RequestedAmount, request.SentTime, request.ProductName);
                }

                
                if(this.dgvRestockRequest.Rows.Count >= rowIndex + 1)
                {
                    this.dgvRestockRequest.ClearSelection();
                    this.dgvRestockRequest.CurrentCell = this.dgvRestockRequest.Rows[rowIndex].Cells[columnIndex];
                }

            }
            else
            {
                this.dgvRestockRequest.Rows.Clear();
                foreach (RestockRequest request in this.requestManager.GetAll())
                {
                    this.dgvRestockRequest.Rows.Add(request.ID, request.RequestedAmount, request.SentTime, request.ProductName);
                }
            }
        }
        private void depotWorkerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timerTable.Stop();
        }

        private void btnRejectRequest_Click(object sender, EventArgs e)
        {
            if (this.dgvRestockRequest.SelectedCells.Count > 0)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure you want to reject this request?", "Confirmation", MessageBoxButtons.OKCancel);
                if (confirmation == DialogResult.OK)
                {
                    RestockRequest request = this.GetRequest();

                    if (this.requestManager.Remove(request))
                    {
                        MessageBox.Show("Request rejected successfully");
                    }
                    else { MessageBox.Show("Failed"); }
                }                  
            }
            else { MessageBox.Show("Please select a request!"); }
        }

        private RestockRequest GetRequest()
        {
            int r = this.dgvRestockRequest.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvRestockRequest.Rows[r];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            RestockRequest request = this.requestManager.Get(id);
            return request;
        }

        private void depotWorkerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

