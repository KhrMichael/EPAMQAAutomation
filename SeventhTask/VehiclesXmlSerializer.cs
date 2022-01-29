using SeventhTask.XmlSerialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using VehicleFleet.Vehicles.Vehicles;

namespace SeventhTask
{
    public class VehiclesXmlSerializer
    {

        public void BusAndTruckSerialize(List<Vehicle> vehicles, string filePath)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<EngineTuple>));

            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, vehicles.Where(vh => vh.GetType() == typeof(Truck) || vh.GetType() == typeof(Bus))
                    .Select(vehicle => new EngineTuple() { Type = vehicle.Engine.Type, SerialNumber = vehicle.Engine.SerialNumber, Power = vehicle.Engine.Power })
                    .ToList());
            }
        }

        public void EngineDisplacementSortedSerialize(List<Vehicle> vehicles, string filePath)
        {
            var genericListSerializer = new GenericListSerializer<Vehicle>();

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                genericListSerializer.Serialize(fileStream, vehicles.Where(vehicle => vehicle.Engine.Displacement > 1.5).ToList());
            }
        }

        public void TransmissionSortedSerialize(List<Vehicle> vehicles, string filePath)
        {
            var genericListSerializer = new GenericListSerializer<Vehicle>();

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                genericListSerializer.Serialize(fileStream, vehicles.OrderBy(vehicle => vehicle.Transmission.Type).ToList());
            }
        }
    }
}
