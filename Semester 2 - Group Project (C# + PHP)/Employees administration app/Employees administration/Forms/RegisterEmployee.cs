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
    public partial class RegisterEmployee : Form
    {
        private UserManager userManager;
        private DepartmentManager departmentManager;
        public RegisterEmployee(UserManager userManager, DepartmentManager departmentManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.departmentManager = departmentManager;
            this.cbContract.SelectedIndex = 0;
            this.cmbGender.SelectedIndex = 0;
            this.cmbRole.SelectedIndex = 0;
            PopilateComboBox();

        }

        private bool AgeChecker()
        {
            DateTime currentDate = DateTime.Now;
            DateTime birthDate = this.dtpBirthDate.Value;

            TimeSpan duration = currentDate.Subtract(birthDate);
            DateTime age = DateTime.MinValue + duration;

            int years = age.Year - 1;

            if (years >= 16) { return true; }
            else { return false; }

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || tbSurname.Text == "" || tbUsername.Text == "" || tbEmail.Text == "" || tbPassword.Text == ""
                    || tbCountry.Text == "" || tbHourlyWage.Text == "" || tbStreetName.Text == "" || tbStreetNo.Text == "" || tbTown.Text == ""
                    || tbZipcode.Text == "" || cbDepartment.Text == "") { throw new MissingDataException(); }

                if (!this.AgeChecker()) { throw new AgeException(); }

                DateTime lastDate = dtpLastWorkingDay.Value;
                if (!this.cbLastDay.Checked)
                {
                    DateTime now = DateTime.Now;
                    lastDate = new DateTime(now.Year + 100, now.Month, now.Day);
                    
                }
                if (DateTime.Compare(lastDate, dtpFirstWorkingDate.Value) > 0)
                {
                    DataEncryptor dataEncryptor = new DataEncryptor();
                    string password = dataEncryptor.Encrypt(tbPassword.Text);
                    string lastDate1 = lastDate.ToString("MM/dd/yyyy");

                    Department department = cbDepartment.SelectedItem as Department;
               //     string filtered = cbDepartment.SelectedItem.ToString().Substring(0, cbDepartment.SelectedItem.ToString().IndexOf(" "));
               //     Department d = departmentManager.Get(Convert.ToInt32(filtered));

                    Employee employee = new Employee(tbName.Text, tbSurname.Text, tbUsername.Text, tbEmail.Text, dtpBirthDate.Value.ToString("MM/dd/yyyy"),
                        dtpFirstWorkingDate.Value.ToString("MM/dd/yyyy"), Convert.ToDecimal(tbHourlyWage.Text), password, (Gender)cmbGender.SelectedIndex,
                        (EmployeeContractType)cbContract.SelectedIndex, tbStreetName.Text, Convert.ToInt32(tbStreetNo.Text),
                        tbZipcode.Text, tbTown.Text, tbCountry.Text, lastDate1, (Role)cmbRole.SelectedIndex,department.ID);

                    this.userManager.Add(employee);
                    this.departmentManager.AssignEmpToDep(userManager, employee, department);
                    DialogResult box = MessageBox.Show("Employee has been added successfully.");
                    if (box == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    throw new IncorrectDateEntry();
                }

            }
            catch (MissingDataException)
            {
                MessageBox.Show("Please fill in all of the fields.");
            }
            catch (FormatException)
            {
                MessageBox.Show("There was entered data in a wrong format.");
            }
            catch (AgeException)
            {
                MessageBox.Show("Employee should be 16 years or older.");
            }
            catch (IncorrectDateEntry) { MessageBox.Show("Last working day can not be earlier than the first one."); }

        }

        private void btnCancelRE_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the process?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cbLastDay_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpLastWorkingDay.Enabled = !this.dtpLastWorkingDay.Enabled;
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
