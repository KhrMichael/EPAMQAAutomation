using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace VehicleFleet.Vehicles.Parts
{
    [DataContract]
    public class Transmission : VehiclePart
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int TransmissionsNumber { get; set; }
        [DataMember]
        public string Manufacturer { get; set; }

        private Transmission() { }

        public Transmission(string type, int transmissionsNumber, string manufacturer)
        {
            Type = type;
            TransmissionsNumber = transmissionsNumber;
            Manufacturer = manufacturer;
        }

        protected override string GetInfo() => $"Transmission:\n\tType: {Type}\n\tNumber of gears: {TransmissionsNumber}\n\tManufacturer: {Manufacturer}";
    }
}
