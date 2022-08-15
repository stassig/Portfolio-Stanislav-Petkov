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
    public partial class AddDepartment : Form
    {
        private  DepartmentManager departmentManager;

        public AddDepartment(DepartmentManager departmentManager)
        {
            InitializeComponent();
            this.departmentManager = departmentManager;
        }

        private void btnAddD_Click(object sender, EventArgs e)
        {
            if ( this.tbDname.Text != "")
            {
              //  Employee employee = u.GetEmp(Convert.ToInt32(tbManagerID.Text));
                Department department = new Department(this.tbDname.Text);
                if (this.departmentManager.Add(department) == true)
                {
                    DialogResult box = MessageBox.Show("The department has been added succesfully. Now you can assign employees to this department by editing their information from the employee tab.");
                    if (box == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                  
                }
                else
                {
                    MessageBox.Show("A department with this name already exists!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill in the name of the department");
            }
        }

        private void btnCancelD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the process?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
