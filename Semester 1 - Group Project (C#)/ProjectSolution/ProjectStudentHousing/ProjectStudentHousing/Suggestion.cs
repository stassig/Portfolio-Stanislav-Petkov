using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentHousing
{
    public class Suggestion
    {
        //Properties
        public string Description { get; private set; }
        public string Reason { get; private set; }

        //Constructor
        public Suggestion(string suggestion, string reason)
        {
            this.Description = suggestion;
            this.Reason = reason;
        }

        //Methods
        public string GetInfo()
        {
            return $"{this.Description} - {this.Reason}";
        }
    }
}
