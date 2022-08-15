using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class DayShift
    {
        public string Date { get; set; }
        public string DayOfTheWeek { get; private set; }
        public bool FullMorning { get; set; }
        public bool FullAfternoon { get; set; }
        public bool FullNight { get; set; }

        public List<WorkShift> MorningShifts { get; set; }
        public List<WorkShift> AfternoonShifts { get; set; }
        public List<WorkShift> NightShifts { get; set; }
        public List<Employee> MorningEmployees { get; set; }
        public List<Employee> AfternoonEmployees { get; set; }
        public List<Employee> NightEmployees { get; set; }        
        

        public DayShift(string Date)
        {
            this.Date = Date;
            this.FullMorning = false;
            this.FullAfternoon = false;
            this.FullNight = false;

            this.MorningShifts = new List<WorkShift>();
            this.AfternoonShifts = new List<WorkShift>();
            this.NightShifts = new List<WorkShift>();
            this.MorningEmployees = new List<Employee>();
            this.AfternoonEmployees = new List<Employee>();
            this.NightEmployees = new List<Employee>();
            
            this.GetWeekDay(this.Date);
        }

        public void GetWeekDay(string date)
        {
            DateTime day = DateTime.ParseExact(date, "MM/dd/yyyy", null);
            string weekDay = day.DayOfWeek.ToString();
            if(weekDay == "Monday")
            {
                this.DayOfTheWeek = "M";
            }
            else if (weekDay == "Tuesday")
            {
                this.DayOfTheWeek = "T";
            }
            else if (weekDay == "Wednesday")
            {
                this.DayOfTheWeek = "W";
            }
            else if (weekDay == "Thursday")
            {
                this.DayOfTheWeek = "Th";
            }
            else if (weekDay == "Friday")
            {
                this.DayOfTheWeek = "F";
            }
            else if (weekDay == "Saturday")
            {
                this.DayOfTheWeek = "S";
            }
            else if (weekDay == "Sunday")
            {
                this.DayOfTheWeek = "U";
            }
        }       
      
        public void AddShift( WorkShift shift, Employee employee)
        {
            //Morning
            if (shift.Type == "MORNING")
            {
                if (this.MorningShifts.Count < 2)
                {
                    this.MorningShifts.Add(shift);
                    this.MorningEmployees.Add(employee);
                    if (this.MorningShifts.Count == 2) { this.FullMorning = true; }
                }
                else { this.FullMorning = true; }              
            }
            //Afternoon
            else if (shift.Type == "AFTERNOON")
            {
                if (this.AfternoonShifts.Count < 2)
                {
                    this.AfternoonShifts.Add(shift);
                    this.AfternoonEmployees.Add(employee);
                    if (this.AfternoonShifts.Count == 2) { this.FullAfternoon = true; }
                }
                else { this.FullAfternoon = true; }
            }
            //Night
            else 
            {
                if (this.NightShifts.Count == 0)
                {
                    this.NightShifts.Add(shift);
                    this.AfternoonEmployees.Add(employee);
                    if (this.NightShifts.Count == 1) { this.FullNight = true; }
                }
                else { this.FullNight = true; }
            }
                     
        }
    }
}
