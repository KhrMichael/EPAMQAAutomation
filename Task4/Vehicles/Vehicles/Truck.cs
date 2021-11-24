using Task4.Vehicles.AdditionalParts;
using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
        public TrailerTypes TrailerType { get; set; }

        public override string GetInfo()
        {
            return "Truck:\n" + Engine.GetInfo() + Chassis.GetInfo() + Transmission.GetInfo() + TrailerType.ToString();
        }
    }
}
