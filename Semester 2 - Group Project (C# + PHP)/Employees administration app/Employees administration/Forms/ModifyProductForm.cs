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
    public partial class ModifyProductForm : Form
    {
        private ProductManager productManager;
        private Product product;
        private ApplicationManager applicationManager;
        private DepartmentManager departmentManager;

        public ModifyProductForm(ProductManager productManager, Product product, ApplicationManager applicationManager, DepartmentManager departmentManager)
        {
            InitializeComponent();
            this.productManager = productManager;
            this.product = product;
            this.FillProductData(this.product);
            this.applicationManager = applicationManager;
            this.departmentManager = departmentManager;
            PopilateComboBox();
            this.cbDepartment.SelectedIndex = this.applicationManager.DepartmentManager.GetDepartmentIndex(product.DepartmentID);
        }

        private void ModifyProductForm_Load(object sender, EventArgs e)
        {


        }

        private void FillProductData(Product product)
        {
            this.tbPname.Text = product.Name;
            this.tbMaxCapacity.Text = product.MaxCapacity.ToString();
            this.tbPbought.Text = product.CostPrice.ToString();
            this.tbPselling.Text = product.SellingPrice.ToString();
            this.tbPsize.Text = product.Size.ToString();
            this.tbThreshold.Text = product.Threshold.ToString();
        }

        private void SendRestockRequest(Product product)
        {
            RestockRequest request = new RestockRequest(product);
            this.applicationManager.RequestManager.Add(request);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (tbPname.Text != "" && tbPbought.Text != "" && tbPselling.Text != "" &&
                  tbPsize.Text != "" && tbMaxCapacity.Text != "" && tbThreshold.Text != "" && cbDepartment.SelectedIndex > -1)
            {
                try
                {
                    int maxCapacity = Convert.ToInt32(tbMaxCapacity.Text);
                    int threshold = Convert.ToInt32(tbThreshold.Text);
                   Department department = cbDepartment.SelectedItem as Department;
                    if (threshold > maxCapacity)
                    {
                        throw new CapacityException();
                    }

                    this.product.EditProduct(tbPname.Text, Convert.ToDecimal(tbPbought.Text),
                      Convert.ToDecimal(tbPselling.Text), Convert.ToDecimal(tbPsize.Text),
                      threshold, maxCapacity, department.ID);

                    this.productManager.Update(this.product);

                    DialogResult box = MessageBox.Show("Data has been edited successfully.");
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
            else { MessageBox.Show("Please fill in all of the required fields."); }
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
            cbDepartment.Items.Clear();
            foreach (Department d in departmentManager.GetAll())
            {
                cbDepartment.Items.Add(d);
            }
        }

    }
}
