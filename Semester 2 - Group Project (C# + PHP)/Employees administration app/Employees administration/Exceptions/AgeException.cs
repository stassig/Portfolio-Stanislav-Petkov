using System;
using System.Runtime.Serialization;

namespace Employees_administration
{
    [Serializable]
    internal class AgeException : Exception
    {
        public AgeException()
        {
        }

        public AgeException(string message) : base(message)
        {
        }

        public AgeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AgeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}