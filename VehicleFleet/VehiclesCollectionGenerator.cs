using System.Collections.Generic;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Vehicles;

namespace VehicleFleet
{
    public class VehiclesCollectionGenerator
    {
        /// <summary>
        /// Fill a collection of vehicles.
        /// </summary>
        /// <param name="vehicles">Collection to fill.</param>
        /// <returns>True if filling succeded.</returns>
        public bool TryFillVehicleCollection(out List<Vehicle> vehicles)
        {
            vehicles = new List<Vehicle>();
            bool success = true;

            try
            {
                FillVehicleCollection(out vehicles);
            }
            catch
            {
                success = false;
            }

            return success;
        }


        /// <summary>
        /// Fills a collection of vehicles.
        /// </summary>
        /// <param name="vehicles">Collection to fill.</param>
        /// <exception cref="AddException"></exception>
        /// <exception cref="InitializationException"></exception>
        public void FillVehicleCollection(out List<Vehicle> vehicles)
        {
            vehicles = new List<Vehicle>();
            VehicleCreator vehicleCreator = new CarCreator();

            vehicles.Add(vehicleCreator.Create());
            vehicles.Add(vehicleCreator.Create());
            vehicles.Add(vehicleCreator.Create());

            vehicleCreator = new BusCreator();

            vehicles.Add(vehicleCreator.Create());
            vehicles.Add(vehicleCreator.Create());
            vehicles.Add(vehicleCreator.Create());

            vehicleCreator = new TruckCreator();

            vehicles.Add(vehicleCreator.Create());
            vehicles.Add(vehicleCreator.Create());

            vehicleCreator = new ScooterCreator();

            vehicles.Add(vehicleCreator.Create());
        }
    }
}
