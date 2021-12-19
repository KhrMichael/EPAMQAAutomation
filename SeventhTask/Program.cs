using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
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
            List<Vehicle> vehicles = new List<Vehicle>();
            VehiclesCollectionGenerator collectionGenerator = new VehiclesCollectionGenerator();

            try
            {
                collectionGenerator.FillVehicleCollection(out vehicles);
            }
            catch (InitializationException initializationException)
            {
                Console.WriteLine(initializationException.Message);
            }
            catch (AddException addException)
            {
                Console.WriteLine(addException.Message);
            }

            VehiclesXmlSerializer vehiclesXmlSerializer = new VehiclesXmlSerializer();

            vehiclesXmlSerializer.BusAndTruckSerialize(vehicles, busAndTruckFilePath);
            vehiclesXmlSerializer.EngineDisplacementSortedSerialize(vehicles, engineDisplacementSortedVehiclesFilePath);
            vehiclesXmlSerializer.TransmissionSortedSerialize(vehicles, transmissionSortedVehiclesFilePath);

            try
            {
                vehicles.GetVehicleByParameter("parameter", "value");
            }
            catch(GetVehicleByParametrException parameterException)
            {
                Console.WriteLine(parameterException.Message);
            }
        }
    }
}
