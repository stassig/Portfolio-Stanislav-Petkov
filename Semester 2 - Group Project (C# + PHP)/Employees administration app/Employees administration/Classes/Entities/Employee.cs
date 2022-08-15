using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class Employee : User
    {

        public string Sdate { get; private set; }
        public decimal HourlyWage { get; private set; }
        public EmployeeContractType contractType { get; private set; }
        public string LastWorkingDay { get; private set; }
        public string DepartureReason { get; private set; }
        public string Email { get; private set; }
        public string Bdate { get; private set; }
        public Role Role { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Gender Gender { get; private set; }
        public string StreetName { get; private set; }
        public int StreetNumber { get; private set; }
        public string ZipCode { get; private set; }
        public string Town { get; private set; }
        public string Country { get; private set; }
        public bool NightAvailability { get; set; }

        private int hoursPerWeek;
        public int DepartmentID { get; private set; }


        public int HoursPerWeek
        {
            get { return this.hoursPerWeek; }
            set
            { this.hoursPerWeek = value; }
        }

        private int shiftsperweek;

        public int ShiftsPerWeek
        {
            get { return this.shiftsperweek; }
            set
            { this.shiftsperweek = value; }
        }


        public Employee(string fname, string lname, string username, string eMail, string bdate, string sdate, decimal hourlyWage,
            string password, Gender gender, EmployeeContractType contractType, string streetName, int streetNumber, string zipCode,
            string town, string country, string lastWorkingDate, Role role, Department department) : base(username, password)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Gender = gender;
            this.Sdate = sdate;
            this.HourlyWage = hourlyWage;
            this.contractType = contractType;
            this.Email = eMail;
            this.Bdate = bdate;
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.ZipCode = zipCode;
            this.Town = town;
            this.Country = country;
            this.LastWorkingDay = lastWorkingDate;
            this.Role = role;
            this.DepartmentID = department.ID;
        }

        public Employee(string fname, string lname, string username, string eMail, string bdate, string sdate, decimal hourlyWage,
        string password, Gender gender, EmployeeContractType contractType, string streetName, int streetNumber, string zipCode,
        string town, string country, string lastWorkingDate, Role role, int DepartmentID) : base(username, password)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Gender = gender;
            this.Sdate = sdate;
            this.HourlyWage = hourlyWage;
            this.contractType = contractType;
            this.Email = eMail;
            this.Bdate = bdate;
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.ZipCode = zipCode;
            this.Town = town;
            this.Country = country;
            this.LastWorkingDay = lastWorkingDate;
            this.Role = role;
            this.DepartmentID = DepartmentID;
        }

        public void EditDetails(string fName, string lName, Gender g, string email, string sDate, string birthDate, decimal hourlyWage,
           EmployeeContractType contractType, string lastDate, string country, string town, string zipcode, int streetNo, string streetName, Role role, Department department)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Gender = g;
            this.Email = email;
            this.Bdate = birthDate;
            this.Sdate = sDate;
            this.Country = country;
            this.HourlyWage = hourlyWage;
            this.contractType = contractType;
            this.LastWorkingDay = lastDate;
            this.StreetName = streetName;
            this.StreetNumber = streetNo;
            this.ZipCode = zipcode;
            this.Town = town;
            this.Role = role;
            this.DepartmentID = department.ID;
        }

        public bool TerminateContract(string reason, DateTime lastDay)
        {
            DateTime date = DateTime.ParseExact(this.Sdate, "MM/dd/yyyy", null);

            if (DateTime.Compare(lastDay, date) > 0)
            {
                this.contractType = EmployeeContractType.Terminated;
                this.DepartureReason = reason;
                this.LastWorkingDay = lastDay.ToString("MM/dd/yyyy");
                return true;
            }
            return false;
        }

        public void MinusHours()
        {
            HoursPerWeek = HoursPerWeek + 8;
            ShiftsPerWeek = ShiftsPerWeek + 1;
        }


        public override string ToString()
        {
            return "ID:" + " " + this.ID + " " + "Name: " + this.FirstName + " " + this.LastName + " Contract: " + this.contractType;
        }


    }
}
