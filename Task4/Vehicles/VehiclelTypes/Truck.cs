using Task4.Vehicles.PartTypes;

namespace Task4.Vehicles.VehicleTypes
{
    public abstract class Truck : Vehicle
    {
        public override Engine Engine { get; protected set; }
        public override Chassis Chassis { get; protected set; }
        public override Transmission Transmission { get; protected set; }

        public override string GetInfo()
        {
            return "Truck:\n" + Engine.GetInfo() + Chassis.GetInfo() + Transmission.GetInfo();
        }
    }
}
