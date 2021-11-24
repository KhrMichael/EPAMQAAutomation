using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    public class Bus : Vehicle
    {
        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
        public string Color { get; set; }
        public bool IsDoubleDeckerBus { get; set; }
        public override string GetInfo()
        {
            return "Bus:\n" + Engine.GetInfo() + Chassis.GetInfo() + Transmission.GetInfo();
        }
    }
}
