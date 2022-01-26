using System;

namespace VehicleFleet
{
    public class UpdateVehicleException : Exception
    {
        public UpdateVehicleException(string message) : base(message)
        { }
    }
}
