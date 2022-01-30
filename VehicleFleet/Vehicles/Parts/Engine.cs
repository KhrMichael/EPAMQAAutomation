using System.Runtime.Serialization;

namespace VehicleFleet.Vehicles.Parts
{
    [DataContract]
    public class Engine : VehiclePart
    {
        [DataMember]
        public double Power { get; set; }
        [DataMember]
        public double Displacement { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }

        private Engine() { }

        public Engine(double power, double displacement, string type, string serialNumber)
        {
            Power = power;
            Displacement = displacement;
            Type = type;
            SerialNumber = serialNumber;
        }

        protected override string GetInfo() => $"Engine:\n\tPower: {Power}\n\tDisplacement: {Displacement}\n\tType: {Type}\n\tSerial number: {SerialNumber}";
    }
}
