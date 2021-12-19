using System;

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

        protected override string GetInfo() => String.Format("Engine:\n\tPower: {0}\n\tDisplacement: {1}\n\tType: {2}\n\tSerial number: {3}", Power, Displacement, Type, SerialNumber);
    }
}
