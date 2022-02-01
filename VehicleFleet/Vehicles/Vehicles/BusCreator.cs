using System;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    public class BusCreator : VehicleCreator
    {
        public override Vehicle Create()
        {
            Random random = new Random();

            Engine engine = new Engine(300, 4.5, "electrical", random.Next().ToString());
            Chassis chassis = new Chassis(6, random.Next().ToString(), 10000);
            Transmission transmission = new Transmission("auto", 6, "Transmission Inc.");

            return new Bus(engine, chassis, transmission);
        }
    }
}
