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
    public partial class EditPersonalInfo : Form
    {
        private UserManager userManager;
        private Employee employee;
        private DepartmentManager departmentManager;

        public EditPersonalInfo(UserManager userManager, Employee employee, DepartmentManager departmentManager)
        {
            this.userManager = userManager;
            this.employee = employee;
            this.departmentManager = departmentManager;
            this.InitializeComponent();
            this.PopulateComboBox();
            this.tbName.Text = employee.FirstName;
            this.tbSurname.Text = employee.LastName;
            if (employee.Gender == Gender.Male) { this.cmbEditGender.SelectedIndex = 0; }
            else { this.cmbEditGender.SelectedIndex = 1; }
            this.tbEmail.Text = employee.Email;
            DateTime startDate = DateTime.ParseExact(employee.Sdate, "MM/dd/yyyy", null);
            this.dtpFirstWorkingDate.Value = startDate;
            DateTime birthtDate = DateTime.ParseExact(employee.Bdate, "MM/dd/yyyy", null);
            this.dtpBirthDate.Value = birthtDate;
            DateTime lastDate = DateTime.ParseExact(employee.LastWorkingDay, "MM/dd/yyyy", null);
            this.dtpLastWorkingDay.Value = lastDate;
            this.tbHourlyWage.Text = employee.HourlyWage.ToString();
            this.cbContract.SelectedIndex = (int)employee.contractType;
            this.tbCountry.Text = employee.Country;
            this.tbTown.Text = employee.Town;
            this.tbZipcode.Text = employee.ZipCode;
            this.tbStreetNo.Text = employee.StreetNumber.ToString();
            this.tbStreetName.Text = employee.StreetName;
            if (employee.Role == Role.DepartmentManager)
            {
                this.cmbRole.Items.Add("DepartmentManager");
            }
            this.cmbRole.SelectedIndex = (int)employee.Role;
            this.cbDepartment.SelectedIndex = departmentManager.GetDepartmentIndex(employee.DepartmentID);
        }

        private void btnEditInfo_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || tbSurname.Text == "" || tbEmail.Text == "" || tbCountry.Text == ""
                    || tbHourlyWage.Text == "" || tbStreetName.Text == "" || tbStreetNo.Text == "" || tbTown.Text == ""
                    || tbZipcode.Text == "") { throw new MissingDataException(); }

                if (!this.AgeChecker()) { throw new AgeException(); }

                Department department = this.departmentManager.Get(this.cbDepartment.Text);
                if (department.ID != employee.DepartmentID)
                {
                    if (!this.departmentManager.CheckAlreadyManager(this.employee.ID))
                    {
                        throw new AlreadyManagerException();
                    }
                }

                if (DateTime.Compare(dtpLastWorkingDay.Value, dtpFirstWorkingDate.Value) > 0 && DateTime.Compare(dtpLastWorkingDay.Value, DateTime.Now) >= 0)
                {
                    this.employee.EditDetails(tbName.Text, tbSurname.Text, (Gender)cmbEditGender.SelectedIndex, tbEmail.Text,
                    dtpFirstWorkingDate.Value.ToString("MM/dd/yyyy"), dtpBirthDate.Value.ToString("MM/dd/yyyy"),
                    Convert.ToDecimal(tbHourlyWage.Text), (EmployeeContractType)cbContract.SelectedIndex,
                     dtpLastWorkingDay.Value.ToString("MM/dd/yyyy"), tbCountry.Text, tbTown.Text, tbZipcode.Text,
                     Convert.ToInt32(tbStreetNo.Text), tbStreetName.Text, (Role)cmbRole.SelectedIndex, department);

                    this.userManager.Update(this.employee);

                    DialogResult box = MessageBox.Show("Data has been edited successfully.");
                    if (box == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else { throw new IncorrectDateEntry(); }
            }
            catch (AlreadyManagerException)
            {
                MessageBox.Show("Can not assigned this employee to another department, because he is the manager of his current department.");
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
            catch (IncorrectDateEntry) { MessageBox.Show("Last working day can not be earlier than the first one and should be later than the current date."); }
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

        private void btnCancelEPI_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the process?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void PopulateComboBox()
        {
            this.cbDepartment.Items.Clear();
            foreach (Department department in this.departmentManager.GetAll())
            {
                this.cbDepartment.Items.Add(department);
            }
        }
    }
}
