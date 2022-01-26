using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Scooter))]
    [Serializable]
    public abstract class Vehicle : IXmlSerializable
    {
        public VIN VehicleIdentificationNumber { get; private set; }
        public abstract Engine Engine { get; set; }
        public abstract Chassis Chassis { get; set; }
        public abstract Transmission Transmission { get; set; }

        private Vehicle() { }

        public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
        {
            Engine = engine;
            Chassis = chassis;
            Transmission = transmission;
            VehicleIdentificationNumber = new VIN();
        }

        /// <summary>
        /// Provide information about Vehicle in string format.
        /// </summary>
        protected abstract string GetInfo();


        public override string ToString()
        {
            return GetInfo();
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public virtual void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Type", this.GetType().Name);
            VehicleIdentificationNumber.WriteXml(writer);

            writer.WriteStartElement("Engine");
            Engine.WriteXml(writer);
            writer.WriteEndElement();

            writer.WriteStartElement("Chassis");
            Chassis.WriteXml(writer);
            writer.WriteEndElement();

            writer.WriteStartElement("Transmisson");
            Transmission.WriteXml(writer);
            writer.WriteEndElement();
        }
        public virtual void ReadXml(XmlReader reader)
        {
            VehicleIdentificationNumber.ReadXml(reader);

            reader.ReadStartElement("Engine");
            Engine.ReadXml(reader);
            reader.ReadEndElement();

            reader.ReadStartElement("Chassis");
            Chassis.ReadXml(reader);
            reader.ReadEndElement();

            reader.ReadStartElement("Transmisson");
            Transmission.ReadXml(reader);
            reader.ReadEndElement();
        }

    }
}
