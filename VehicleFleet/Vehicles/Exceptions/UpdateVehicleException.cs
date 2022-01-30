using System;
using System.Runtime.Serialization;

namespace VehicleFleet
{
    public class UpdateVehicleException : Exception
    {
        public UpdateVehicleException()
        { }

        public UpdateVehicleException(string message) : base(message)
        { }

        public UpdateVehicleException(string message, Exception innerException) : base(message, innerException)
        { }

        protected UpdateVehicleException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
