using System.Runtime.Serialization;

namespace VehicleFleet.Vehicles.Parts
{
    [DataContract]
    public class Chassis : VehiclePart
    {
        [DataMember]
        public int WheelNumber { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public double PermissibleLoad { get; set; }

        private Chassis() { }

        public Chassis(int wheelNumber, string number, double permissbleLoad)
        {
            WheelNumber = wheelNumber;
            Number = number;
            PermissibleLoad = permissbleLoad;
        }

        protected override string GetInfo() => $"Chassis:\n\tNumber of wheels: {WheelNumber}\n\tNumber: {Number}\n\tPermissable load: {PermissibleLoad}";
    }
}
