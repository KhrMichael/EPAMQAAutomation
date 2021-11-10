using Task4.Cars.Parts;

namespace Task4.Cars.Types
{
    public abstract class Vehicle
    {
        public abstract Engine Engine { get; protected set; }
        public abstract Chassis Chassis { get; protected set; }
        public abstract Transmission Transmission { get; protected set; }
    }
}
