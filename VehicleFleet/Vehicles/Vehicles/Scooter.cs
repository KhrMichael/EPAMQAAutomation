using System.Runtime.Serialization;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [DataContract]
    public class Scooter : Vehicle
    {
        [DataMember]
        public bool IsNaked { get; set; }
        [DataMember]
        public override Engine Engine { get; set; }
        [DataMember]
        public override Chassis Chassis { get; set; }
        [DataMember]
        public override Transmission Transmission { get; set; }

        private Scooter() : base(null, null, null) { }

        public Scooter(Engine engine, Chassis chassis, Transmission transmission, bool isNaked = false) : base(engine, chassis, transmission)
        {
            if (chassis.WheelNumber < 2 || chassis.WheelNumber > 3)
            {
                throw new InitializationException("Number of scooter wheels must be 2 or 3.");
            }

            IsNaked = isNaked;
        }

        protected override string GetInfo() => $"Scooter:\n{Engine}\n{Chassis}\n{Transmission}\nIs naked: {IsNaked}";
    }
}
