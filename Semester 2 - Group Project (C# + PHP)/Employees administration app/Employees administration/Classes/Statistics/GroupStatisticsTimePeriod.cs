using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class GroupStatisticsTimePeriod : EmployeeStatistics
    {
        public decimal TotalSalariesTimePeriod { get; private set; }
        public decimal TotalHoursTimePeriod { get; private set; }
        public int TotalShiftsTimePeriod { get; private set; }

        public GroupStatisticsTimePeriod(UserManager userManager, ShiftManager shiftManager) : base(userManager, shiftManager)
        {

        }

        private List<WorkShift> GetWorkShiftsInTimePeriod(string startDate, string endDate)
        {
            List<WorkShift> shifts = new List<WorkShift>();
            DateTime startDate1 = DateTime.ParseExact(startDate, "MM/dd/yyyy", null);
            DateTime endDate1 = DateTime.ParseExact(endDate, "MM/dd/yyyy", null);

            foreach (WorkShift shift in this.shiftManager.GetActiveShifts())
            {
                if (DateTime.Compare(DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null), startDate1) >= 0 &&
                    DateTime.Compare(DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null), endDate1) <= 0)
                {
                    shifts.Add(shift);
                }
            }
            return shifts;
        }

        public decimal GetTotalHoursSalariesShiftsTimePeriod(string startDate, string endDate, Department department)
        {
            this.TotalHoursTimePeriod = 0;
            this.TotalSalariesTimePeriod = 0;
            this.TotalShiftsTimePeriod = 0;
            decimal totalShifts = 0;
            decimal attended = 0;

            foreach (WorkShift ws in this.GetWorkShiftsInTimePeriod(startDate, endDate))
            {
                Employee employee = this.userManager.GetEmp(ws.empId);
                if (employee != null)
                {
                    if (department.ID == employee.DepartmentID)
                    {
                        totalShifts++;
                        if (this.shiftMediator.CheckAttendance(ws, ws.empId) == 1) { attended++; }
                        this.TotalHoursTimePeriod += ws.hoursWorked;
                        this.TotalSalariesTimePeriod += ws.wageForShift;
                        this.TotalShiftsTimePeriod++;
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

        public decimal GetTotalHoursSalariesShiftsTimePeriod(string startDate, string endDate)
        {
            this.TotalHoursTimePeriod = 0;
            this.TotalSalariesTimePeriod = 0;
            this.TotalShiftsTimePeriod = 0;
            decimal totalShifts = 0;
            decimal attended = 0;

            foreach (WorkShift ws in this.GetWorkShiftsInTimePeriod(startDate, endDate))
            {
                totalShifts++;
                if (this.shiftMediator.CheckAttendance(ws, ws.empId) == 1) { attended++; }
                this.TotalHoursTimePeriod += ws.hoursWorked;
                this.TotalSalariesTimePeriod += ws.wageForShift;
                this.TotalShiftsTimePeriod++;
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

        public List<Employee> GetEmployeesForTimePeriod(string startDate, string endDate, Department department)
        {
            List<Employee> employees = new List<Employee>();
            foreach (Employee employee in this.GetEmployeesForTimePeriod(startDate, endDate))
            {
                if (department.ID == employee.DepartmentID)
                {
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public List<Employee> GetEmployeesForTimePeriod(string startDate, string endDate)
        {
            DateTime startDate1 = DateTime.ParseExact(startDate, "MM/dd/yyyy", null);
            DateTime endDate1 = DateTime.ParseExact(endDate, "MM/dd/yyyy", null);
            List<Employee> activeEmployees = new List<Employee>();

            foreach (Employee employee in this.userManager.GetAllEmployees())
            {
                if (this.CheckEmployeeWorkPeriod(employee, startDate1, endDate1))
                {
                    activeEmployees.Add(employee);
                }
            }

            return activeEmployees;
        }

        private bool CheckEmployeeWorkPeriod(Employee employee, DateTime start, DateTime finish)
        {
            if (DateTime.Compare(DateTime.ParseExact(employee.LastWorkingDay, "MM/dd/yyyy", null), start) < 0 ||
                   DateTime.Compare(DateTime.ParseExact(employee.Sdate, "MM/dd/yyyy", null), finish) > 0) { return false; }
            else { return true; }
        }

        public decimal GetAvgEmployeeHourlyWage(string startDate, string endDate)
        {
            decimal wage = 0;
            List<Employee> employees = this.GetEmployeesForTimePeriod(startDate, endDate);

            foreach (Employee employee in employees)
            {
                wage += employee.HourlyWage;
            }
            if (employees.Count == 0)
            {
                return 0.00M;
            }
            else
            {
                wage = wage / employees.Count;
                return wage;
            }

        }

        public decimal GetAvgEmployeeHourlyWage(string startDate, string endDate, Department department)
        {
            decimal wage = 0;
            List<Employee> employees = this.GetEmployeesForTimePeriod(startDate, endDate, department);

            foreach (Employee employee in employees)
            {
                wage += employee.HourlyWage;
            }
            if (employees.Count == 0)
            {
                return 0.00M;
            }
            else
            {
                wage = wage / employees.Count;
                return wage;
            }

        }
    }
}
