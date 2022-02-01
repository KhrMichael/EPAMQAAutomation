using System;
using VehicleFleet.Vehicles.Parts;

namespace VehicleFleet.Vehicles.Vehicles
{
    public class CarCreator : VehicleCreator
    {
        public override Vehicle Create()
        {
            Random random = new Random();
            Engine engine = new Engine(230, 2, "electrical", random.Next().ToString());
            Chassis chassis = new Chassis(4, random.Next().ToString(), 3500);
            Transmission transmission = new Transmission("auto", 5, "Transmission Inc.");

            return new Car(engine, chassis, transmission);
        }
    }
}
