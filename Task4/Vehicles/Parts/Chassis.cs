using System;

namespace Task4.Vehicles.Parts
{
    public class Chassis : VehiclePart
    {
        public int WheelNumber { get; private set; }
        public string Number { get; private set; }
        public double PermissbleLoad { get; private set; }

        public Chassis(int wheelNumber, string number, double permissbleLoad)
        {
            WheelNumber = wheelNumber;
            Number = number;
            PermissbleLoad = permissbleLoad;
        }

        protected override string GetInfo() => String.Format("Chassis:\n\tNumber of wheels: {0}\n\tNumber: {1}\n\tPermissable load: {2}", WheelNumber, Number, PermissbleLoad);
    }
}
