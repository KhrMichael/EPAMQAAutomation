using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Task4.Vehicles.Vehicles;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            VehiclesCollectionGenerator collectionGenerator = new VehiclesCollectionGenerator();
            collectionGenerator.TryFillVehicleCollection(out List<Vehicle> vehicles);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));
            using (FileStream fs = new FileStream("vehicles_with_engine_displacement_more_then_1_5.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, vehicles.Where(vh => vh.Engine.Displacement > 1.5).ToList());
            }
            using (FileStream fs = new FileStream("vehicles_by_transmission_type.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, vehicles.OrderBy(vh => vh.Transmission.Type).ToList());
            }
            xmlSerializer = new XmlSerializer(typeof(List<EngineTuple>));
            using (FileStream fs = new FileStream("bus_and_truck_info.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, vehicles.Where(vh => vh.GetType() == typeof(Truck) || vh.GetType() == typeof(Bus))
                    .Select(vh => new EngineTuple() { Type = vh.Engine.Type, SerialNumber = vh.Engine.SerialNumber, Power = vh.Engine.Power })
                    .ToList());
            }
        }
    }
}
