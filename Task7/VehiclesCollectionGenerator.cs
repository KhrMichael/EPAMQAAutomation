using System;
using System.Collections.Generic;
using Task4.Vehicles.AdditionalParts;
using Task4.Vehicles.Parts;
using Task4.Vehicles.Vehicles;

namespace Task7
{
    public class VehiclesCollectionGenerator
    {
        /// <summary>
        /// Fills the collection with vehicles.
        /// </summary>
        /// <param name="vehicles">Collection to fill.</param>
        /// <param name="length">Length of collection.</param>
        public void TryFillVehicleCollection(out List<Vehicle> vehicles)
        {
            vehicles = new List<Vehicle>();
            try
            {
                vehicles.Add(new Truck(GenerateEngine("Electrical"), GenerateChassis(), GenerateTransmission("Manual"), TrailerType.RefrigeratedTrailer));
                vehicles.Add(new Truck(GenerateEngine("Electrical"), GenerateChassis(), GenerateTransmission("Auto")));
                vehicles.Add(new Car(GenerateEngine("Electrical"), GenerateChassis(), GenerateTransmission("Manual"), 6));
                vehicles.Add(new Car(GenerateEngine("Electrical"), GenerateChassis(), GenerateTransmission("Auto")));
                vehicles.Add(new Car(GenerateEngine("Electrical"), GenerateChassis(), GenerateTransmission("Auto"), 9));
                vehicles.Add(new Car(GenerateEngine("Electrical"), GenerateChassis(), GenerateTransmission("Auto"), 6));
                vehicles.Add(new Bus(GenerateEngine("Thermal"), GenerateChassis(), GenerateTransmission("Manual"), "red"));
                vehicles.Add(new Scooter(GenerateEngine("Electrical"), GenerateChassis(), GenerateTransmission("Manual"), true));
            }
            catch
            {

            }
        }

        /// <summary>
        /// Generates new engine with given engine type.
        /// </summary>
        /// <param name="type">Engine type.</param>
        /// <returns>New Engine.</returns>
        static Engine GenerateEngine(string type)
        {
            Random rnd = new Random();
            double power = rnd.NextDouble() * 199 + 1;// engine capacity from 1 to 200 horespower
            double displacement = rnd.NextDouble() * 4 + 1;// engine displacement from 1 to 5 litre
            string serialNumber = (rnd.NextDouble() * rnd.Next()).ToString();
            return new Engine(power, displacement, type, serialNumber);
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
