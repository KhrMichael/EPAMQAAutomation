using System;
using System.Collections.Generic;
using VehicleFleet;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Vehicles;

namespace SeventhTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string busAndTruckFilePath = "bus_and_truck_info.xml";
            string engineDisplacementSortedVehiclesFilePath = "vehicles_with_engine_displacement_more_then_1_5.xml";
            string transmissionSortedVehiclesFilePath = "vehicles_by_transmission_type.xml";
            var vehicles = new List<Vehicle>();
            var collectionGenerator = new VehiclesCollectionGenerator();

            try
            {
                collectionGenerator.TryFillVehicleCollection(out vehicles);
            }
            catch (InitializationException initializationException)
            {
                Console.WriteLine(initializationException.Message);
            }
            catch (AddException addException)
            {
                Console.WriteLine(addException.Message);
            }

            var vehiclesXmlSerializer = new VehiclesXmlSerializer();

            vehiclesXmlSerializer.BusAndTruckSerialize(vehicles, busAndTruckFilePath);
            vehiclesXmlSerializer.EngineDisplacementSortedSerialize(vehicles, engineDisplacementSortedVehiclesFilePath);
            vehiclesXmlSerializer.TransmissionSortedSerialize(vehicles, transmissionSortedVehiclesFilePath);

            try
            {
                vehicles.GetVehicleByParameter("parameter", "value");
            }
            catch (GetVehicleByParametrException parameterException)
            {
                Console.WriteLine(parameterException.Message);
            }
        }
    }
}
