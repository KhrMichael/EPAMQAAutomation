using System;
using System.Xml.Serialization;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Scooter))]
    [Serializable]
    public abstract class Vehicle
    {
        public abstract Engine Engine { get; set; }
        public abstract Chassis Chassis { get; set; }
        public abstract Transmission Transmission { get; set; }

        private Vehicle() { }

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
