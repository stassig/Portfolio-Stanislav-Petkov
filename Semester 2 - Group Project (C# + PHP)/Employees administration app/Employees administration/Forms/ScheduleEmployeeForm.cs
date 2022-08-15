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
    public partial class ScheduleEmployeeForm : Form
    {
        private ApplicationManager applicationManager;

        private string date;
        private string type;
        private string dayOfTheWeek;
        private string startOfTheWeek;
        private string endOfTheWeek;

        public ScheduleEmployeeForm(ApplicationManager applicationManager, string date, string shiftType, string day, string monday, string sunday)
        {
            InitializeComponent();
            this.date = date;
            this.type = shiftType;
            this.dayOfTheWeek = day;
            this.startOfTheWeek = monday;
            this.endOfTheWeek = sunday;
            this.applicationManager = applicationManager;

            this.DisplayInfo();
            this.DisplayAvailableEmployees();
            this.DisplayAssignedEmployees();
        }

        private void DisplayInfo()
        {
            this.lblScheduleDate.Text = this.date + " " + this.type;

            if (this.type == "EVENING")
            {
                this.lblRequiredEmployees.Text = 1.ToString();
            }
            else { this.lblRequiredEmployees.Text = 2.ToString(); }
        }

        private void DisplayAvailableEmployees()
        {
            this.lbAvailablemployees.Items.Clear();

            bool nightShift = false;
            if (this.type == "EVENING") { nightShift = !nightShift; }

            List<Employee> availableEmployees = this.applicationManager.Scheduler.GetAvailableEmployees(this.dayOfTheWeek, this.date, this.startOfTheWeek, this.endOfTheWeek, nightShift);

            foreach (Employee employee in availableEmployees)
            {
                this.lbAvailablemployees.Items.Add("ID: " + employee.ID + " - " + employee.FirstName + " " + employee.LastName);
            }
        }

        private void DisplayAssignedEmployees()
        {
            this.lbAssignedEmployees.Items.Clear();

            List<WorkShift> assignedShifts = this.applicationManager.Scheduler.GetAssignedEmployeesToShift(this.date, this.type);

            foreach (WorkShift shift in assignedShifts)
            {
                this.lbAssignedEmployees.Items.Add(shift);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            int index = this.lbAvailablemployees.SelectedIndex;

            if (index > -1)
            {
                string[] employeeInfo = this.lbAvailablemployees.SelectedItem.ToString().Split(' ');
                Employee employee = this.applicationManager.UserManager.GetEmp(Convert.ToInt32(employeeInfo[1]));
                WorkShift shift = new WorkShift(employee.ID, employee.FirstName + " " + employee.LastName, this.date, this.type, employee.HourlyWage, 8);

                this.applicationManager.ShiftManager.Add(shift);

                this.lbAvailablemployees.Items.RemoveAt(index);
                this.lbAssignedEmployees.Items.Add(shift);

                MessageBox.Show("Employee has been assigned successfully!");
            }
            else { MessageBox.Show("Please select an employee first."); }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit this window?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = this.lbAssignedEmployees.SelectedIndex;
            if (index > -1)
            {
                WorkShift shift = this.lbAssignedEmployees.SelectedItem as WorkShift;
                this.applicationManager.ShiftManager.CancelShift(shift);

                this.lbAssignedEmployees.Items.RemoveAt(index);
                this.lbAvailablemployees.Items.Add(this.applicationManager.UserManager.GetEmp(shift.empId));

                MessageBox.Show("The shift has been successfully canceled for the selected employee.");
            }
            else { MessageBox.Show("Please select an employee to be removed from the schedule."); }

        }

        private void ScheduleEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit this window?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else { this.DialogResult = DialogResult.OK; }
            }
        }
    }
}
