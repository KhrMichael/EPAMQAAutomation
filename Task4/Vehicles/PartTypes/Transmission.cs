using System;

namespace Task4.Vehicles.PartTypes
{
    public class Transmission : VehiclePart
    {
        public Transmission(string type, int transmissionsNumber, string manufacturer)
        {
            Type = type;
            TransmissionsNumber = transmissionsNumber;
            Manufacturer = manufacturer;
        }
        public string Type { get; private set; }
        public int TransmissionsNumber { get; private set; }
        public string Manufacturer { get; private set; }

        public override string GetInfo()
        {
            return String.Format("Transmission:\n\tType: {0}\n\tNumber of gears: {1}\n\tManufacturer: {2}", Type, TransmissionsNumber, Manufacturer);
        }
    }
}
