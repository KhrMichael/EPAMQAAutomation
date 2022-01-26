using System;
using System.Xml;
using System.Xml.Serialization;

namespace VehicleFleet.Vehicles.Parts
{
    [Serializable]
    public class Transmission : VehiclePart, IXmlSerializable
    {
        public string Type { get; set; }
        public int TransmissionsNumber { get; set; }
        public string Manufacturer { get; set; }

        private Transmission() { }

        public Transmission(string type, int transmissionsNumber, string manufacturer)
        {
            Type = type;
            TransmissionsNumber = transmissionsNumber;
            Manufacturer = manufacturer;
        }

        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            Type = reader.ReadElementContentAsString("Type", "");
            TransmissionsNumber = reader.ReadElementContentAsInt("TransmissionNumber", "");
            Manufacturer = reader.ReadElementContentAsString("Manufacturer", "");
        }
        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("Type", Type);
            writer.WriteElementString("TransmissionNumber", TransmissionsNumber.ToString());
            writer.WriteElementString("Manufacturer", Manufacturer);
        }
        protected override string GetInfo() => $"Transmission:\n\tType: {Type}\n\tNumber of gears: {TransmissionsNumber}\n\tManufacturer: {Manufacturer}";
    }
}
