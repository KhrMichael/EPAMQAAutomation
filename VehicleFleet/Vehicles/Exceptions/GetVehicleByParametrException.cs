using System;

namespace VehicleFleet
{
    public class GetVehicleByParametrException : Exception
    {
        public GetVehicleByParametrException(string message) : base(message)
        { }
    }
}
