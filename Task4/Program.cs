using System;
using System.Collections.Generic;
using Task4.Vehicles.Vehicles;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleCollectionGenerator vehicleCollectionGenerator = new VehicleCollectionGenerator();

            vehicleCollectionGenerator.TryFillVehicleCollection(out List<Vehicle> vehicleCollection);

            foreach (var vehicle in vehicleCollection)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
