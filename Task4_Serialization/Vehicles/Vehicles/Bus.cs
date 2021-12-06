using System;
using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    [Serializable]
    public class Bus : Vehicle
    {
        private Bus() : base(null, null, null)
        { }
        public Bus(Engine engine, Chassis chassis, Transmission transmission, string color = "yellow", bool isDoubleDeckerBus = false) : base(engine, chassis, transmission)
        {
            Color = color;
            IsDoubleDeckerBus = isDoubleDeckerBus;
        }
        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
        public string Color { get; set; }
        public bool IsDoubleDeckerBus { get; set; }
        protected override string GetInfo()
        {
            return "Bus:\n" + Engine.ToString() + Chassis.ToString() + Transmission.ToString() + "\nColor: " + Color + "\nIs double decker bus: " + IsDoubleDeckerBus;
        }
    }
}
