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
    public partial class ProductStatistics : Form
    {
        private ApplicationManager applicationManager;
        private ProductStatisticsC statistics;
        private ProductManager productManager;
        private int departmentId;

        public ProductStatistics(ApplicationManager applicationManager, int departmentId)
        {
            InitializeComponent();
            this.statistics = new ProductStatisticsC();

            this.applicationManager = applicationManager;
            this.productManager = applicationManager.ProductManager;
            this.departmentId = departmentId;

            this.PopulateDepartmentComboBox();
            this.LoadProducts();
        }

        private void PopulateDepartmentComboBox()
        {
            cmbDepartments.Items.Clear();

            if (this.departmentId == -1)
            {
                this.Text = "General Manager";

                this.cmbDepartments.Items.Add("ALL");
                foreach (Department department in this.applicationManager.DepartmentManager.GetAll())
                {
                    this.cmbDepartments.Items.Add(department);
                }
            }
            else
            {
                Department department = this.applicationManager.DepartmentManager.Get(this.departmentId);
                this.Text = department.Name + " Manager";
                this.cmbDepartments.Items.Add(department);
            }
            cmbDepartments.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            this.lbProducts.Items.Clear();

            List<Product> products = new List<Product>();
            if (this.cmbDepartments.SelectedItem.ToString() == "ALL")
            {
                products = this.productManager.GetAll();
            }
            else
            {
                Department department = this.cmbDepartments.SelectedItem as Department;
                products = this.productManager.GetProductsOfSpecificDepartment(department);
            }

            foreach (Product product in products)
            {
                this.lbProducts.Items.Add(product);
            }
        }

        private bool DateChecker(DateTime startDate, DateTime endDate)
        {
            if (DateTime.Compare(startDate, endDate) > 0) { return false; }
            else { return true; }
        }

        private void ViewTimePeriodStatistics_Click(object sender, EventArgs e)
        {
            if (DateChecker(this.dtpStartDateSingle.Value, this.dtpEndDateSingle.Value))
            {
                if (DateTime.Compare(this.dtpEndDateSingle.Value, DateTime.Now) <= 0)
                {
                    if (this.tbProductID.Text != "")
                    {
                        try
                        {
                            int id = Convert.ToInt32(tbProductID.Text);
                            Product product = this.productManager.Get(id);
                            if (product != null)
                            {
                                if (this.departmentId != -1)
                                {
                                    if (product.DepartmentID != this.departmentId)
                                    {
                                        throw new EmployeeNotInSelectedDepartment();
                                    }
                                }
                                string startDate = this.dtpStartDateSingle.Value.ToString("MM/dd/yyyy");
                                string endDate = this.dtpEndDateSingle.Value.ToString("MM/dd/yyyy");

                                this.statistics.GetSingleTurnoverAmountSoldTimePeriod(startDate, endDate, id);
                                this.lblAmountSold.Text = this.statistics.SoldAmount.ToString() + " items";
                                this.lblProductTurnover.Text = this.statistics.SingleTurnover.ToString() + " €";
                            }
                            else { throw new EmployeeNotFoundException(); }
                        }
                        catch (EmployeeNotInSelectedDepartment)
                        {
                            MessageBox.Show("The product with this ID is not your department.");
                        }
                        catch (EmployeeNotFoundException)
                        {
                            MessageBox.Show("Employee with this ID doesn't exist.");
                        }
                        catch (FormatException) { MessageBox.Show("Please enter a numeric value"); }
                    }
                    else { MessageBox.Show("Please enter an ID"); }
                }
                else { MessageBox.Show("The end date of the selected time period can not be in the future."); }                
            }
            else { MessageBox.Show("First date and last date of the selected period are not appropriate."); }

        }

        private void ProductStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product product = this.lbProducts.SelectedItem as Product;
            this.tbProductID.Text = product.ID.ToString();
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadProducts();
        }

        private void btnViewOverallStatistics_Click(object sender, EventArgs e)
        {
            if (DateChecker(this.dtpStartDate.Value, this.dtpEndDate.Value))
            {
                if (DateTime.Compare(this.dtpEndDate.Value, DateTime.Now) <= 0)
                {
                    string startDate = this.dtpStartDate.Value.ToString("MM/dd/yyyy");
                    string endDate = this.dtpEndDate.Value.ToString("MM/dd/yyyy");
                    decimal turnover = 0;
                    if (this.cmbDepartments.SelectedItem.ToString() == "ALL")
                    {
                        turnover = this.statistics.GetOverallTurnoverTimePeriod(startDate, endDate);
                    }
                    else
                    {
                        Department department = this.cmbDepartments.SelectedItem as Department;
                        turnover = this.statistics.GetOverallTurnoverTimePeriod(startDate, endDate, department);
                    }
                    this.lblTotalTurnover.Text = turnover.ToString() + " €";
                }
                else { MessageBox.Show("The end date of the selected time period can not be in the future."); }
            }
            else { MessageBox.Show("First date and last date of the selected period are not appropriate."); }
        }
    }
}
