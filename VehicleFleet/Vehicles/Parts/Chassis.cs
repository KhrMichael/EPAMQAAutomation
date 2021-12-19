using System;

namespace VehicleFleet.Vehicles.Parts
{
    [Serializable]
    public class Chassis : VehiclePart
    {
        public int WheelNumber { get; set; }
        public string Number { get; set; }
        public double PermissbleLoad { get; set; }

        private Chassis() { }

        public Chassis(int wheelNumber, string number, double permissbleLoad)
        {
            WheelNumber = wheelNumber;
            Number = number;
            PermissbleLoad = permissbleLoad;
        }

        protected override string GetInfo() => String.Format("Chassis:\n\tNumber of wheels: {0}\n\tNumber: {1}\n\tPermissable load: {2}", WheelNumber, Number, PermissbleLoad);
    }
}
