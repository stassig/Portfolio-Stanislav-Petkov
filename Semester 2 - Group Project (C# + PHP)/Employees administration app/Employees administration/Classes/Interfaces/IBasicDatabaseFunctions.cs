using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    interface IBasicDatabaseFunctions<T>
    {
        bool Add(T obj);
        bool Remove(T obj);
        List<T> GetAll();
    }
}
