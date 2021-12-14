using Task4.Vehicles.AdditionalParts;
using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
        public TrailerType TrailerType { get; set; }

        public Truck(Engine engine, Chassis chassis, Transmission transmission, TrailerType trailerType = TrailerType.None) : base(engine, chassis, transmission)
        {
            TrailerType = trailerType;
        }

        protected override string GetInfo() => string.Format("Truck:\n{0}\n{1}\n{2}\nTrailer type: {3}", Engine, Chassis, Transmission, TrailerType);
    }
}
