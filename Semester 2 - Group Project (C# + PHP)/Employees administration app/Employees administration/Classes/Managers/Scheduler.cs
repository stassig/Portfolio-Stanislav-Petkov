using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class Scheduler
    {

        public List<WorkShift> AllShifts { get { return this.shiftManager.GetActiveShifts(); } }

        private ShiftManager shiftManager;
        private UserManager userManager;
        private EmployeeMediator employeeMediator;

        public Scheduler()
        {
            this.shiftManager = new ShiftManager();
            this.userManager = new UserManager();
            this.employeeMediator = new EmployeeMediator();
        }

        public int CheckNumberOfAssignedEmployees(string date, string type)
        {
            int assignedEmployees = 0;
            foreach (WorkShift shift in this.AllShifts)
            {
                if (shift.Date == date && shift.Type == type)
                {
                    assignedEmployees++;
                }
            }
            return assignedEmployees;
        }

        public List<WorkShift> GetAssignedEmployeesToShift(string date, string type)
        {
            List<WorkShift> shifts = new List<WorkShift>();
            foreach (WorkShift shift in this.AllShifts)
            {
                if (shift.Date == date && shift.Type == type)
                {
                    shifts.Add(shift);
                }
            }
            return shifts;

        }

        public List<Employee> GetAvailableEmployees(string weekDay, string date, string monday, string sunday, bool nightShift)
        {
            List<Employee> employees = this.employeeMediator.GetAvailableEmployees(weekDay);
            List<Employee> availableEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (!this.MaximumShifts(employee, monday, sunday))
                {
                    if (nightShift)
                    {
                        if (employee.NightAvailability)
                        {
                            if(this.CheckEmployeesShiftsForToday(employee.ID, date))
                            {
                                availableEmployees.Add(employee);
                            }
                        }
                    }
                    else
                    {
                        if (this.CheckEmployeesShiftsForToday(employee.ID, date))
                        {
                            availableEmployees.Add(employee);
                        }
                    }
                }
            }
            
            List<Employee> fixedTermEmployees = new List<Employee>();
            foreach (Employee employee in availableEmployees)
            {
                if(employee.contractType != EmployeeContractType.ZeroHours)
                {
                    fixedTermEmployees.Add(employee);
                }
            }

            if (nightShift)
            {
                if(fixedTermEmployees.Count >= 1)
                {
                    return fixedTermEmployees;
                }
                else { return availableEmployees; }
            }
            else
            {
                if (fixedTermEmployees.Count >= 2)
                {
                    return fixedTermEmployees;
                }
                else { return availableEmployees; }
            }          
        }

        private bool CheckEmployeesShiftsForToday(int employeeID, string date)
        {
            List<WorkShift> shiftsToday = this.shiftManager.GetShiftsForSpecificDate(date);
            if (shiftsToday.Count > 0)
            {
                foreach (WorkShift shift in shiftsToday)
                {
                    if (shift.empId == employeeID)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private bool MaximumShifts(Employee employee, string monday1, string sunday1)
        {
            DateTime monday = DateTime.ParseExact(monday1, "MM/dd/yyyy", null);
            DateTime sunday = DateTime.ParseExact(sunday1, "MM/dd/yyyy", null);
            int numberOfShifts = 0;

            foreach (WorkShift shift in this.AllShifts)
            {
                if (shift.empId == employee.ID)
                {
                    if (DateTime.Compare(monday, DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null)) <= 0 &&
                    DateTime.Compare(sunday, DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null)) >= 0)
                    {
                        numberOfShifts++;
                    }
                }
            }
            if (employee.contractType == EmployeeContractType.FullTime || employee.contractType == EmployeeContractType.ZeroHours)
            {
                if (numberOfShifts >= 5) { return true; }
            }
            else if (EmployeeContractType.PartTime == employee.contractType)
            {
                if (numberOfShifts >= 4) { return true; }
            }
            return false;
        }




    }
}
