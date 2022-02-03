using System;
using System.Runtime.Serialization;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles.Exceptions
{
    public class ExecuteCommandException : Exception
    {
        public ExecuteCommandException()
        {
        }

        public ExecuteCommandException(string message) : base(message)
        {
        }

        public ExecuteCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExecuteCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
