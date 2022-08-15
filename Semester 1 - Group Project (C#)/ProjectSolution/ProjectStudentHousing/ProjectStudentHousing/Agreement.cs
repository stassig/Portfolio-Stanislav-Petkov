using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentHousing
{
    public class Agreement
    {
        //Properties
        public string Description { get; set; }
        public int AgreementNumber { get; set; }

        //Constructor
        public Agreement(int number, string description)
        {
            this.Description = description;
            this.AgreementNumber = number;
        }

        //Methods
        public string GetInfo()
        {
            return $"#{this.AgreementNumber}: {this.Description}";
        }
    }
}
