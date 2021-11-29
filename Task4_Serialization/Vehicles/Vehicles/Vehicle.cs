using System;
using System.Xml.Serialization;
using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Scooter))]
    [XmlInclude(typeof(Truck))]
    [Serializable]
    public abstract class Vehicle
    {
        private Vehicle()
        { }
        public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
        {
            Engine = engine;
            Chassis = chassis;
            Transmission = transmission;
        }
        public abstract Engine Engine { get; set; }
        public abstract Chassis Chassis { get; set; }
        public abstract Transmission Transmission { get; set; }

        protected abstract string GetInfo();
        public override string ToString()
        {
            return GetInfo();
        }
    }
}
