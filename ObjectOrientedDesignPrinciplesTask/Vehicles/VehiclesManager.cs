using ObjectOrientedDesignPrinciplesTask.Vehicles.Exceptions;
using System;
using System.Globalization;
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

        private VehiclesFleet VehiclesFleet { get; }
        private CommandsInvoker Invoker { get; }

        protected VehiclesManager()
        {
            VehiclesFleet = new VehiclesFleet();
            Invoker = new CommandsInvoker();
        }

        public static VehiclesManager Instance() => manager ??= new VehiclesManager();

        public void Start()
        {
            ReceiveVehiclesData();
            ExecuteCommand(new Help(VehiclesFleet));
            Monitor();
        }

        private void Monitor()
        {
            while (!VehiclesFleet.Exit)
            {
                var command = Console.ReadLine()!.Trim();
                switch (command)
                {
                    case countTypesCommand:
                        ExecuteCommand(new CountTypes(VehiclesFleet));
                        break;
                    case countAllCommand:
                        ExecuteCommand(new CountAll(VehiclesFleet));
                        break;
                    case averagePriceCommand:
                        ExecuteCommand(new AveragePrice(VehiclesFleet));
                        break;
                    case exitCommand:
                        ExecuteCommand(new Exit(VehiclesFleet));
                        break;
                    default:
                        if (command.Contains(averagePriceCommand))
                        {
                            //substring with the type of vehicles
                            string type = command.Substring(averagePriceCommand.Length);
                            type = type.Trim();
                            ExecuteCommand(new AveragePriceType(VehiclesFleet) { Type = type });
                        }
                        else
                        {
                            Console.WriteLine("Incorrect command.");
                        }
                        break;
                }
            }
        }

        private void ExecuteCommand(Command command)
        {
            try 
            {
                Invoker.StoreCommand(command);
                Invoker.ExecuteCommand();
                Console.WriteLine(VehiclesFleet.Message);
            }
            catch(ExecuteCommandException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void ReceiveVehiclesData()
        {
            Console.WriteLine("Enter vehicle information as \"[type], [model], [number], [price]\"");
            string vehiclesData = Console.ReadLine();
            vehiclesData = string.Concat(vehiclesData.Where(symblol => !char.IsWhiteSpace(symblol)));

            var vehicelceDataPattern = "\\\"\\w+[,]\\w+[,]\\d+[,]\\d+[.]?\\d*\\\"";//"[type],[model],[number],[price]"
            var regex = new Regex(vehicelceDataPattern);

            foreach (Match vehicleData in regex.Matches(vehiclesData))
            {
                var vehicle = ParseVehicleData(vehicleData.Value);
                VehiclesFleet.Vehicles.Add(vehicle);
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
