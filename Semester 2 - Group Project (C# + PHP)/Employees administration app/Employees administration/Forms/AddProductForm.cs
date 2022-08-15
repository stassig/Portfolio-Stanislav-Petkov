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
    public partial class AddProductForm : Form
    {
        private ProductManager productManager;
        private ApplicationManager applicationManager;
        private DepartmentManager departmentManager;

        public AddProductForm(ProductManager productManager, ApplicationManager applicationManager, DepartmentManager departmentManager)
        {
            InitializeComponent();
            this.productManager = productManager;
            this.applicationManager = applicationManager;
            this.departmentManager = departmentManager;
            PopilateComboBox();

        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }

        private void SendRestockRequest(Product product)
        {
            RestockRequest request = new RestockRequest(product);
            this.applicationManager.RequestManager.Add(request);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (tbThreshold.Text == "" || tbMaxCapacity.Text == "" || tbPname.Text == "" ||
                tbPstock.Text == "" || tbPbought.Text == "" || tbPselling.Text == "" ||
                tbPsize.Text == "" || cbDepartment.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill in all of the required fields!");
            }
            else
            {
                try
                {
                    string name = tbPname.Text;
                    int stock = Convert.ToInt32(this.tbPstock.Text);
                    decimal costPrice = Convert.ToDecimal(this.tbPbought.Text);
                    decimal sellingPrice = Convert.ToDecimal(this.tbPselling.Text);
                    decimal size = Convert.ToDecimal(this.tbPsize.Text);
                    int maxCapacity = Convert.ToInt32(this.tbMaxCapacity.Text);
                    int threshold = Convert.ToInt32(this.tbThreshold.Text);
                    Department department = cbDepartment.SelectedItem as Department;
                    if (threshold > maxCapacity || stock > maxCapacity)
                    {
                        throw new CapacityException();
                    }
                    Product product = new Product(name, stock, 0, costPrice, sellingPrice, size, maxCapacity, threshold, department);
                    this.productManager.Add(product);
                    this.departmentManager.AssignProductsToDep(productManager,product, department);
                  

                    DialogResult box = MessageBox.Show("Product has been added successfully.");
                    product.ProductOutOfStock += SendRestockRequest;
                    if (product.CheckQuantity())
                    {
                        MessageBox.Show("Instock quantity is lower than than threshold value of the product, so an automatic restock request has been sent.");
                    }
                    if (box == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    product.ProductOutOfStock -= SendRestockRequest;
                }
                catch (CapacityException)
                {
                    MessageBox.Show("Threshold or instock value can not be bigger than the maximum capacity of the product.");
                }
                catch (FormatException) { MessageBox.Show("Please enter all of the information in the right format."); }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the process?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void PopilateComboBox()
        {
            foreach (Department d in departmentManager.GetAll())
            {
                cbDepartment.Items.Add(d);
            }
        }
    }
}
