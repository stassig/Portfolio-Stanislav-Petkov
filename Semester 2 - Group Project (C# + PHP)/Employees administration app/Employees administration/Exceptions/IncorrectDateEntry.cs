using System;
using System.Runtime.Serialization;

namespace Employees_administration
{
    [Serializable]
    internal class IncorrectDateEntry : Exception
    {
        public IncorrectDateEntry()
        {
        }

        public IncorrectDateEntry(string message) : base(message)
        {
        }

        public IncorrectDateEntry(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectDateEntry(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}