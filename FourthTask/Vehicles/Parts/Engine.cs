using System;

namespace Task4.Vehicles.Parts
{
    public class Engine : VehiclePart
    {
        public double Capasity { get; private set; }
        public double Displacement { get; private set; }
        public string Type { get; private set; }
        public string SerialNumber { get; private set; }

        public Engine(double capasity, double displacement, string type, string serialNumber)
        {
            Capasity = capasity;
            Displacement = displacement;
            Type = type;
            SerialNumber = serialNumber;
        }

        protected override string GetInfo() => String.Format("Engine:\n\tCapasity: {0}\n\tDisplacement: {1}\n\tType: {2}\n\tSerial number: {3}", Capasity, Displacement, Type, SerialNumber);
    }
}
