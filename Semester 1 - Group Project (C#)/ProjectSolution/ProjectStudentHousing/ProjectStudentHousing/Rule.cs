using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentHousing
{
    public class Rule
    {
        //Properties
        public string Description { get; private set; }
        public int RuleNumber { get; set; }

        //Constructor
        public Rule(int number, string description)
        {
            this.Description = description;
            this.RuleNumber = number;
        }

        //Methods
        public void ChangeRule(string description)
        {
            this.Description = description;
        }

        public string GetInfo()
        {
            return $"#{this.RuleNumber}: {this.Description}";
        }

    }
}
