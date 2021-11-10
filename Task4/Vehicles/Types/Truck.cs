using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Types
{
    public class Truck : Vehicle
    {
        public override Engine Engine { get; protected set; }
        public override Chassis Chassis { get; protected set; }
        public override Transmission Transmission { get; protected set; }
    }
}
