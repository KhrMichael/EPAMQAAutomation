using Task4.Vehicles.PartTypes;

namespace Task4.Vehicles.VehicleTypes
{
    public abstract class Vehicle
    {
        public abstract Engine Engine { get; protected set; }
        public abstract Chassis Chassis { get; protected set; }
        public abstract Transmission Transmission { get; protected set; }

        public abstract string GetInfo();
    }
}
