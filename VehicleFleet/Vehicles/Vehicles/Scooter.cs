using System;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [Serializable]
    public class Scooter : Vehicle
    {
        public bool IsNaked { get; set; }

        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }

        private Scooter() : base(null, null, null) { }

        public Scooter(Engine engine, Chassis chassis, Transmission transmission, bool isNaked = false) : base(engine, chassis, transmission)
        {
            if(chassis.WheelNumber < 2 || chassis.WheelNumber > 3)
            {
                throw new InitializationException("Number of scooter scooter must be 2 or 3.");
            }

            IsNaked = isNaked;
        }

        protected override string GetInfo() => string.Format("Scooter:\n{0}\n{1}\n{2}\nIs naked: {3}", Engine, Chassis, Transmission, IsNaked);
    }
}
