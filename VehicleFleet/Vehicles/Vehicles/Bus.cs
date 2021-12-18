using System;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [Serializable]
    public class Bus : Vehicle
    {
        public string Color { get; set; }
        public bool IsDoubleDeckerBus { get; set; }

        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }

        private Bus() : base(null, null, null) { }

        public Bus(Engine engine, Chassis chassis, Transmission transmission, string color = "yellow", bool isDoubleDeckerBus = false) : base(engine, chassis, transmission)
        {
            if (engine.Power < 300)
            {
                throw new InitializationException("Engine power for bus must be greater then 300.");
            }

            Color = color;
            IsDoubleDeckerBus = isDoubleDeckerBus;
        }

        protected override string GetInfo() => string.Format("Bus:\n{0}\n{1}\n{2}\nColor: {3}\nIs double decker bus: {4}", Engine, Chassis, Transmission, Color, IsDoubleDeckerBus);
    }
}
