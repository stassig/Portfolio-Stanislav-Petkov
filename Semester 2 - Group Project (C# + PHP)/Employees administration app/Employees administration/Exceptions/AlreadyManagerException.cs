using System;
using System.Runtime.Serialization;

namespace Employees_administration
{
    [Serializable]
    internal class AlreadyManagerException : Exception
    {
        public AlreadyManagerException()
        {
        }

        public AlreadyManagerException(string message) : base(message)
        {
        }

        public AlreadyManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}