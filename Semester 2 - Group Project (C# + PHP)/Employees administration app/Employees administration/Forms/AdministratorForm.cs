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
    public partial class AdministrationForm : Form
    {
        private ApplicationManager applicationManager;
        private ProductManager productManager;
        private ShiftManager shiftManager;
        private UserManager userManager;
        private DepartmentManager departmentManager;

        private int Days;
        private DayOfWeek Day;        
        private DateTime Monday;
        private DateTime Tuesday;
        private DateTime Wednesday;
        private DateTime Thursday;
        private DateTime Friday;
        private DateTime Saturday;
        private DateTime Sunday;

        public AdministrationForm(ApplicationManager applicationManager)
        {
            InitializeComponent();
            this.applicationManager = applicationManager;
            this.productManager = this.applicationManager.ProductManager;
            this.shiftManager = this.applicationManager.ShiftManager;
            this.userManager = this.applicationManager.UserManager;
            this.departmentManager = this.applicationManager.DepartmentManager;

            showdepartments();
            PopulateComboBox();
            this.cmbSelectDepartment.SelectedIndex = 0;
            this.cbDepartments.SelectedIndex = 0;

        }

        private void AdministratorForm_Load(object sender, EventArgs e)
        {

            this.UpdateCancelledShiftsList();

            this.Day = DateTime.Now.DayOfWeek;
            this.Days = Day - DayOfWeek.Monday;

            this.Monday = DateTime.Now.AddDays(-Days);
            this.Tuesday = Monday.AddDays(1);
            this.Wednesday = Monday.AddDays(2);
            this.Thursday = Monday.AddDays(3);
            this.Friday = Monday.AddDays(4);
            this.Saturday = Monday.AddDays(5);
            this.Sunday = Monday.AddDays(6);

            this.lblMonday.Text = Monday.ToString("MM/dd/yyyy");
            this.lblTuesday.Text = Tuesday.ToString("MM/dd/yyyy");
            this.lblWednesday.Text = Wednesday.ToString("MM/dd/yyyy");
            this.lblThursday.Text = Thursday.ToString("MM/dd/yyyy");
            this.lblFriday.Text = Friday.ToString("MM/dd/yyyy");
            this.lblSaturday.Text = Saturday.ToString("MM/dd/yyyy");
            this.lblSunday.Text = Sunday.ToString("MM/dd/yyyy");

            this.productGridView.BackgroundColor = this.productGridView.DefaultCellStyle.BackColor;

            CheckEachShift();
        }

        //Employee CRUD
        private void btnEditEmployeeData_Click(object sender, EventArgs e)
        {
            if (this.lbInfo.SelectedIndex > -1)
            {
                Employee employee = this.lbInfo.SelectedItem as Employee;
                int compare = DateTime.Compare(DateTime.ParseExact(employee.LastWorkingDay, "MM/dd/yyyy", null), DateTime.Now);
                if (employee.contractType != EmployeeContractType.Terminated)
                {
                    if (compare > 0)
                    {
                        EditPersonalInfo edit = new EditPersonalInfo(this.userManager, employee, this.applicationManager.DepartmentManager);
                        DialogResult result = edit.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            this.ShowEmployees();
                        }
                    }
                    else { MessageBox.Show("The selected employee is no longer working at the company."); }

                }
                else { MessageBox.Show("The selected employee's contract has already been terminated."); }

            }
            else { MessageBox.Show("Please, select an employee."); }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            RegisterEmployee r = new RegisterEmployee(this.userManager, this.applicationManager.DepartmentManager);
            DialogResult result = r.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ShowEmployees();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.lbInfo.Items.Clear();
                if (tbEmployeeId.Text != "")
                {
                    if (this.userManager.Get(Convert.ToInt32(tbEmployeeId.Text)) != null)
                    {
                        Employee employee = (Employee)this.userManager.Get(Convert.ToInt32(tbEmployeeId.Text));
                        this.lbInfo.Items.Add(employee);
                    }
                    else
                    {
                        MessageBox.Show("Employee with this ID does not exist");
                    }
                }
                else { MessageBox.Show("Please enter an ID."); }
            }
            catch (FormatException) { MessageBox.Show("Please enter a numeric value."); }

        }

        private void ShowEmployees()
        {
            this.lbInfo.Items.Clear();
            Department department = this.cmbSelectDepartment.SelectedItem as Department;
            List<Employee> employees = new List<Employee>();
            if (this.cbActiveEmplooyees.Checked)
            {
                if (this.cmbSelectDepartment.SelectedItem.ToString() == "ALL")
                {
                    employees = this.userManager.GetActiveEmployees();
                }
                else { employees = this.userManager.GetActiveEmployees(department); }

                if (employees.Count < 1) { MessageBox.Show("There are no active employees at the department at the moment."); }
                else
                {
                    foreach (Employee employee in employees)
                    {
                        this.lbInfo.Items.Add(employee);
                    }
                }
            }
            else
            {
                if (this.cmbSelectDepartment.SelectedItem.ToString() == "ALL")
                {
                    employees = this.userManager.GetAllEmployees();
                }
                else { employees = this.userManager.GetEmployeesByDepartment(department); }

                if (employees.Count < 1) { MessageBox.Show("There are no registered employees in the department at the moment."); }
                else
                {
                    foreach (Employee employee in employees)
                    {
                        this.lbInfo.Items.Add(employee);
                    }
                }
            }

        }

        private void btnCancelContract_Click(object sender, EventArgs e)
        {
            if (this.lbInfo.SelectedIndex > -1)
            {
                Employee employee = this.lbInfo.SelectedItem as Employee;
                if (employee.contractType != EmployeeContractType.Terminated)
                {
                    if (employee.Role != Role.DepartmentManager)
                    {
                        CancellingEmployee_sContract newForm = new CancellingEmployee_sContract(employee, this.applicationManager);
                        DialogResult result = newForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            this.UpdateCancelledShiftsList();
                            this.ShowEmployees();
                        }
                    }
                    else { MessageBox.Show("The selected employee is currently a department manager, please assign another manager to his department before cancelling his contract."); }                   
                }
                else { MessageBox.Show("The selected employee's contract has already been terminated."); }
            }
            else { MessageBox.Show("Please, select an employee."); }
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (this.lbInfo.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove this employee?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Employee employee = this.lbInfo.SelectedItem as Employee;
                    if (employee.Role != Role.DepartmentManager)
                    {
                        if (!this.shiftManager.RemoveEmployeesCurrentShifts(employee))
                        {
                            MessageBox.Show("Fail shifts.");
                        };
                        if (!this.userManager.Remove(employee))
                        {
                            MessageBox.Show("Fail removing user.");
                        }
                        this.UpdateCancelledShiftsList();
                        this.ShowEmployees();
                        MessageBox.Show("Employee has been removed successfully.");
                    }
                    else { MessageBox.Show("The selected employee is currently a department manager, please assign another manager to his department before removing him."); }
                }                   
            }
            else { MessageBox.Show("Please, select an employee."); }
        }

        //Cancelled Shifts
        private void UpdateCancelledShiftsList()
        {
            this.lbCanceledShifts.Items.Clear();
            List<WorkShift> cancelledShifts = this.shiftManager.GetCancelledShifts();
            if (cancelledShifts.Count < 1) { this.lbCanceledShifts.Items.Add("There aren't any cancelled shifts at the momement"); }
            else
            {
                foreach (WorkShift shift in cancelledShifts)
                {
                    this.lbCanceledShifts.Items.Add("ID: " + shift.ID + "  " + shift.EmpName + "  " + shift.Date + "  " + shift.Type);
                }
            }

        }

        private void btnClearCanceledShiftNotification_Click(object sender, EventArgs e)
        {
            if (this.lbCanceledShifts.SelectedIndex > -1)
            {
                this.shiftManager.Load();
                string[] shift = this.lbCanceledShifts.SelectedItem.ToString().Split(' ');
                WorkShift workshift = this.shiftManager.Get(Convert.ToInt32(shift[1]));

                if (this.shiftManager.Remove(workshift))
                {
                    this.UpdateCancelledShiftsList();
                    MessageBox.Show("Shift was removed successfully.");
                }
                else { MessageBox.Show("Fail"); }
            }
            else { MessageBox.Show("Please select a shift."); }
        }

        //Scheduling
        private bool CheckIfDateInThePast(string date)
        {
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            if (DateTime.Compare(DateTime.ParseExact(date, "MM/dd/yyyy", null), DateTime.ParseExact(currentDate, "MM/dd/yyyy", null)) < 0)
            {
                MessageBox.Show("You can not schedule employees for a date in the past.");
                return false;
            }
            return true;
        }

        private void CheckEachShift()
        {
            Scheduler scheduler = this.applicationManager.Scheduler;

            //Monday
            if (scheduler.CheckNumberOfAssignedEmployees(this.lblMonday.Text, "MORNING") >= 2)
            {
                this.btnMondayM.BackColor = Color.Green;
            }
            else { this.btnMondayM.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblMonday.Text, "AFTERNOON") >= 2)
            {
                this.btnMondayA.BackColor = Color.Green;
            }
            else { this.btnMondayA.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblMonday.Text, "EVENING") >= 1)
            {
                this.btnMondayE.BackColor = Color.Green;
            }
            else { this.btnMondayE.BackColor = Color.Red; }

            //Tuesday
            if (scheduler.CheckNumberOfAssignedEmployees(this.lblTuesday.Text, "MORNING") >= 2)
            {
                this.btnTuesdayM.BackColor = Color.Green;
            }
            else { this.btnTuesdayM.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblTuesday.Text, "AFTERNOON") >= 2)
            {
                this.btnTuesdayA.BackColor = Color.Green;
            }
            else { this.btnTuesdayA.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblTuesday.Text, "EVENING") >= 1)
            {
                this.btnTuesdayE.BackColor = Color.Green;
            }
            else { this.btnTuesdayE.BackColor = Color.Red; }

            //Wednesday
            if (scheduler.CheckNumberOfAssignedEmployees(this.lblWednesday.Text, "MORNING") >= 2)
            {
                this.btnWednesdayM.BackColor = Color.Green;
            }
            else { this.btnWednesdayM.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblWednesday.Text, "AFTERNOON") >= 2)
            {
                this.btnWednesdayA.BackColor = Color.Green;
            }
            else { this.btnWednesdayA.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblWednesday.Text, "EVENING") >= 1)
            {
                this.btnWednesdayE.BackColor = Color.Green;
            }
            else { this.btnWednesdayE.BackColor = Color.Red; }

            //Thursday
            if (scheduler.CheckNumberOfAssignedEmployees(this.lblThursday.Text, "MORNING") >= 2)
            {
                this.btnThursdayM.BackColor = Color.Green;
            }
            else { this.btnThursdayM.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblThursday.Text, "AFTERNOON") >= 2)
            {
                this.btnThursdayA.BackColor = Color.Green;
            }
            else { this.btnThursdayA.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblThursday.Text, "EVENING") >= 1)
            {
                this.btnThursdayE.BackColor = Color.Green;
            }
            else { this.btnThursdayE.BackColor = Color.Red; }

            //Friday
            if (scheduler.CheckNumberOfAssignedEmployees(this.lblFriday.Text, "MORNING") >= 2)
            {
                this.btnFridayM.BackColor = Color.Green;
            }
            else { this.btnFridayM.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblFriday.Text, "AFTERNOON") >= 2)
            {
                this.btnFridayA.BackColor = Color.Green;
            }
            else { this.btnFridayA.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblFriday.Text, "EVENING") >= 1)
            {
                this.btnFridayE.BackColor = Color.Green;
            }
            else { this.btnFridayE.BackColor = Color.Red; }

            //Saturday
            if (scheduler.CheckNumberOfAssignedEmployees(this.lblSaturday.Text, "MORNING") >= 2)
            {
                this.btnSaturdayM.BackColor = Color.Green;
            }
            else { this.btnSaturdayM.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblSaturday.Text, "AFTERNOON") >= 2)
            {
                this.btnSaturdayA.BackColor = Color.Green;
            }
            else { this.btnSaturdayA.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblSaturday.Text, "EVENING") >= 1)
            {
                this.btnSaturdayE.BackColor = Color.Green;
            }
            else { this.btnSaturdayE.BackColor = Color.Red; }

            //Sunday
            if (scheduler.CheckNumberOfAssignedEmployees(this.lblSunday.Text, "MORNING") >= 2)
            {
                this.btnSundayM.BackColor = Color.Green;
            }
            else { this.btnSundayM.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblSunday.Text, "AFTERNOON") >= 2)
            {
                this.btnSundayA.BackColor = Color.Green;
            }
            else { this.btnSundayA.BackColor = Color.Red; }

            if (scheduler.CheckNumberOfAssignedEmployees(this.lblSunday.Text, "EVENING") >= 1)
            {
                this.btnSundayE.BackColor = Color.Green;
            }
            else { this.btnSundayE.BackColor = Color.Red; }

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.Monday = this.Monday.AddDays(7);
            this.Tuesday = this.Tuesday.AddDays(7);
            this.Wednesday = this.Wednesday.AddDays(7);
            this.Thursday = this.Thursday.AddDays(7);
            this.Friday = this.Friday.AddDays(7);
            this.Saturday = this.Saturday.AddDays(7);
            this.Sunday = this.Sunday.AddDays(7);

            this.lblMonday.Text = this.Monday.ToString("MM/dd/yyyy");
            this.lblTuesday.Text = this.Tuesday.ToString("MM/dd/yyyy");
            this.lblWednesday.Text = this.Wednesday.ToString("MM/dd/yyyy");
            this.lblThursday.Text = this.Thursday.ToString("MM/dd/yyyy");
            this.lblFriday.Text = this.Friday.ToString("MM/dd/yyyy");
            this.lblSaturday.Text = this.Saturday.ToString("MM/dd/yyyy");
            this.lblSunday.Text = this.Sunday.ToString("MM/dd/yyyy");

            this.CheckEachShift();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            this.Monday = this.Monday.AddDays(-7);
            this.Tuesday = this.Tuesday.AddDays(-7);
            this.Wednesday = this.Wednesday.AddDays(-7);
            this.Thursday = this.Thursday.AddDays(-7);
            this.Friday = this.Friday.AddDays(-7);
            this.Saturday = this.Saturday.AddDays(-7);
            this.Sunday = this.Sunday.AddDays(-7);

            this.lblMonday.Text = this.Monday.ToString("MM/dd/yyyy");
            this.lblTuesday.Text = this.Tuesday.ToString("MM/dd/yyyy");
            this.lblWednesday.Text = this.Wednesday.ToString("MM/dd/yyyy");
            this.lblThursday.Text = this.Thursday.ToString("MM/dd/yyyy");
            this.lblFriday.Text = this.Friday.ToString("MM/dd/yyyy");
            this.lblSaturday.Text = this.Saturday.ToString("MM/dd/yyyy");
            this.lblSunday.Text = this.Sunday.ToString("MM/dd/yyyy");

            this.CheckEachShift();
        }

        private void btnMondayM_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblMonday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblMonday.Text, "MORNING", "M", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblMonday.Text, "MORNING") >= 2)
                    {
                        this.btnMondayM.BackColor = Color.Green;
                    }
                    else { this.btnMondayM.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnMondayA_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblMonday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblMonday.Text, "AFTERNOON", "M", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblMonday.Text, "AFTERNOON") >= 2)
                    {
                        this.btnMondayA.BackColor = Color.Green;
                    }
                    else { this.btnMondayA.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnMondayE_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblMonday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblMonday.Text, "EVENING", "E", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblMonday.Text, "EVENING") >= 1)
                    {
                        this.btnMondayE.BackColor = Color.Green;
                    }
                    else { this.btnMondayE.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnTuesdayM_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblTuesday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblTuesday.Text, "MORNING", "T", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblTuesday.Text, "MORNING") >= 2)
                    {
                        this.btnTuesdayM.BackColor = Color.Green;
                    }
                    else { this.btnTuesdayM.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnTuesdayA_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblTuesday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblTuesday.Text, "AFTERNOON", "T", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblTuesday.Text, "AFTERNOON") >= 2)
                    {
                        this.btnTuesdayA.BackColor = Color.Green;
                    }
                    else { this.btnTuesdayA.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnTuesdayE_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblTuesday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblTuesday.Text, "EVENING", "T", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblTuesday.Text, "EVENING") >= 1)
                    {
                        this.btnTuesdayE.BackColor = Color.Green;
                    }
                    else { this.btnTuesdayE.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnWednesdayM_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblWednesday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblWednesday.Text, "MORNING", "W", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblWednesday.Text, "MORNING") >= 2)
                    {
                        this.btnWednesdayM.BackColor = Color.Green;
                    }
                    else { this.btnWednesdayM.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnWednesdayA_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblWednesday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblWednesday.Text, "AFTERNOON", "W", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblWednesday.Text, "AFTERNOON") >= 2)
                    {
                        this.btnWednesdayA.BackColor = Color.Green;
                    }
                    else { this.btnWednesdayA.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnWednesdayE_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblWednesday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblWednesday.Text, "EVENING", "W", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblWednesday.Text, "EVENING") >= 1)
                    {
                        this.btnWednesdayE.BackColor = Color.Green;
                    }
                    else { this.btnWednesdayE.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnThursdayM_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblThursday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblThursday.Text, "MORNING", "Th", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblThursday.Text, "MORNING") >= 2)
                    {
                        this.btnThursdayM.BackColor = Color.Green;
                    }
                    else { this.btnThursdayM.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnThursdayA_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblThursday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblThursday.Text, "AFTERNOON", "Th", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblThursday.Text, "AFTERNOON") >= 2)
                    {
                        this.btnThursdayA.BackColor = Color.Green;
                    }
                    else { this.btnThursdayA.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnThursdayE_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblThursday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblThursday.Text, "EVENING", "Th", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblThursday.Text, "EVENING") >= 1)
                    {
                        this.btnThursdayE.BackColor = Color.Green;
                    }
                    else { this.btnThursdayE.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnFridayM_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblFriday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblFriday.Text, "MORNING", "F", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblFriday.Text, "MORNING") >= 2)
                    {
                        this.btnFridayM.BackColor = Color.Green;
                    }
                    else { this.btnFridayM.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnFridayA_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblFriday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblFriday.Text, "AFTERNOON", "F", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblFriday.Text, "AFTERNOON") >= 2)
                    {
                        this.btnFridayA.BackColor = Color.Green;
                    }
                    else { this.btnFridayA.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnFridayE_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblFriday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblFriday.Text, "EVENING", "F", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblFriday.Text, "EVENING") >= 1)
                    {
                        this.btnFridayE.BackColor = Color.Green;
                    }
                    else { this.btnFridayE.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnSaturdayM_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblSaturday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblSaturday.Text, "MORNING", "S", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblSaturday.Text, "MORNING") >= 2)
                    {
                        this.btnSaturdayM.BackColor = Color.Green;
                    }
                    else { this.btnSaturdayM.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnSaturdayA_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblSaturday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblSaturday.Text, "AFTERNOON", "S", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblSaturday.Text, "AFTERNOON") >= 2)
                    {
                        this.btnSaturdayA.BackColor = Color.Green;
                    }
                    else { this.btnSaturdayA.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnSaturdayE_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblSaturday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblSaturday.Text, "EVENING", "S", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblSaturday.Text, "EVENING") >= 1)
                    {
                        this.btnSaturdayE.BackColor = Color.Green;
                    }
                    else { this.btnSaturdayE.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnSundayM_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblSunday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblSunday.Text, "MORNING", "U", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblSunday.Text, "MORNING") >= 2)
                    {
                        this.btnSundayM.BackColor = Color.Green;
                    }
                    else { this.btnSundayM.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnSundayA_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblSunday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblSunday.Text, "AFTERNOON", "U", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblSunday.Text, "AFTERNOON") >= 2)
                    {
                        this.btnSundayA.BackColor = Color.Green;
                    }
                    else { this.btnSundayA.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        private void btnSundayE_Click(object sender, EventArgs e)
        {
            if (this.CheckIfDateInThePast(this.lblSunday.Text))
            {
                ScheduleEmployeeForm scheduleForm = new ScheduleEmployeeForm(this.applicationManager, this.lblSunday.Text, "EVENING", "U", this.lblMonday.Text, this.lblSunday.Text);
                DialogResult result = scheduleForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.applicationManager.Scheduler.CheckNumberOfAssignedEmployees(this.lblSunday.Text, "EVENING") >= 1)
                    {
                        this.btnSundayE.BackColor = Color.Green;
                    }
                    else { this.btnSundayE.BackColor = Color.Red; }

                    this.UpdateCancelledShiftsList();
                }
            }
        }

        //Product CRUD
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm form = new AddProductForm(this.productManager, this.applicationManager, this.departmentManager);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.LoadAllProductsInDatagrid();
            }
        }

        private void LoadAllProductsInDatagrid()
        {
            this.productGridView.Rows.Clear();
            List<Product> products = new List<Product>();
            if (this.cbDepartments.SelectedItem.ToString() == "ALL")
            {
                products = this.productManager.GetAll();
            }
            else
            {
                Department department = cbDepartments.SelectedItem as Department;
                products = this.productManager.GetProductsOfSpecificDepartment(department);
            }

            foreach (Product product in products)
            {
                this.productGridView.Rows.Add(product.ID, product.Name, product.InStock,
               product.CostPrice + " €", product.SellingPrice + " €", product.Sold,
               product.Size + " cm³", product.Threshold, product.MaxCapacity);

            }

            foreach (DataGridViewRow row in this.productGridView.Rows)
            {
                if (Convert.ToInt32(row.Cells["Stock"].Value) < Convert.ToInt32(row.Cells["threshold"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void BtnPmodify_Click(object sender, EventArgs e)
        {

            if (this.productGridView.SelectedCells.Count > 0)
            {
                Product product = this.GetProduct();

                ModifyProductForm form = new ModifyProductForm(this.productManager, product, this.applicationManager, this.departmentManager);
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.LoadAllProductsInDatagrid();
                }
            }
        }

        private Product GetProduct()
        {
            int selectedRowIndex = this.productGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.productGridView.Rows[selectedRowIndex];
            Product product = this.productManager.Get(Convert.ToInt32(selectedRow.Cells["ID"].Value));
            return product;
        }

        private void BtnPdelete_Click(object sender, EventArgs e)
        {
            if (this.productGridView.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Product product = this.GetProduct();
                    this.productManager.Remove(product);

                    this.LoadAllProductsInDatagrid();
                    MessageBox.Show("Product has been removed successfully.");
                }                
            }
            else { MessageBox.Show("Please select a product from the table."); }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
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
            this.LoadAllProductsInDatagrid();

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

        private void btnSendRestockRequest_Click(object sender, EventArgs e)
        {
            if (this.productGridView.SelectedCells.Count > 0)
            {
                Product product = this.GetProduct();
                if (product.InStock < product.MaxCapacity)
                {
                    RestockRequest restockRequest = new RestockRequest(product);
                    if (!this.applicationManager.RequestManager.CheckRequestAlreadySent(restockRequest))
                    {
                        this.applicationManager.RequestManager.Add(new RestockRequest(product));
                        MessageBox.Show("A restock request has been successfully sent.");
                    }
                    else { MessageBox.Show("A restock request for this product has already been sent."); }
                }
                else { MessageBox.Show("Can not send a restock request when the product is at full capacity."); }
            }
            else { MessageBox.Show("Please select a product from the table."); }
        }

        private void productGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            if (e.Column.Index == 3 || e.Column.Index == 4)
            {
                string value1 = e.CellValue1.ToString();
                value1 = value1.Remove(value1.Length - 2, 2);

                string value2 = e.CellValue2.ToString();
                value2 = value2.Remove(value2.Length - 2, 2);

                e.SortResult = decimal.Parse(value1).CompareTo(decimal.Parse(value2));
                e.Handled = true;
            }
            else if (e.Column.Index == 0 || e.Column.Index == 2 || e.Column.Index == 5 ||
                e.Column.Index == 7 || e.Column.Index == 8)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
            else if (e.Column.Index == 6)
            {
                string value1 = e.CellValue1.ToString();
                value1 = value1.Remove(value1.Length - 4, 4);

                string value2 = e.CellValue2.ToString();
                value2 = value2.Remove(value2.Length - 4, 4);

                e.SortResult = decimal.Parse(value1).CompareTo(decimal.Parse(value2));
                e.Handled = true;
            }
        }

        //Different views
        private void cbActiveEmplooyees_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowEmployees();
        }

        private void cmbSelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowEmployees();
        }

        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAllProductsInDatagrid();
        }

        //Department CRUD
        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            AddDepartment add = new AddDepartment(this.departmentManager);
            DialogResult result = add.ShowDialog();
            if (result == DialogResult.OK)
            {
                int departmentEmployeeIndex = this.cmbSelectDepartment.SelectedIndex;
                int departmentProductIndex = this.cbDepartments.SelectedIndex;
                this.showdepartments();
                this.PopulateComboBox();
                this.cmbSelectDepartment.SelectedIndex = departmentEmployeeIndex;
                this.cbDepartments.SelectedIndex = departmentProductIndex;
            }
        }

        private void showdepartments()
        {
            this.dvgDepartments.Rows.Clear();
            this.dvgDepartments.ColumnCount = 4;
            this.dvgDepartments.Columns[0].Name = "ID";
            this.dvgDepartments.Columns[1].Name = "Department Name";
            this.dvgDepartments.Columns[2].Name = "Manager ID";
            this.dvgDepartments.Columns[3].Name = "Manager Name";
            this.dvgDepartments.Columns[0].Width = 100;
            this.dvgDepartments.Columns[1].Width = 250;
            this.dvgDepartments.Columns[2].Width = 100;

            foreach (Department d in this.departmentManager.GetAll())
            {
                if (d.ManagerID == -1 && d.ManagerName == null)
                {
                    this.dvgDepartments.Rows.Add(d.ID, d.Name, " ", " ");
                }
                else
                {
                    this.dvgDepartments.Rows.Add(d.ID, d.Name, d.ManagerID, d.ManagerName);
                }

            }
            foreach (DataGridViewColumn c in dvgDepartments.Columns)
            {
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dvgDepartments.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dvgDepartments.BackgroundColor = this.dvgDepartments.DefaultCellStyle.BackColor;
        }

        private void btnRemoveDeprt_Click(object sender, EventArgs e)
        {
            if (this.dvgDepartments.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove this department?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int r = this.dvgDepartments.SelectedCells[0].RowIndex;
                    DataGridViewRow row = this.dvgDepartments.Rows[r];
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    Department depart = this.departmentManager.Get(id);
                    this.departmentManager.Remove(depart);
                    MessageBox.Show("Removed successfully!");
                    this.showdepartments();
                    this.PopulateComboBox();
                    this.cbDepartments.SelectedIndex = 0;
                    this.cmbSelectDepartment.SelectedIndex = 0;
                    this.LoadAllProductsInDatagrid();
                    this.ShowEmployees();
                }                   
            }
            else
            {
                MessageBox.Show("Please select a department");
            }
        }

        private void btnSearchDepart_Click(object sender, EventArgs e)
        {
            this.dvgDepartments.Rows.Clear();
            if (this.tbDepartmentID.Text != "")
            {
                Department d = this.departmentManager.Get(Convert.ToInt32(tbDepartmentID.Text));
                if (d != null)
                {
                    if (d.ManagerID != -1)
                    {
                        this.dvgDepartments.Rows.Add(d.ID, d.Name, d.ManagerID, d.ManagerName);
                    }
                    else
                    {
                        this.dvgDepartments.Rows.Add(d.ID, d.Name, " ", " ");
                    }
                }
                else
                {
                    MessageBox.Show("A department with this ID does not exist.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in the ID of department");
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.showdepartments();
        }

        private void btnEditDeprt_Click(object sender, EventArgs e)
        {
            if (this.dvgDepartments.SelectedCells.Count > 0)
            {
                int rowIndex = this.dvgDepartments.CurrentCell.RowIndex;
                int columnIndex = this.dvgDepartments.CurrentCell.ColumnIndex;

                int r = this.dvgDepartments.SelectedCells[0].RowIndex;
                DataGridViewRow row = this.dvgDepartments.Rows[r];
                int id = Convert.ToInt32(row.Cells["ID"].Value);
                Department depart = this.departmentManager.Get(id);
                if (this.userManager.GetEmployeesByDepartment(depart).Count != 0)
                {
                    ModifyDepartment modify = new ModifyDepartment(this.departmentManager, depart, this.userManager);
                    DialogResult result = modify.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int departmentEmployeeIndex = this.cmbSelectDepartment.SelectedIndex;
                        int departmentProductIndex = this.cbDepartments.SelectedIndex;
                        this.showdepartments();
                        this.PopulateComboBox();
                        this.cmbSelectDepartment.SelectedIndex = departmentEmployeeIndex;
                        this.cbDepartments.SelectedIndex = departmentProductIndex;
                        this.ShowEmployees();
                        this.LoadAllProductsInDatagrid();
                    }
                }
                else
                {
                    MessageBox.Show("No employees in this department at the moment! First you need to assign at least one employee to this department in order to modify its information.");
                }

                if (this.dvgDepartments.Rows.Count >= rowIndex + 1)
                {
                    this.dvgDepartments.ClearSelection();
                    this.dvgDepartments.CurrentCell = this.dvgDepartments.Rows[rowIndex].Cells[columnIndex];
                }
            }

        }

        private void PopulateComboBox()
        {
            this.cbDepartments.Items.Clear();
            this.cmbSelectDepartment.Items.Clear();
            this.cmbSelectDepartment.Items.Add("ALL");
            this.cbDepartments.Items.Add("ALL");

            foreach (Department d in this.departmentManager.GetAll())
            {
                this.cmbSelectDepartment.Items.Add(d);
            }
            foreach (Department department in this.departmentManager.GetAll())
            {
                this.cbDepartments.Items.Add(department);
            }
        }

        //View Schedule
        private void btnSeeSchedule_Click_1(object sender, EventArgs e)
        {
            ViewSchedule view = new ViewSchedule(this.shiftManager);
            view.ShowDialog();
        }

        //Automatic Scheduling
        private void btnAutoScheduler_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to automatically generate a schedule for the selected week?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.AutoSchedulerAlgorithm();
            }
        }

        private void AutoSchedulerAlgorithm()
        {
            List<string> weekDates = this.GetWeekDates();
            if (this.CheckIfDateInThePast(weekDates[6]))
            {
                AutoScheduler autoScheduler = new AutoScheduler();
                autoScheduler.ScheduleAutomatically(weekDates);
                this.CheckEachShift();
                MessageBox.Show("All of the shifts for this week have been scheduled successfully.");
            }
        }

        private List<string> GetWeekDates()
        {
            List<string> weekDates = new List<string>();
            weekDates.Add(this.lblMonday.Text);
            weekDates.Add(this.lblTuesday.Text);
            weekDates.Add(this.lblWednesday.Text);
            weekDates.Add(this.lblThursday.Text);
            weekDates.Add(this.lblFriday.Text);
            weekDates.Add(this.lblSaturday.Text);
            weekDates.Add(this.lblSunday.Text);

            return weekDates;
        }

        //Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void AdministrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
