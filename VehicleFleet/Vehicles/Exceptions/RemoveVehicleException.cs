using System;

namespace VehicleFleet.Vehicles.Exceptions
{
    public class RemoveVehicleException : Exception
    {
        public RemoveVehicleException(string message) : base(message)
        { }
    }
}
