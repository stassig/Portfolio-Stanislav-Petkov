using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class Department
    {
        private List<Employee> employees;
        public string ManagerName { get; private set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManagerID { get; private set; }
        private List<Product> products;


        public Department(string name)
        {
            this.Name = name;
            this.ManagerID = -1;
            this.ManagerName = null;
            employees = new List<Employee>();
            products = new List<Product>();

        }

        public Department(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            this.ManagerID = -1;
            this.ManagerName = null;
            employees = new List<Employee>();
            products = new List<Product>();
        }

        //public void assignAManager(Employee employee)
        //{
        //        this.ManagerID = employee.ID;
        //        this.ManagerName = employee.FirstName;
           
       // }

        public void AssignManager(int id)
        {
            this.ManagerID = id;
            UserManager userManager = new UserManager();
            Employee employee = userManager.GetEmp(id);
            this.ManagerName = employee.FirstName;

        }
        public bool AssignEmployee(Employee e)
        {
            if (!employees.Contains(e))
            {
                employees.Add(e);
                return true;
            }
            return false;
        }

        public bool RemoveEmployee(Employee e)
        {
            if (employees.Contains(e))
            {
                employees.Remove(e);
                return true;
            }
            return false;
        }

        //TO DO: Assign/remove products as well

        public void EditInfo(string name)
        {
            this.Name = name;
        }

        public bool AssignProduct(Product p)
        {
            if (!products.Contains(p))
            {
                products.Add(p);
                return true;
            }
            return false;
        }

        public string GetInfo()
        {
            return $"ID: {this.ID},Name: {this.Name}and manager: {this.ManagerName}({this.ManagerID})";
        }

        public override string ToString()
        {
            return this.Name;
        }
  
        public List<Employee> GetEmployeesOfDepartment()
        {
            return this.employees;
        }
        public List<Product> GetProductsOfDepartment()
        {
            return this.products;
        }
    }
}
