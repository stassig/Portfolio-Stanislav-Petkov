using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class EmployeeStatistics
    {
        protected ShiftManager shiftManager;
        protected ShiftMediator shiftMediator;
        protected UserManager userManager;

        public EmployeeStatistics(UserManager userManager, ShiftManager shiftManager)
        {
            this.userManager = userManager;
            this.shiftManager = shiftManager;
            this.shiftMediator = new ShiftMediator();
        }       
    }
}
