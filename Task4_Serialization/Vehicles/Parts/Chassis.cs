using System;

namespace Task4.Vehicles.Parts
{
    [Serializable]
    public class Chassis : VehiclePart
    {
        private Chassis() { }
        public Chassis(int wheelNumber, string number, double permissbleLoad)
        {
            WheelNumber = wheelNumber;
            Number = number;
            PermissbleLoad = permissbleLoad;
        }
        public int WheelNumber { get;  set; }
        public string Number { get;  set; }
        public double PermissbleLoad { get;  set; }

        protected override string GetInfo()
        {
            return String.Format("Chassis:\n\tNumber of wheels: {0}\n\tNumber: {1}\n\tPermissable load: {2}", WheelNumber, Number, PermissbleLoad);
        }
    }
}
