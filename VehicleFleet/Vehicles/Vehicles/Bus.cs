using System;
using System.Runtime.Serialization;
using System.Xml;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [DataContract]
    public class Bus : Vehicle
    {
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public bool IsDoubleDeckerBus { get; set; }
        [DataMember]
        public override Engine Engine { get; set; }
        [DataMember]
        public override Chassis Chassis { get; set; }
        [DataMember]
        public override Transmission Transmission { get; set; }

        private Bus() : base(null, null, null) { }

        public Bus(Engine engine, Chassis chassis, Transmission transmission, string color = "yellow", bool isDoubleDeckerBus = false) : base(engine, chassis, transmission)
        {
            if (engine?.Power < 300)
            {
                throw new InitializationException("Engine power for bus must be greater then 300.");
            }

            Color = color;
            IsDoubleDeckerBus = isDoubleDeckerBus;
        }

        protected override string GetInfo() => string.Format("Bus:\n{0}\n{1}\n{2}\nColor: {3}\nIs double decker bus: {4}", Engine, Chassis, Transmission, Color, IsDoubleDeckerBus);
    }
}
