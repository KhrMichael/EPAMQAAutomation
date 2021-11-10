using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Types
{
    public abstract class Vehicle
    {
        public abstract Engine Engine { get; protected set; }
        public abstract Chassis Chassis { get; protected set; }
        public abstract Transmission Transmission { get; protected set; }

        public abstract string GetInfo();
    }
}
