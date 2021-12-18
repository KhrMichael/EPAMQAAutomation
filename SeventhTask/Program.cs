using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using VehicleFleet;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Vehicles;

namespace Task7
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
            catch(InitializationException initializationException)
            {
                System.Console.WriteLine(initializationException.Message);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));

            using (FileStream fileStream = new FileStream(engineDisplacementSortedVehiclesFilePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, vehicles.Where(vehicle => vehicle.Engine.Displacement > 1.5).ToList());
            }
            using (FileStream fileStream = new FileStream(transmissionSortedVehiclesFilePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, vehicles.OrderBy(vehicle => vehicle.Transmission.Type).ToList());
            }
            xmlSerializer = new XmlSerializer(typeof(List<EngineTuple>));
            using (FileStream fileStream = new FileStream(busAndTruckFilePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, vehicles.Where(vh => vh.GetType() == typeof(Truck) || vh.GetType() == typeof(Bus))
                    .Select(vehicle => new EngineTuple() { Type = vehicle.Engine.Type, SerialNumber = vehicle.Engine.SerialNumber, Power = vehicle.Engine.Power })
                    .ToList());
            }
        }
    }
}
