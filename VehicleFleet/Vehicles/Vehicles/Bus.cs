using System.Runtime.Serialization;
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

        protected override string GetInfo() => $"Bus:\n{Engine}\n{Chassis}\n{Transmission}\nColor: {Color}\nIs double decker bus: {IsDoubleDeckerBus}";
    }
}
