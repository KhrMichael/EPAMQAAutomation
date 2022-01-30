using System.Runtime.Serialization;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [KnownType(typeof(Car))]
    [KnownType(typeof(Bus))]
    [KnownType(typeof(Truck))]
    [KnownType(typeof(Scooter))]
    [DataContract]
    public abstract class Vehicle
    {
        [DataMember]
        public VIN VehicleIdentificationNumber { get; private set; }
        [DataMember]
        public abstract Engine Engine { get; set; }
        [DataMember]
        public abstract Chassis Chassis { get; set; }
        [DataMember]
        public abstract Transmission Transmission { get; set; }

        private Vehicle() { }

        public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
        {
            if(engine != null && chassis != null && transmission != null)
            { 
                Engine = engine;
                Chassis = chassis;
                Transmission = transmission;
                VehicleIdentificationNumber = new VIN();
            }
            else
            {
                throw new InitializationException("Parts of the vehicle can't be null.");
            }
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
