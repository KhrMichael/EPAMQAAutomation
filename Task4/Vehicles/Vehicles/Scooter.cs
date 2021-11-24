using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    public class Scooter : Vehicle
    {
        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
        public bool IsNaked { get; set; }
        public override string GetInfo()
        {
            return "Scooter:\n" + Engine.GetInfo() + Chassis.GetInfo() + Transmission.GetInfo();
        }
    }
}
