using System;
using System.Xml;

namespace VehicleFleet.Vehicles.Parts
{
    [Serializable]
    public class Chassis : VehiclePart
    {
        public int WheelNumber { get; set; }
        public string Number { get; set; }
        public double PermissibleLoad { get; set; }

        private Chassis() { }

        public Chassis(int wheelNumber, string number, double permissbleLoad)
        {
            WheelNumber = wheelNumber;
            Number = number;
            PermissibleLoad = permissbleLoad;
        }

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("WheelNumber", WheelNumber.ToString());
            writer.WriteElementString("Number", Number);
            writer.WriteElementString("PermissibleLoad", PermissibleLoad.ToString());
        }
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);
        }
        protected override string GetInfo() => $"Chassis:\n\tNumber of wheels: {WheelNumber}\n\tNumber: {Number}\n\tPermissable load: {PermissibleLoad}";
    }
}
