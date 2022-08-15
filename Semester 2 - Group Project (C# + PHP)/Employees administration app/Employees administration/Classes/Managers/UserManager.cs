using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class UserManager : IBasicFunctions<User>
    {
        public List<User> Users { get; private set; }

        private EmployeeMediator employeeMediator;
        private AdminMediator adminMediator;
        private ManagerMediator managerMediator;

        public UserManager()
        {
            this.Users = new List<User>();
            this.employeeMediator = new EmployeeMediator();
            this.adminMediator = new AdminMediator();
            this.managerMediator = new ManagerMediator();
        }

        public bool Add(User user)
        {
            if (user != null)
            {
                this.Users.Add(user);
                if (user is Administrator) { this.adminMediator.Add((Administrator)user); }
                else if (user is Manager) { this.managerMediator.Add((Manager)user); }
                else { this.employeeMediator.Add((Employee)user); }

                return true;
            }
            else { return false; }

        }

        public bool Remove(User user)
        {
            if (this.Get(user.ID) != null)
            {
                this.Users.Remove(user);
                if (user is Administrator) { this.adminMediator.Remove((Administrator)user); }
                else if (user is Manager) { this.managerMediator.Remove((Manager)user); }
                else { this.employeeMediator.Remove((Employee)user); }
                return true;
            }
            else { return false; }
        }

        public bool Update(Employee employee)
        {
            if (this.Users.Contains(employee))
            {
                this.employeeMediator.Update(employee);
                return true;
            }
            else { return false; }
        }

        public User Get(int id)
        {
            foreach (User user in this.GetAll())
            {
                if (user.ID == id && user is Employee)
                {
                    return user;
                }
            }
            return null;
        }

        public Employee GetEmp(int id)
        {
            foreach (Employee e in this.GetAllEmployees())
            {
                if (e.ID == id)
                {
                    return e;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            this.Load();
            return this.Users;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            foreach (User user in this.GetAll())
            {
                if (user is Employee)
                {
                    employees.Add((Employee)user);
                }
            }
            return employees;
        }
         public List<Employee>GetEmployeesByDepartment(Department department)
        {
            List<Employee> employees = new List<Employee>();
            foreach (Employee emp in this.GetAllEmployees())
            {
                if (emp.DepartmentID==department.ID)
                {
                    employees.Add(emp);
                }
            }
            return employees;
        }
      
        public List<Employee> GetActiveEmployees(Department department )
        {
            List<Employee> activeEmployees = new List<Employee>();
            DateTime currentDate = DateTime.Now;

            foreach (Employee employee in this.GetEmployeesByDepartment(department))
            {
                if (DateTime.Compare(DateTime.ParseExact(employee.LastWorkingDay, "MM/dd/yyyy", null), currentDate) > 0)
                {
                    activeEmployees.Add(employee);
                }
            }
            return activeEmployees;
        }

        public List<Employee> GetActiveEmployees()
        {
            List<Employee> activeEmployees = new List<Employee>();
            DateTime currentDate = DateTime.Now;

            foreach (Employee employee in this.GetAllEmployees())
            {
                if (DateTime.Compare(DateTime.ParseExact(employee.LastWorkingDay, "MM/dd/yyyy", null), currentDate) > 0)
                {
                    activeEmployees.Add(employee);
                }
            }
            return activeEmployees;
        }

        public User LoginCheck(string username, string password)
        {
            foreach (User user in this.GetAll())
            {
                if (user.CheckDetails(username, password))
                {
                    return user;
                }
            }
            return null;
        }

        public bool Load()
        {
            this.Users = null;
            this.Users = new List<User>();

            foreach (User administrator in this.adminMediator.GetAll())
            {
                this.Users.Add(administrator);
            }

            foreach (User manager in this.managerMediator.GetAll())
            {
                this.Users.Add(manager);
            }

            foreach (User employee in this.employeeMediator.GetAll())
            {
                this.Users.Add(employee);
            }

            return true;
        }

    }
}
