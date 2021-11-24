using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    public abstract class Vehicle
    {
        public abstract Engine Engine { get; set; }
        public abstract Chassis Chassis { get; set; }
        public abstract Transmission Transmission { get; set; }

        public abstract string GetInfo();
    }
}
