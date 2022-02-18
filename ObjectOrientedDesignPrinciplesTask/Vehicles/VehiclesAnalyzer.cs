using ObjectOrientedDesignPrinciplesTask.Vehicles.Exceptions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class VehiclesAnalyzer
    {
        public string Message { get; private set; }
        public List<Vehicle> Vehicles { get; set; }
        public bool Exit { get; private set; }

        public VehiclesAnalyzer()
        {
            Vehicles = new List<Vehicle>();
        }

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

            Message = types.Count.ToString();
        }

        private void CountAll()
        {
            uint numberOfVehicles = 0;
            foreach (var vehicle in Vehicles)
            {
                numberOfVehicles += vehicle.Quantity;
            }

            Message = numberOfVehicles.ToString();
        }

        private void AveragePrice()
        {
            double totalPrice = 0;
            foreach (var vehicle in Vehicles)
            {
                totalPrice += vehicle.Price;
            }
            double averagePrice = totalPrice / Vehicles.Count;

            Message = averagePrice.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <exception cref="ExecuteCommandException"></exception>
        private void AveragePriceType(string type)
        {
            double totalPrice = 0;
            int numberOfModels = 0;
            double averagePrice = 0;

            if (!Vehicles.Any(vh => vh.Type == type))
            {
                throw new ExecuteCommandException($"There is no such type [{type}].");
            }

            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Type == type)
                {
                    totalPrice += vehicle.Price;
                    numberOfModels++;
                }
            }
            averagePrice = totalPrice / numberOfModels;

            Message = averagePrice.ToString(CultureInfo.InvariantCulture);
        }

        private void Help()
        {
            string helpMessage = "count types - number of car stemps\ncount all - total number of vehicles\naverage price - average vehicle price\naverage price [type] - average price of each type, such as average price volvo\nexit - exit.";

            Message = helpMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <exception cref="ExecuteCommandException"></exception>
        public void Action(CommandTypes commandType, params object[] parameters)
        {
            switch (commandType)
            {
                case CommandTypes.CountTypes:
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
                    Message = string.Empty;
                    break;
            }
        }
    }
}
