using System;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    public class ScooterCreator : VehicleCreator
    {
        public override Vehicle Create()
        {
            Random random = new Random();
            Engine engine = new Engine(120, 1.2, "electrical", random.Next().ToString());
            Chassis chassis = new Chassis(2, random.Next().ToString(), 170);
            Transmission transmission = new Transmission("auto", 5, "Transmission Inc.");

            return new Scooter(engine, chassis, transmission);
        }
    }
}
