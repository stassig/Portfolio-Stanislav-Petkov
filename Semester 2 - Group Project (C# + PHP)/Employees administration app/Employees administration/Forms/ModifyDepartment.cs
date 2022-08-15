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
    public partial class ModifyDepartment : Form
    {
        private DepartmentManager departmentManager;
        private Department department;
        private UserManager userManager;

        public ModifyDepartment(DepartmentManager manager, Department department,UserManager user)
        {
            InitializeComponent();
            this.departmentManager = manager;
            this.department = department;
            this.userManager = user;
            this.tbEditDname.Text = department.Name;
            ListOfEmployees();
        }

        private void btnModifyD_Click(object sender, EventArgs e)
        {
            if (this.lbSelectManager.SelectedIndex > -1 )
            {
                Employee emp = this.lbSelectManager.SelectedItem as Employee;
                if (this.tbEditDname.Text != "")
                {
                    
                    this.departmentManager.Update(this.department, emp.ID, this.tbEditDname.Text);
                    this.department.AssignManager(emp.ID);
                    this.department.EditInfo(this.tbEditDname.Text);
                    DialogResult box = MessageBox.Show("Updated successfully");
                    if (box == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in the name of the department!");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all of the requirements"); 
            }
}

        private void btnEditCancelD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the process?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ListOfEmployees()
        {
            if (this.userManager.GetEmployeesByDepartment(this.department).Count != 0)
            {
                foreach (Employee employee in this.userManager.GetEmployeesByDepartment(this.department))
                {
                    this.lbSelectManager.Items.Add(employee);
                }
            }
        }

        private void btnSearchManager_Click(object sender, EventArgs e)
        {
            lbSelectManager.Items.Clear();
            if (tbsearchManager.Text != "")
            {
                Employee employee = userManager.GetEmp(Convert.ToInt32(tbsearchManager.Text));
                if (employee != null)
                {
                    lbSelectManager.Items.Add(employee);
                }
                else
                {
                    MessageBox.Show("this ID does not exist");
                }
            }
            else
            {
                MessageBox.Show("Please fill in the ID");
            }

        }
    }
}
