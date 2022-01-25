namespace VehicleFleet.Vehicles.Vehicles
{
    /// <summary>
    /// Vehicle Identification Number
    /// </summary>
    public class VIN
    {
        public string Number { get; private set; }

        public VIN()
        {
            Number = new VINGenerator().GenerateVIN();
        }
    }
}
