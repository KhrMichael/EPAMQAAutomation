using System;

namespace Task4.Vehicles.Parts
{
    [Serializable]
    public class Transmission : VehiclePart
    {
        private Transmission() { }
        public Transmission(string type, int transmissionsNumber, string manufacturer)
        {
            Type = type;
            TransmissionsNumber = transmissionsNumber;
            Manufacturer = manufacturer;
        }
        public string Type { get; set; }
        public int TransmissionsNumber { get; set; }
        public string Manufacturer { get; set; }

        protected override string GetInfo()
        {
            return String.Format("Transmission:\n\tType: {0}\n\tNumber of gears: {1}\n\tManufacturer: {2}", Type, TransmissionsNumber, Manufacturer);
        }
    }
}
