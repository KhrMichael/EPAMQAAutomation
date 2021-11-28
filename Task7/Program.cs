using System;
using System.Collections.Generic;
using Task4.Vehicles.Vehicles;
using Task4.Vehicles.Parts;
using Task4.Vehicles.AdditionalParts;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Truck(GenerateEngine("Electrical"), GenerateChassis(), GenerateTransmission("Manual")));
        }


        /// <summary>
        /// Fills the collection with vehicles.
        /// </summary>
        /// <param name="vehicles">Collection to fill.</param>
        /// <param name="length">Length of collection.</param>
        static void FillVehicleCollection(out List<Vehicle> vehicles)
        {
            vehicles = new List<Vehicle>();
        }

        /// <summary>
        /// Generates new engine with given engine type.
        /// </summary>
        /// <param name="type">Engine type.</param>
        /// <returns>New Engine.</returns>
        static Engine GenerateEngine(string type)
        {
            Random rnd = new Random();
            double capacity = rnd.NextDouble() * 199 + 1;// engine capacity from 1 to 200 horespower
            double displacement = rnd.NextDouble() * 4 + 1;// engine displacement from 1 to 5 litre
            string serialNumber = (rnd.NextDouble() * rnd.Next()).ToString();
            return new Engine(capacity, displacement, type, serialNumber);
        }

        /// <summary>
        /// Generates new Chassis.
        /// </summary>
        /// <returns>New Chassis.</returns>
        static Chassis GenerateChassis()
        {
            Random rnd = new Random();
            int wheelNumber = (rnd.Next() % 5 + 1) * 2;// wheel number from 2 to 10 
            string number = (rnd.NextDouble() * rnd.Next()).ToString();
            double permissibleLoad = wheelNumber * 250.25;
            return new Chassis(wheelNumber, number, permissibleLoad);
        }
        /// <summary>
        /// Generates new Transmission.
        /// </summary>
        /// <param name="type">Transmission type.</param>
        /// <param name="manufacturer">Transmission manufacturer.</param>
        /// <returns>New Transmission.</returns>
        static Transmission GenerateTransmission(string type, string manufacturer = "Transmission INC")
        {
            int transmissionNumber = new Random().Next() % 6 + 1; //transmission number from 1 to 6
            return new Transmission(type, transmissionNumber, manufacturer);
        }
    }
}
