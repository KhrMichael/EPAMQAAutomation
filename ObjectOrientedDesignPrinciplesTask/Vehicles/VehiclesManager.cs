using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class VehiclesManager
    {
        protected static VehiclesManager manager;

        private const string countTypesCommand = "count types";
        private const string countAllCommand = "count all";
        private const string averagePriceCommand = "average price";
        private const string exitCommand = "exit";

        private VehiclesAnalyzer VehiclesAnalyzer { get; set; }
        private CommandsInvoker Invoker { get; set; }

        protected VehiclesManager()
        {
            VehiclesAnalyzer = new VehiclesAnalyzer();
            Invoker = new CommandsInvoker();
        }

        public static VehiclesManager Instance()
        {
            return manager != null ? manager : manager = new VehiclesManager();
        }

        public void Start()
        {
            ReceiveVehiclesData();
            ExecuteCommand(new Help(VehiclesAnalyzer));
            Monitor();
        }

        private void Monitor()
        {
            while (!VehiclesAnalyzer.Exit)
            {
                try
                {
                    var command = Console.ReadLine().Trim();
                    switch (command)
                    {
                        case countTypesCommand:
                            ExecuteCommand(new CountTypes(VehiclesAnalyzer));
                            break;
                        case countAllCommand:
                            ExecuteCommand(new CountAll(VehiclesAnalyzer));
                            break;
                        case averagePriceCommand:
                            ExecuteCommand(new AveragePrice(VehiclesAnalyzer));
                            break;
                        case exitCommand:
                            ExecuteCommand(new Exit(VehiclesAnalyzer));
                            break;
                        default:
                            if (command.Contains(averagePriceCommand))
                            {
                                string type = command.Substring(averagePriceCommand.Length);
                                type = type.Trim();
                                ExecuteCommand(new AveragePriceType(VehiclesAnalyzer) { Type = type });
                            }
                            else
                            {
                                Console.WriteLine("Incorrect command.");
                            }
                            break;
                    }
                }
                catch (IOException)
                {
                }

            }
        }

        private void ExecuteCommand(Command command)
        {
            Invoker.StoreCommand(command);
            Invoker.ExecuteCommand();
            Console.WriteLine(VehiclesAnalyzer.CommandResult);
        }

        private void ReceiveVehiclesData()
        {
            Console.WriteLine("Enter vehicle information as \"[type], [model], [number], [price]\"");
            string vehiclesData = Console.ReadLine();
            vehiclesData = string.Concat(vehiclesData.Where(symblol => !char.IsWhiteSpace(symblol)));

            string vehicelceDataPattern = "\\\"\\w+[,]\\w+[,]\\d+[,]\\d+[.]?\\d*\\\"";
            Regex regex = new Regex(vehicelceDataPattern);

            foreach (Match vehicleData in regex.Matches(vehiclesData))
            {
                var vehicle = ParseVehicleData(vehicleData.Value);
                VehiclesAnalyzer.Vehicles.Add(vehicle);
            }
        }

        private Vehicle ParseVehicleData(string vehicleData)
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

            return vehicle;
        }
    }
}
