using System;
using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
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
            IsNaked = isNaked;
        }

        protected override string GetInfo() => string.Format("Scooter:\n{0}\n{1}\n{2}\nIs naked: {3}", Engine, Chassis, Transmission, IsNaked);
    }
}
