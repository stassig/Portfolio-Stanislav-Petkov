using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class WorkShift
    {
        public int empId { get; private set; }
        public string EmpName { get; private set; }
        public string Date { get; private set; }
        public string Type { get; private set; }
        public decimal wageForShift { get; private set; }
        public int hoursWorked { get; private set; }
        public int ID { get; set; }

        public bool Cancelled { get; private set; }

        public WorkShift(int employeeId, string employee, string date, string type, decimal wage, int hours)
        {
            this.empId = employeeId;
            this.EmpName = employee;
            this.Date = date;
            this.Type = type;
            this.wageForShift = wage;
            this.hoursWorked = hours;
            this.Cancelled = false;
        }

        public bool CancelShift()
        {
            if (!this.Cancelled)
            {
                this.Cancelled = true;
                return true;
            }
            else { return false; }
        }

        public override string ToString()
        {  
            return "ID: " + this.empId + " - " + this.EmpName ;
        }
    }
}
