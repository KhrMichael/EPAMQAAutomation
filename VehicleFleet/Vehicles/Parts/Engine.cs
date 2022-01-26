using System;
using System.Xml;

namespace VehicleFleet.Vehicles.Parts
{
    [Serializable]
    public class Engine : VehiclePart
    {
        public double Power { get; set; }
        public double Displacement { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }

        private Engine() { }

        public Engine(double power, double displacement, string type, string serialNumber)
        {
            Power = power;
            Displacement = displacement;
            Type = type;
            SerialNumber = serialNumber;
        }

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("Power", Power.ToString());
            writer.WriteElementString("Displacement", Displacement.ToString());
            writer.WriteElementString("Type", Type);
            writer.WriteElementString("SerialNumber", SerialNumber);
        }
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
            Power = reader.ReadElementContentAsDouble("Power", "");
            Displacement = reader.ReadElementContentAsDouble("Displacement", "");
            Type = reader.ReadElementContentAsString("Type", "");
            SerialNumber = reader.ReadElementContentAsString("SerialNumber", "");
        }
        protected override string GetInfo() => $"Engine:\n\tPower: {Power}\n\tDisplacement: {Displacement}\n\tType: {Type}\n\tSerial number: {SerialNumber}";
    }
}
