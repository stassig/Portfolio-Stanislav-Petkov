using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class DepartmentManager : IBasicFunctions<Department>
    {
        private List<Department> departments;
        private DepartmentMediator mediator;

        public DepartmentManager()
        {
            departments = new List<Department>();
            mediator = new DepartmentMediator();
        }

        public bool Add(Department obj)
        {
            foreach (Department dep in GetAll())
            {
                if (obj.Name != dep.Name)
                {
                    departments.Add(obj);
                    mediator.Add(obj);
                    return true;
                }
            }
          
            return false;
        }

        public bool Remove(Department obj)
        {
            foreach (Department dep in GetAll())
            {
                if (dep.ID == obj.ID)
                {
                    departments.Remove(obj);
                    mediator.Remove(obj);
                    return true;
                }
            }
            return false;
        }

        public Department Get(int id)
        {
            foreach (Department d in GetAll())
            {
                if (d.ID == id)
                {
                    return d;
                }
            }
            return null;
        }
        public Department Get(string name)
        {
            foreach (Department department in GetAll())
            {
                if (department.Name == name)
                {
                    return department;
                }
            }
            return null;
        }

        public bool CheckAlreadyManager(int id)
        {
            foreach (Department department in GetAll())
            {
                if (id == department.ManagerID)
                {
                    return false;
                }
            }
            return true;
        }


        public List<Department> GetAll()
        {
            Load();
            return departments;

        }
        public bool Load()
        {
            this.departments = this.mediator.GetAll();
            if (departments != null)
            {
                return true;
            }
            return false;
        }

        public bool Update(Department department, int newManagerID, string newDepartmentName)
        {
            this.mediator.Update(department,newManagerID, newDepartmentName);
            return true;
        }

        public bool AssignEmpToDep(UserManager userManager, Employee employee, Department department)
        {

            foreach (Employee e in userManager.GetAllEmployees())
            {
                if (e.ID == employee.ID)
                {
                    foreach (Department d in this.departments)
                    {
                        if (department.ID == d.ID)
                        {
                            d.AssignEmployee(e);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool AssignProductsToDep(ProductManager productManager, Product product, Department department)
        {

            foreach (Product p in productManager.GetAll())
            {
                if (p.ID == product.ID)
                {
                    foreach (Department d in this.departments)
                    {
                        if (department.ID == d.ID)
                        {
                            d.AssignProduct(p);
                            return true;
                        }
                    }

                }

            }
            return false;
        }

        public int GetDepartmentIndex(int id)
        {
            List<Department> departments = this.GetAll();
            for (int i = 0; i < departments.Count; i++)
            {
                if(departments[i].ID == id) { return i; }
            }
            return -1;           
        }
    }
}
