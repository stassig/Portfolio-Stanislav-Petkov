using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentHousing
{
    public class Event
    {
        //Properties
        public string Name { private set; get; }
        public string StartDate { private set; get; }
        public string EndDate { private set; get; }
        public int EventNumber { private set; get; }
        public string StartHour { private set; get; }
        public string EndHour { private set; get; }
        public int Participants { private set; get; }

        //Constructor
        
        public Event(string name, string startDate , string endDate, int number, string startHour="00:00", string endHour="00:00", int participants=0)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.EventNumber = number;
            this.StartHour = startHour;
            this.EndHour = endHour;
            this.Participants = participants;
        }

        //Methods
        public string GetInfo()
        {
            if(this.Participants == 0)
            {
                return $"{this.Name} on {this.StartDate} until {this.EndDate} starting at {this.StartHour} finishing at {this.EndHour} with an unspecified number of people";
            }
            else
            {
                return $"{this.Name} on {this.StartDate} until {this.EndDate} starting at {this.StartHour} finishing at {this.EndHour} with a number of {this.Participants} people";
            }
           
        }
    }
}
