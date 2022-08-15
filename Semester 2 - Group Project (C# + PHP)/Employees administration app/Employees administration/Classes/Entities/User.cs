using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public abstract class User
    {

        public string Username { get; private set; }
        public string Password { get; private set; }
        public int ID { get; set; }

        public User(string usernam, string pass)
        {
            this.Username = usernam;
            this.Password = pass;
        }

        public bool CheckDetails(string username, string password)
        {
            if (this.Password == password && this.Username == username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
