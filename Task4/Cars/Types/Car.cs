using Task4.Cars.Parts;

namespace Task4.Cars.Types
{
    public class Car : Vehicle
    {
        public override Engine Engine { get; protected set; }
        public override Chassis Chassis { get; protected set; }
        public override Transmission Transmission { get; protected set; }
    }
}
