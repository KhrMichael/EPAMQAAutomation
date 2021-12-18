using System;

namespace VehicleFleet.Vehicles.Exceptions
{
    public class InitializationException : Exception
    {
        public InitializationException(string message) : base(message)
        {
        }

    }
}
