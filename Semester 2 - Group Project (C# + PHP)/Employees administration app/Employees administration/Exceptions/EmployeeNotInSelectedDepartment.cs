using System;
using System.Runtime.Serialization;

namespace Employees_administration
{
    [Serializable]
    internal class EmployeeNotInSelectedDepartment : Exception
    {
        public EmployeeNotInSelectedDepartment()
        {
        }

        public EmployeeNotInSelectedDepartment(string message) : base(message)
        {
        }

        public EmployeeNotInSelectedDepartment(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeNotInSelectedDepartment(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}