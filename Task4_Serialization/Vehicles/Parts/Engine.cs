using System;

namespace Task4.Vehicles.Parts
{
    [Serializable]
    public class Engine : VehiclePart
    {
        private Engine() { }
        public Engine(double capasity, double displacement, string type, string serialNumber)
        {
            Capasity = capasity;
            Displacement = displacement;
            Type = type;
            SerialNumber = serialNumber;
        }
        public double Capasity { get; set; }
        public double Displacement { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }

        protected override string GetInfo()
        {
            return String.Format("Engine:\n\tCapasity: {0}\n\tDisplacement: {1}\n\tType: {2}\n\tSerial number: {3}", Capasity, Displacement, Type, SerialNumber);
        }
    }
}
