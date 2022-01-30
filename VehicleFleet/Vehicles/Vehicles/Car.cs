using System;
using System.Runtime.Serialization;
using System.Xml;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [DataContract]
    public class Car : Vehicle
    {
        [DataMember]
        private int seatsNumber;

        [DataMember]
        public override Engine Engine { get; set; }
        [DataMember]
        public override Chassis Chassis { get; set; }
        [DataMember]
        public override Transmission Transmission { get; set; }
        [DataMember]
        public int SeatsNumber
        {
            get => seatsNumber;
            set
            {
                if (value <= 0 || value > 9)
                {
                    throw new ArgumentException("Seats number must be greater then 0 and lower then 10");
                }
                seatsNumber = value;
            }
        }

        private Car() : base(null, null, null) { }

        public Car(Engine engine, Chassis chassis, Transmission transmission, int seatsNumber = 5) : base(engine, chassis, transmission)
        {
            SeatsNumber = seatsNumber;
        }

        protected override string GetInfo() => String.Format("Car:\n{0}\n{1}\n{2}\nSeats number: {3}", Engine, Chassis, Transmission, SeatsNumber);
    }
}
