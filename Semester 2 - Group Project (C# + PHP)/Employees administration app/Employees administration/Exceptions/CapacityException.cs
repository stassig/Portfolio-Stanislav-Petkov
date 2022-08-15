using System;
using System.Runtime.Serialization;

namespace Employees_administration
{
    [Serializable]
    internal class CapacityException : Exception
    {
        public CapacityException()
        {
        }

        public CapacityException(string message) : base(message)
        {
        }

        public CapacityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CapacityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}