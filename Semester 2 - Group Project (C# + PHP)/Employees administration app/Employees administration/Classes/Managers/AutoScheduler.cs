using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class AutoScheduler
    {
        private EmployeeMediator employeeMediator;
        private Random random;
        private ShiftManager shiftManager;

        public AutoScheduler()
        {
            this.employeeMediator = new EmployeeMediator();
            this.random = new Random();
            this.shiftManager = new ShiftManager();
        }

        private List<string> CheckWeekDatesInThePast(List<string> weekdates)
        {
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            List<string> dates = new List<string>();
            foreach (string date in weekdates)
            {
                if(DateTime.Compare(DateTime.ParseExact(currentDate, "MM/dd/yyyy", null), DateTime.ParseExact(date, "MM/dd/yyyy", null)) <= 0)
                {
                    dates.Add(date);
                }
            }
            return dates;
        }

        public void ScheduleAutomatically(List<string> weekDates)
        {
            List<string> dates = CheckWeekDatesInThePast(weekDates);
            this.RemoveShiftsForCurrentWeek(dates[0], dates[dates.Count - 1]);



            List<DayShift> Week = new List<DayShift>();
            foreach (string date in dates)
            {
                DayShift Day = new DayShift(date);
                Week.Add(Day);
            }

            foreach (DayShift day in Week)
            {
                List<Employee> AvailableEmployees = this.employeeMediator.GetAvailableEmployees(day.DayOfTheWeek);
                //Morning               
                do
                {
                    //Take random employee
                    int index = this.random.Next(AvailableEmployees.Count);
                    Employee employee = AvailableEmployees.ElementAt(index);

                    //Checks if the employee is already assigned for a shift on this day
                    if (!day.NightEmployees.Contains(employee) && !day.AfternoonEmployees.Contains(employee) && !day.MorningEmployees.Contains(employee))
                    {
                        //Checks if the employee is already assigned to his maximum number of shifts
                        if (!this.MaximumShifts(employee, weekDates[0], weekDates[6]))
                        {
                            WorkShift AssignedShift = new WorkShift(employee.ID, employee.FirstName + " " + employee.LastName, day.Date, "MORNING", employee.HourlyWage, 8);
                            day.AddShift(AssignedShift, employee);

                            this.shiftManager.Add(AssignedShift);
                        }
                    }
                }
                while (!day.FullMorning);


                //Afternoon
                do
                {
                    int index = this.random.Next(AvailableEmployees.Count);
                    Employee employee = AvailableEmployees.ElementAt(index);

                    //Checks if the employee is already assigned for a shift on this day
                    if (!day.NightEmployees.Contains(employee) && !day.AfternoonEmployees.Contains(employee) && !day.MorningEmployees.Contains(employee))
                    {
                        //Checks if the employee is already assigned to his maximum number of shifts
                        if (!this.MaximumShifts(employee, weekDates[0], weekDates[6]))
                        {
                            WorkShift AssignedShift = new WorkShift(employee.ID, employee.FirstName + " " + employee.LastName, day.Date, "AFTERNOON", employee.HourlyWage, 8);
                            day.AddShift(AssignedShift, employee);

                            this.shiftManager.Add(AssignedShift);
                        }
                    }
                }
                while (!day.FullAfternoon);

                //Night
                do
                {
                    int index = this.random.Next(AvailableEmployees.Count);
                    Employee employee = AvailableEmployees.ElementAt(index);

                    //Checks if the employee is already assigned for a shift on this day
                    if (!day.NightEmployees.Contains(employee) && !day.AfternoonEmployees.Contains(employee) && !day.MorningEmployees.Contains(employee))
                    {
                        //Checks if the employee is already assigned to his maximum number of shifts
                        if (!this.MaximumShifts(employee, weekDates[0], weekDates[6]))
                        {
                            //Checks if employee is available for nightShifts
                            if (employee.NightAvailability)
                            {
                                WorkShift AssignedShift = new WorkShift(employee.ID, employee.FirstName + " " + employee.LastName, day.Date, "EVENING", employee.HourlyWage, 8);
                                day.AddShift(AssignedShift, employee);

                                this.shiftManager.Add(AssignedShift);
                            }
                        }

                    }
                }
                while (!day.FullNight);

            }
        }

        //Checking if the employee has available hours for the week
        private bool MaximumShifts(Employee employee, string mondayDate, string sundayDate)
        {

            DateTime monday = DateTime.ParseExact(mondayDate, "MM/dd/yyyy", null);
            DateTime sunday = DateTime.ParseExact(sundayDate, "MM/dd/yyyy", null);
            int numberOfShifts = 0;

            foreach (WorkShift shift in this.shiftManager.GetActiveShifts())
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

        //Clear all shifts for currently selected week
        private void RemoveShiftsForCurrentWeek(string mondayDate, string sundayDate)
        {
            DateTime monday = DateTime.ParseExact(mondayDate, "MM/dd/yyyy", null);
            DateTime sunday = DateTime.ParseExact(sundayDate, "MM/dd/yyyy", null);

            foreach (WorkShift shift in this.shiftManager.GetActiveShifts())
            {
                if (DateTime.Compare(monday, DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null)) <= 0 &&
                DateTime.Compare(sunday, DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null)) >= 0)
                {
                    this.shiftManager.Remove(shift);
                }
            }
        }


    }
}
