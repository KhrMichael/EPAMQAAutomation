using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VehicleFleet.Vehicles.Vehicles
{
    /// <summary>
    /// Vehicle Identification Number
    /// </summary>
    public class VIN : IXmlSerializable
    {
        public string Number { get; private set; }

        public VIN()
        {
            Number = new VINGenerator().GenerateVIN();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Number", Number);
        }
        public void ReadXml(XmlReader reader)
        {
            Number = reader.ReadElementContentAsString("Number", "");
        }
    }
}
