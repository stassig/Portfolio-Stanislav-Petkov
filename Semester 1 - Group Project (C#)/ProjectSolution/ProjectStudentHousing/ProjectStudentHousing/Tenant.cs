using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentHousing
{

    public class Tenant
    {
        //Properties
        public string Name { get; private set; }
        public string Password { get; private set; }       

        //Constructor
        public Tenant(string name, string password)
        {
            this.Name = name;
            this.Password = password;          
        }

        //Methods
        public string GetInfo()
        {
            return $"Username: {this.Name} Password: {this.Password}";
        }
    }
}
