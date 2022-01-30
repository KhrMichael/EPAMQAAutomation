using System;
using System.Runtime.Serialization;

namespace VehicleFleet.Vehicles.Exceptions
{
    public class RemoveVehicleException : Exception
    {
        public RemoveVehicleException()
        { }

        public RemoveVehicleException(string message) : base(message)
        { }

        public RemoveVehicleException(string message, Exception innerException) : base(message, innerException)
        { }

        protected RemoveVehicleException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
