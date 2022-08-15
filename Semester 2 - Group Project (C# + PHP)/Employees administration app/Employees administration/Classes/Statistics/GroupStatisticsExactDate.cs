using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class GroupStatisticsExactDate : EmployeeStatistics
    {
        public decimal TotalSalariesExactDate { get; private set; }
        public decimal TotalHoursWorkedExactDate { get; private set; }
        public int TotalEmployeesExactDate { get; private set; }

        public GroupStatisticsExactDate(UserManager userManager, ShiftManager shiftManager) : base(userManager, shiftManager)
        {

        }

        private List<WorkShift> GetShiftsOnExactDate(string selectedDate)
        {
            DateTime selectDate = DateTime.ParseExact(selectedDate, "MM/dd/yyyy", null);
            List<WorkShift> shifts = new List<WorkShift>();
            foreach (WorkShift shift in this.shiftManager.GetActiveShifts())
            {
                if (DateTime.Compare(DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null), selectDate) == 0)
                {
                    shifts.Add(shift);
                }
            }
            return shifts;
        }

        public decimal GetTotalSalariesHoursWorkedForExactDate(string selectedDate, Department department)
        {
            this.TotalSalariesExactDate = 0;
            this.TotalHoursWorkedExactDate = 0;
            decimal totalShifts = 0;
            decimal attended = 0;
            List<WorkShift> shifts = this.GetShiftsOnExactDate(selectedDate);

            foreach (WorkShift shift in shifts)
            {
                Employee employee = this.userManager.GetEmp(shift.empId);
                if (employee != null)
                {
                    if (employee.DepartmentID == department.ID)
                    {
                        totalShifts++;
                        this.TotalSalariesExactDate += shift.wageForShift;
                        this.TotalHoursWorkedExactDate += shift.hoursWorked;
                        if (this.shiftMediator.CheckAttendance(shift, shift.empId) == 1)
                        {
                            attended++;
                        }
                    }
                }
            }
            if (totalShifts == 0 || attended == 0)
            {
                return 0.00M;
            }
            else
            {
                decimal rate = attended / totalShifts * 100;
                return Math.Round(rate, 2);
            }

        }

        public decimal GetTotalSalariesHoursWorkedForExactDate(string selectedDate)
        {
            this.TotalSalariesExactDate = 0;
            this.TotalHoursWorkedExactDate = 0;
            decimal totalShifts = 0;
            decimal attended = 0;

            foreach (WorkShift ws in this.GetShiftsOnExactDate(selectedDate))
            {
                totalShifts++;
                this.TotalSalariesExactDate += ws.wageForShift;
                this.TotalHoursWorkedExactDate += ws.hoursWorked;
                if (this.shiftMediator.CheckAttendance(ws, ws.empId) == 1)
                {
                    attended++;
                }
            }
            if (totalShifts == 0 || attended == 0)
            {
                return 0.00M;
            }
            else
            {
                decimal rate = attended / totalShifts * 100;
                return Math.Round(rate, 2);
            }
        }

        private List<Employee> GetActiveEmployeesOnExactDate(string selectedDate)
        {
            DateTime selectDate = DateTime.ParseExact(selectedDate, "MM/dd/yyyy", null);
            List<Employee> employees = new List<Employee>();

            foreach (Employee employee in this.userManager.GetAllEmployees())
            {
                if (DateTime.Compare(DateTime.ParseExact(employee.Sdate, "MM/dd/yyyy", null), selectDate) <= 0 &&
                    DateTime.Compare(DateTime.ParseExact(employee.LastWorkingDay, "MM/dd/yyyy", null), selectDate) >= 0)
                {
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public int GetTotalActiveEmployeesOnExactDate(string selectedDate, Department department)
        {
            this.TotalEmployeesExactDate = 0;

            foreach (Employee employee in this.GetActiveEmployeesOnExactDate(selectedDate))
            {
                if (department.ID == employee.DepartmentID)
                {
                    this.TotalEmployeesExactDate++;
                }
            }
            return this.TotalEmployeesExactDate;
        }

        public int GetTotalActiveEmployeesOnExactDate(string selectedDate)
        {
            return this.GetActiveEmployeesOnExactDate(selectedDate).Count();
        }
    }
}
