using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentHousing
{
    public class Complain
    {
        //Properties
        public string Relation { get; private set; }
        public string Description { get; private set; }
        public string User { get; private set; }


        //Constructors
        public Complain(string relation, string description) //-- anonymous submission
        {
            this.Relation = relation;
            this.Description = description;
            this.User = "";
        }

        public Complain(string relation, string description, string user)
        {
            this.Relation = relation;
            this.Description = description;
            this.User = user;
        }

        //Methods
        public string GetInfo()
        {
            if (this.User != "")
            {
                return $"{this.Relation}: {this.Description} - {this.User}";
            }
            else
            {
                return $"{this.Relation}: {this.Description}";
            }

        }
    }
}
