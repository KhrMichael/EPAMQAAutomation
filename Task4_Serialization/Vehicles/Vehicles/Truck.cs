using System;
using Task4.Vehicles.AdditionalParts;
using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    [Serializable]
    public class Truck : Vehicle
    {
        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
        public TrailerType TrailerType { get; set; }
        private Truck() : base(null, null, null) 
        { }
        public Truck(Engine engine, Chassis chassis, Transmission transmission, TrailerType trailerType = TrailerType.None) : base(engine, chassis, transmission)
        {
            TrailerType = trailerType;
        }

        protected override string GetInfo()
        {
            return "Truck:\n" + Engine.ToString() + Chassis.ToString() + Transmission.ToString() + "\nTrailer type: " + this.TrailerType.ToString();
        }
    }
}
