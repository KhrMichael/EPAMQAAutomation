using System;
using System.Runtime.Serialization;

namespace VehicleFleet.Vehicles.Exceptions
{
    public class GetVehicleByParametrException : Exception
    {
        public GetVehicleByParametrException()
        { }

        public GetVehicleByParametrException(string message) : base(message)
        { }

        public GetVehicleByParametrException(string message, Exception innerException) : base(message, innerException)
        { }

        protected GetVehicleByParametrException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
