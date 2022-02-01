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
            VehiclesCollectionGenerator vehiclesCollectionGenerator = new VehiclesCollectionGenerator();
            VehicleCreator vehicleCreator = new BusCreator();
            List<Vehicle> vehicles = new List<Vehicle>();

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
                vehicles.Add(vehicleCreator.Create());
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
                vehicles.Remove(new VIN());
            }
            catch (RemoveVehicleException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
