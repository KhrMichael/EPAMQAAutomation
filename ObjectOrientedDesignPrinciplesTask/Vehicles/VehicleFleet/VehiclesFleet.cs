using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands.Exceptions;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet
{
    public class VehiclesFleet
    {
        public object Result { get; private set; }
        public List<Vehicle> Vehicles { get; set; }
        public bool Exit { get; private set; }

        public VehiclesFleet()
        {
            Vehicles = new List<Vehicle>();
        }

        private void CountTypes()
        {
            var types = new List<string>();
            foreach (var vehicle in Vehicles)
            {
                if (!types.Exists(type => type == vehicle.Type))
                {
                    types.Add(vehicle.Type);
                }
            }

            Result = types.Count;
        }

        private void CountAll()
        {
            uint numberOfVehicles = 0;
            foreach (var vehicle in Vehicles)
            {
                numberOfVehicles += vehicle.Quantity;
            }

            Result = numberOfVehicles;
        }

        private void AveragePrice()
        {
            var totalPrice = 0.0;
            var vechiclesQuantity = 0u;
            foreach (var vehicle in Vehicles)
            {
                totalPrice += vehicle.Price * vehicle.Quantity;
                vechiclesQuantity += vehicle.Quantity;
            }
            var averagePrice = totalPrice / vechiclesQuantity;

            Result = averagePrice;
        }

        /// <exception cref="ExecuteCommandException"></exception>
        private void AveragePriceType(string type)
        {
            var totalPrice = 0.0;
            var vehiclesQuantity = 0u;

            if (Vehicles.All(vh => vh.Type != type))
            {
                throw new ExecuteCommandException($"Vehicle fleet doesn't have type: [{type}].");
            }

            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Type == type)
                {
                    totalPrice += vehicle.Price * vehicle.Quantity;
                    vehiclesQuantity += vehicle.Quantity;
                }
            }
            var averagePrice = totalPrice / vehiclesQuantity;

            Result = averagePrice;
        }

        private void Help()
        
        {
            var helpMessage = "Available commands:\n" +
                              "count types\n" +
                              "count all\n" +
                              "average price\n" +
                              "average price [type]\n" +
                              "exit";

            Result = helpMessage;
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
                    CountTypes();
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
