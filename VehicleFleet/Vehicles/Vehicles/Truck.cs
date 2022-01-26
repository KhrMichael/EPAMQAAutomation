using System;
using System.Xml;
using System.Xml.Serialization;
using VehicleFleet.Vehicles.AdditionalParts;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [Serializable]
    public class Truck : Vehicle, IXmlSerializable
    {
        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
        public TrailerType TrailerType { get; set; }

        private Truck() : base(null, null, null) { }

        public Truck(Engine engine, Chassis chassis, Transmission transmission, TrailerType trailerType = TrailerType.None) : base(engine, chassis, transmission)
        {
            if (engine.Power < 300)
            {
                throw new InitializationException("Engine power for truck must be greater then 300.");
            }

            TrailerType = trailerType;
        }

        protected override string GetInfo() => string.Format("Truck:\n{0}\n{1}\n{2}\nTrailer type: {3}", Engine, Chassis, Transmission, TrailerType);

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("TrailerType", TrailerType.ToString());
        }
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            TrailerType = (TrailerType)reader.ReadElementContentAs(typeof(TrailerType), null, "TrailerType", "");
        }
    }
}
