using System;
using System.Xml;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [Serializable]
    public class Car : Vehicle
    {
        private int seatsNumber;

        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
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

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("SeatsNumber", SeatsNumber.ToString());
        }
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            reader.ReadElementContentAsInt("SeatsNumber", "");
        }
    }
}
