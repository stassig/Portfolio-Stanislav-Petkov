using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class IndividualEmployeeStatistics : EmployeeStatistics
    {
        private Employee employee;

        public IndividualEmployeeStatistics(UserManager userManager, ShiftManager shiftManager, Employee employee) : base(userManager, shiftManager)
        {
            this.employee = employee;
        }

        public List<WorkShift> GetPastEmployeeShifts()
        {
            List<WorkShift> workShifts = new List<WorkShift>();
            foreach (WorkShift shift in this.shiftManager.GetActiveShifts())
            {
                if (shift.empId == this.employee.ID)
                {
                    if (DateTime.Compare(DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null), DateTime.Now) < 0)
                    {
                        workShifts.Add(shift);
                    }
                }
            }
            return workShifts;

        }

        public decimal GetIndividualAttendanceRate()
        {
            List<WorkShift> workShifts = this.GetPastEmployeeShifts();

            decimal totalShifts = workShifts.Count();
            decimal attended = 0;
            foreach (WorkShift shift in workShifts)
            {
                if (this.shiftMediator.CheckAttendance(shift, this.employee.ID) == 1)
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

        public int CalculateTotalHoursWorked()
        {
            int totalHoursWorked = 0;
            foreach (WorkShift workshift in this.shiftManager.GetActiveShifts())
            {
                if (workshift.empId == this.employee.ID)
                {
                    totalHoursWorked += workshift.hoursWorked;
                }
            }
            return totalHoursWorked;

        }

        public int CalculateTotalDaysAtTheCompany()
        {
            DateTime firstWorkingDate = DateTime.ParseExact(this.employee.Sdate, "MM/dd/yyyy", null);
            DateTime lastWorkingDate = DateTime.ParseExact(this.employee.LastWorkingDay, "MM/dd/yyyy", null);
            DateTime currentDate = DateTime.Now;
            int lenght = 0;

            if (DateTime.Compare(currentDate, lastWorkingDate) > 0)
            {
                TimeSpan duration = lastWorkingDate.Subtract(firstWorkingDate);
                lenght = Convert.ToInt32(duration.TotalDays);
            }
            else
            {
                TimeSpan duration = currentDate.Subtract(firstWorkingDate);
                lenght = Convert.ToInt32(duration.TotalDays);
            }

            return lenght;
        }
    }
}
