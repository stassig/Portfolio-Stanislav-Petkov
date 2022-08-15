using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    interface IBasicFunctions<T>
    {
        bool Add(T obj);
        bool Remove(T obj);
        T Get(int id);
        List<T> GetAll();
        bool Load();

    }
}
