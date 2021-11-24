using System;

namespace Task4.Vehicles.PartTypes
{
    public class Engine : VehiclePart
    {
        public Engine(double capasity, double displacement, string type, string serialNumber)
        {
            Capasity = capasity;
            Displacement = displacement;
            Type = type;
            SerialNumber = serialNumber;
        }
        public double Capasity { get; private set; }
        public double Displacement { get; private set; }
        public string Type { get; private set; }
        public string SerialNumber { get; private set; }

        public override string GetInfo()
        {
            return String.Format("Engine:\n\tCapasity: {0}\n\tDisplacement: {1}\n\tType: {2}\n\tSerial number: {3}", Capasity, Displacement, Type, SerialNumber);
        }
    }
}
