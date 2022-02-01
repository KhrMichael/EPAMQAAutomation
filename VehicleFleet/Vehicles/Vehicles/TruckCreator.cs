using System;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    public class TruckCreator : VehicleCreator
    {
        public override Vehicle Create()
        {
            Random random = new Random();
            Engine engine = new Engine(350, 8, "electrical", random.Next().ToString());
            Chassis chassis = new Chassis(6, random.Next().ToString(), 15000);
            Transmission transmission = new Transmission("auto", 6, "Transmission Inc.");

            return new Truck(engine, chassis, transmission);
        }
    }
}
