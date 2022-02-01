using System;
using System.Runtime.Serialization;

namespace VehicleFleet.Vehicles.Exceptions
{
    public class AddException : Exception
    {
        public AddException()
        { }

        public AddException(string message) : base(message)
        { }

        public AddException(string message, Exception innerException) : base(message, innerException)
        { }

        protected AddException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
