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
    public partial class lbAttendanceRateSpecificDate : Form
    {
        private ApplicationManager applicationManager;
        
        private GroupStatisticsExactDate exactDateStatistics;
        private GroupStatisticsTimePeriod timePeriodStatistics;

        private int departmentID;

        public lbAttendanceRateSpecificDate(ApplicationManager applicationManager, int departmentID)
        {
            InitializeComponent();
            this.exactDateStatistics = new GroupStatisticsExactDate(applicationManager.UserManager, applicationManager.ShiftManager);
            this.timePeriodStatistics = new GroupStatisticsTimePeriod(applicationManager.UserManager, applicationManager.ShiftManager);

            this.applicationManager = applicationManager;
            this.departmentID = departmentID;

            this.PopulateDepartmentComboBox();
        }

        private void PopulateDepartmentComboBox()
        {
            this.cmbDepartments.Items.Clear();

            if (this.departmentID == -1)
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
                Department department = this.applicationManager.DepartmentManager.Get(this.departmentID);
                this.Text = department.Name + " Manager";
                this.cmbDepartments.Items.Add(department);
            }
            this.cmbDepartments.SelectedIndex = 0;
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            if (this.departmentID == -1)
            {
                foreach (Employee employee in this.applicationManager.UserManager.GetAllEmployees())
                {
                    this.lbCurrentEmployees.Items.Add(employee);
                }
            }
            else
            {
                Department department = this.applicationManager.DepartmentManager.Get(this.departmentID);
                foreach (Employee employee in department.GetEmployeesOfDepartment())
                {
                    this.lbCurrentEmployees.Items.Add(employee);
                }
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            if (this.tbSearchName.Text != "")
            {
                try
                {
                    Employee employee = (Employee)this.applicationManager.UserManager.Get(Convert.ToInt32(this.tbSearchName.Text));

                    if (employee != null)
                    {
                        if (this.departmentID != -1)
                        {
                            if (employee.DepartmentID != this.departmentID)
                            {
                                throw new EmployeeNotInSelectedDepartment();
                            }
                        }
                        IndividualStatistics form = new IndividualStatistics(this.applicationManager, employee);
                        form.ShowDialog();
                    }
                    else { throw new EmployeeNotFoundException(); }
                }
                catch (EmployeeNotInSelectedDepartment)
                {
                    MessageBox.Show("The employee with the entered ID does not belong to your department.");
                }
                catch (EmployeeNotFoundException)
                {
                    MessageBox.Show("Employee with this ID doesn't exist.");
                }
                catch (FormatException) { MessageBox.Show("Please enter a numeric value"); }
            }
            else { MessageBox.Show("Please enter an ID"); }
        }

        private void btnTotalAmountOfSalaryPaid_Click(object sender, EventArgs e)
        {
            
            if(DateTime.Compare(this.dtpSelectDate.Value, DateTime.Now) <= 0)
            {
                string selectedDate = this.dtpSelectDate.Value.ToString("MM/dd/yyyy");
                if (this.cmbDepartments.SelectedItem.ToString() == "ALL")
                {
                    this.lblAttendanceRateExactDate.Text = this.exactDateStatistics.GetTotalSalariesHoursWorkedForExactDate(selectedDate).ToString() + " %";
                    this.lbNumberOFEmployees.Text = this.exactDateStatistics.GetTotalActiveEmployeesOnExactDate(selectedDate).ToString() + " employees";
                }
                else
                {
                    Department department = this.cmbDepartments.SelectedItem as Department;
                    this.lblAttendanceRateExactDate.Text = this.exactDateStatistics.GetTotalSalariesHoursWorkedForExactDate(selectedDate, department).ToString() + " %";
                    this.lbNumberOFEmployees.Text = this.exactDateStatistics.GetTotalActiveEmployeesOnExactDate(selectedDate, department).ToString() + " employees";
                }
                this.lbTotalAmountOfSalarypaid.Text = this.exactDateStatistics.TotalSalariesExactDate.ToString("00.00") + " €";
                this.lblTotalHoursWorkedDate.Text = this.exactDateStatistics.TotalHoursWorkedExactDate.ToString() + " hours";
            }
            else { MessageBox.Show("You can not select a date in the future."); }
            

        }

        private void GetTimePeriodStatistics()
        {
            string startDate = this.dtpStartDate.Value.ToString("MM/dd/yyyy");
            string endDate = this.dtpEndDate.Value.ToString("MM/dd/yyyy");
            int numberOfEmployees = 0;
            
            if (this.cmbDepartments.SelectedItem.ToString() != "ALL")
            {
                Department department = this.cmbDepartments.SelectedItem as Department;
                this.lblAttendanceRateTimePeriod.Text = this.timePeriodStatistics.GetTotalHoursSalariesShiftsTimePeriod(startDate, endDate, department).ToString() + " %";
                numberOfEmployees = this.timePeriodStatistics.GetEmployeesForTimePeriod(startDate, endDate, department).Count;
                this.lblAvgHourlyWagePerEmployee.Text = this.timePeriodStatistics.GetAvgEmployeeHourlyWage(startDate, endDate, department).ToString("00.00") + " €";
            }
            else
            {
                this.lblAttendanceRateTimePeriod.Text = this.timePeriodStatistics.GetTotalHoursSalariesShiftsTimePeriod(startDate, endDate).ToString() + " %";
                numberOfEmployees = this.timePeriodStatistics.GetEmployeesForTimePeriod(startDate, endDate).Count;
                this.lblAvgHourlyWagePerEmployee.Text = this.timePeriodStatistics.GetAvgEmployeeHourlyWage(startDate, endDate).ToString("00.00") + " €";
            }

            decimal totalHoursWorked = this.timePeriodStatistics.TotalHoursTimePeriod;
            decimal totalSalaries = this.timePeriodStatistics.TotalSalariesTimePeriod;
            int totalShifts = this.timePeriodStatistics.TotalShiftsTimePeriod;


            decimal avgHoursPerEmployee = 0;
            if (numberOfEmployees != 0)
            {
                avgHoursPerEmployee = totalHoursWorked / numberOfEmployees;
            }
            decimal avgNumOfEmployeesPerWorkshift = 0;
            if (totalShifts != 0)
            {
                avgNumOfEmployeesPerWorkshift = Convert.ToDecimal(numberOfEmployees) / totalShifts;
            }

            this.lblAvgEmployeesPerShift.Text = avgNumOfEmployeesPerWorkshift.ToString("00.00") + " emplpyees";
            this.lblTotalSalariesPeriod.Text = totalSalaries.ToString("00.00") + " €";
            this.lblTotalHoursPeriod.Text = totalHoursWorked.ToString() + " hours";
            this.DisplayAvgHoursPerEmployee(avgHoursPerEmployee);

        }

        private void DisplayAvgHoursPerEmployee(decimal hours)
        {
            Math.Round(hours, 2);
            var ts = TimeSpan.FromHours((double)hours);

            this.lblAvgHoursPerEmployeePeriod.Text = $"{Math.Floor(ts.TotalHours)} hours, {ts.Minutes} minutes";
        }

        private bool DateChecker()
        {
            if (DateTime.Compare(this.dtpStartDate.Value, this.dtpEndDate.Value) >= 0) { return false; }
            else { return true; }
        }

        private void ViewTimePeriodStatistics_Click(object sender, EventArgs e)
        {
            if (this.DateChecker())
            {
                if (DateTime.Compare(this.dtpEndDate.Value, DateTime.Now) <= 0)
                {
                    this.GetTimePeriodStatistics();
                }
                else { MessageBox.Show("The end date of the selected time period can not be in the future."); }
               
            }
            else { MessageBox.Show("First date and last date of the selected period are not appropriate."); }

        }

        //Opens product statistic form
        private void button1_Click(object sender, EventArgs e)
        {
            ProductStatistics newForm = new ProductStatistics(this.applicationManager, this.departmentID);
            this.Hide();
            DialogResult result = newForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
            }

        }

        private void lbCurrentEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee employee = this.lbCurrentEmployees.SelectedItem as Employee;
            this.tbSearchName.Text = employee.ID.ToString();
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbCurrentEmployees.Items.Clear();
            Department department = cmbDepartments.SelectedItem as Department;
            List<Employee> employees = new List<Employee>();

            if (cmbDepartments.SelectedItem.ToString() == "ALL")
            {
                employees = this.applicationManager.UserManager.GetAllEmployees();
            }
            else { employees = this.applicationManager.UserManager.GetEmployeesByDepartment(department); }

            if (employees.Count < 1) { MessageBox.Show("There are no registered employees in the department at the moment."); }
            else
            {
                foreach (Employee employee in employees)
                {
                    this.lbCurrentEmployees.Items.Add(employee);
                }
            }
        }

        private void lbAttendanceRateSpecificDate_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
