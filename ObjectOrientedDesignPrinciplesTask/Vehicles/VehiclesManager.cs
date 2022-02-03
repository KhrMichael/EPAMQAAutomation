using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class VehiclesManager
    {
        protected static VehiclesManager manager;

        private VehiclesAnalyzer VehiclesAnalyzer { get; set; }
        private Invoker Invoker { get; set; }
        private List<Vehicle> Vehicles { get; set; }

        protected VehiclesManager()
        {
            VehiclesAnalyzer = new VehiclesAnalyzer();
            Invoker = new Invoker();
            Vehicles = new List<Vehicle>();
        }

        public static VehiclesManager Instance()
        {
            return manager != null ? manager : manager = new VehiclesManager();
        }

        public void Start()
        {
            ReceiveVehiclesData();
            Invoker.StoreCommand(new Help(VehiclesAnalyzer));
            Invoker.ExecuteCommand();
            Console.WriteLine(VehiclesAnalyzer.CommandResult);
        }

        private void ReceiveVehiclesData()
        {
            Console.WriteLine("Enter vehicle information as \"[type], [model], [number], [price]\"");
            string vehiclesData = Console.ReadLine();
            vehiclesData = String.Concat(vehiclesData.Where(symblol => !char.IsWhiteSpace(symblol)));

            string vehicelceDataPattern = "\\\"\\w+[,]\\w+[,]\\d+[,]\\d+[.]?\\d*\\\"";
            Regex regex = new Regex(vehicelceDataPattern);

            foreach (Match vehicleData in regex.Matches(vehiclesData))
            {
                VehicleDataParse(vehicleData.Value);
            }
        }

        private void VehicleDataParse(string vehicleData)
        {
            vehicleData = vehicleData.Trim('"');
            string[] vehicleParameters = vehicleData.Split(',');
            Vehicle vehicle = new Vehicle()
            {
                Type = vehicleParameters[0],
                Model = vehicleParameters[1],
                Quantity = uint.Parse(vehicleParameters[2]),
                Price = double.Parse(vehicleParameters[3], CultureInfo.InvariantCulture)
            };

            Vehicles.Add(vehicle);
        }
    }
}
