using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    public abstract class Vehicle
    {
        public abstract Engine Engine { get; set; }
        public abstract Chassis Chassis { get; set; }
        public abstract Transmission Transmission { get; set; }

        public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
        {
            Engine = engine;
            Chassis = chassis;
            Transmission = transmission;
        }

        /// <summary>
        /// Provide information about Vehicle in string format.
        /// </summary>
        protected abstract string GetInfo();

        public override string ToString()
        {
            return GetInfo();
        }
    }
}
