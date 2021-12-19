using System;

namespace VehicleFleet.Vehicles
{
    public class UpdateVehicleException : Exception
    {
        public UpdateVehicleException(string message) : base(message)
        { }
    }
}
