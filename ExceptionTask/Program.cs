using System;
using System.Collections.Generic;
using VehicleFleet;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Vehicles;

namespace ExceptionTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehiclesCollectionGenerator = new VehiclesCollectionGenerator();
            var vehicleCreator = new BusCreator();
            var vehicles = new List<Vehicle>();

            try
            {
                vehiclesCollectionGenerator.FillVehicleCollection(out vehicles);
            }
            catch (InitializationException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (AddException exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                var vehicle = vehicleCreator.Create();
                vehicles.Add(vehicle);
            }
            catch (AddException exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                vehicles.GetVehicleByParameter("power", "399");
            }
            catch (GetVehicleByParametrException exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                var vehicleIdentifier = new VIN();
                vehicles.Remove(vehicleIdentifier);
            }
            catch (RemoveVehicleException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
