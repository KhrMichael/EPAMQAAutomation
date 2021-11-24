using System;

namespace Task4.Vehicles.PartTypes
{
    public class Chassis : VehiclePart
    {
        public Chassis(int wheelNumber, string number, double permissbleLoad)
        {
            WheelNumber = wheelNumber;
            Number = number;
            PermissbleLoad = permissbleLoad;
        }
        public int WheelNumber { get; private set; }
        public string Number { get; private set; }
        public double PermissbleLoad { get; private set; }

        public override string GetInfo()
        {
            return String.Format("Chassis:\n\tNumber of wheels: {0}\n\tNumber: {1}\n\tPermissable load: {2}", WheelNumber, Number, PermissbleLoad);
        }
    }
}
