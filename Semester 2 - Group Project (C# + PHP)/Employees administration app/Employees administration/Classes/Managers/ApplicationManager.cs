using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class ApplicationManager
    {
        public ProductManager ProductManager { get; private set; }
        public RequestManager RequestManager { get; private set; }
        public ShiftManager ShiftManager { get; private set; }
        public UserManager UserManager { get; private set; }
       
        public DepartmentManager DepartmentManager { get; private set; }

        public Scheduler Scheduler { get; private set; }

        public ApplicationManager()
        {
            this.ProductManager = new ProductManager();
            this.RequestManager = new RequestManager();
            this.ShiftManager = new ShiftManager();
            this.UserManager = new UserManager();
            this.DepartmentManager = new DepartmentManager();
            this.Scheduler = new Scheduler();
        }

        public bool LoadAllData()
        {
            if (this.ProductManager.Load() && this.RequestManager.Load() &&
                this.ShiftManager.Load() && this.UserManager.Load()&&this.DepartmentManager.Load())
            {
                return true;
            }
            else { return false; }
        }
    }
}
