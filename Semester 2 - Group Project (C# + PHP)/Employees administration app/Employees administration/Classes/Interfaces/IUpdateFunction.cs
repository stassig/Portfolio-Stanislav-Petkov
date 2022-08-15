using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    interface IUpdateFunction<T>
    {
        bool Update(T obj);
    }
}
