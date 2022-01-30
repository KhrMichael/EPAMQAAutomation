using SeventhTask.XmlSerialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using VehicleFleet.Vehicles.Vehicles;

namespace SeventhTask
{
    public class VehiclesXmlSerializer
    {
        private DataContractSerializer xmlSerializer;

        public void BusAndTruckSerialize(List<Vehicle> vehicles, string filePath)
        {
            xmlSerializer = new DataContractSerializer(typeof(List<EngineTuple>));
            using (var xmlWriter = XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }))
            {
                xmlSerializer.WriteObject(xmlWriter, vehicles.Where(vh => vh.GetType() == typeof(Truck) || vh.GetType() == typeof(Bus))
                    .Select(vehicle => new EngineTuple() { Type = vehicle.Engine.Type, SerialNumber = vehicle.Engine.SerialNumber, Power = vehicle.Engine.Power })
                    .ToList());
            }
        }

        public void EngineDisplacementSortedSerialize(List<Vehicle> vehicles, string filePath)
        {
            xmlSerializer = new DataContractSerializer(typeof(List<Vehicle>));
            using (var xmlWriter = XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }))
            {
                xmlSerializer.WriteObject(xmlWriter, vehicles.Where(vehicle => vehicle.Engine.Displacement > 1.5).ToList());
            }
        }

        public void TransmissionSortedSerialize(List<Vehicle> vehicles, string filePath)
        {
            xmlSerializer = new DataContractSerializer(typeof(List<Vehicle>));
            using (var xmlWriter = XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }))
            {
                xmlSerializer.WriteObject(xmlWriter, vehicles.OrderBy(vehicle => vehicle.Transmission.Type).ToList());
            }
        }
    }
}
