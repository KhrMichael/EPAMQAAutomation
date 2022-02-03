using System.Collections.Generic;

namespace ObjectOrientedDesignPrinciplesTask.VehiclesManager
{
    public class VehiclesAnalyzer
    {
        public string CommandResult { get; private set; }
        public List<Vehicle> Vehicles { get; set; }
        public bool Exit { get; private set; }

        private void CountType()
        {
            List<string> types = new List<string>();
            foreach (var vehicle in Vehicles)
            {
                if (!types.Exists(type => type == vehicle.Type))
                {
                    types.Add(vehicle.Type);
                }
            }

            CommandResult = types.Count.ToString();
        }

        private void CountAll()
        {
            uint numberOfVehicles = 0;
            foreach (var vehicle in Vehicles)
            {
                numberOfVehicles += vehicle.Quantity;
            }

            CommandResult = numberOfVehicles.ToString();
        }

        private void AveragePrice()
        {
            double totalPrice = 0;
            double averagePrice;
            foreach (var vehicle in Vehicles)
            {
                totalPrice += vehicle.Price;
            }
            averagePrice = totalPrice / Vehicles.Count;

            CommandResult = averagePrice.ToString();
        }

        private void AveragePriceType(string type)
        {
            double totalPrice = 0;
            double averagePrice;
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Type == type)
                {
                    totalPrice += vehicle.Price;
                }
            }
            averagePrice = totalPrice / Vehicles.Count;

            CommandResult = averagePrice.ToString();
        }

        private void Help()
        {
            string helpMessage = "Count type [t] - number of car stemps\tCount all [a] - total number of vehicles\tAverage price [p] - average vehicle price\tAverage price type [x] - average price of each type, such as average price volvo\tExit[q] - exit.";

            CommandResult = helpMessage;
        }

        public void Action(CommandTypes commandType, params object[] parameters)
        {
            switch (commandType)
            {
                case CommandTypes.CountType:
                    CountType();
                    break;
                case CommandTypes.CountAll:
                    CountAll();
                    break;
                case CommandTypes.AveragePrice:
                    AveragePrice();
                    break;
                case CommandTypes.AveragePriceType:
                    AveragePriceType(parameters[0].ToString());
                    break;
                case CommandTypes.Help:
                    Help();
                    break;
                case CommandTypes.Exit:
                    Exit = true;
                    break;
            }
        }
    }
}
