using System.Runtime.Serialization;
using VehicleFleet.Vehicles.AdditionalParts;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [DataContract]
    public class Truck : Vehicle
    {
        [DataMember]
        public override Engine Engine { get; set; }
        [DataMember]
        public override Chassis Chassis { get; set; }
        [DataMember]
        public override Transmission Transmission { get; set; }
        [DataMember]
        public TrailerType TrailerType { get; set; }

        private Truck() : base(null, null, null) { }

        public Truck(Engine engine, Chassis chassis, Transmission transmission, TrailerType trailerType = TrailerType.None) : base(engine, chassis, transmission)
        {
            if (engine.Power < 300)
            {
                throw new InitializationException("Engine power for truck must be greater then 300.");
            }

            TrailerType = trailerType;
        }

        protected override string GetInfo() => $"Truck:\n{Engine}\n{Chassis}\n{Transmission}\nTrailer type: {TrailerType}";
    }
}
