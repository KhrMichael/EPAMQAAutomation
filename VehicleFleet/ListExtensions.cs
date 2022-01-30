using System.Collections.Generic;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Vehicles;

namespace VehicleFleet
{
    public static class ListExtensions
    {
        /// <summary>
        /// Find and return first vehicle with given parameter name and it value.
        /// </summary>
        /// <param name="vehicles"></param>
        /// <param name="parameter">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <returns>First vehicle with given parameter name and it value.</returns>
        public static Vehicle GetVehicleByParameter(this List<Vehicle> vehicles, string parameter, string value)
        {
            foreach (var vehicle in vehicles)
            {
                var vehicleType = vehicle.GetType();
                var vehicleProperties = vehicleType.GetProperties();

                foreach (var properyty in vehicleProperties)
                {
                    if (properyty.Name == parameter && properyty.GetValue(vehicle).ToString() == value)
                    {
                        return vehicle;
                    }
                }
            }

            throw new GetVehicleByParametrException($"Vehicles in vehicles collection don't have a parameter \"{parameter}\" with a given value \"{value}\"");
        }

        /// <summary>
        /// Add a vehicle to the list.
        /// </summary>
        /// <param name="vehicles"></param>
        /// <param name="vehicle">Vehicle to add.</param>
        /// <returns></returns>
        public static List<Vehicle> AddVehicle(this List<Vehicle> vehicles, Vehicle vehicle)
        {
            if (vehicle is Bus && ((Bus)vehicle).Color.ToUpperInvariant() == "IMPOSSIBLE COLOR")
            {
                throw new AddException("The list of vehicles can't contain a bus with \"Impossible color\"");
            }

            vehicles.Add(vehicle);

            return vehicles;
        }


        public static void Update(this List<Vehicle> vehicles, VIN identificationNumber, Vehicle newVehicle)
        {
            int index;

            if (identificationNumber != null && (index = vehicles.FindIndex(vh => vh.VehicleIdentificationNumber == identificationNumber)) > 0)
            {
                vehicles[index] = newVehicle;
            }
            else
            {
                throw new UpdateVehicleException($"No vehicle with VIN - {identificationNumber}");
            }
        }
        public static void Remove(this List<Vehicle> vehicles, VIN identificationNumber)
        {
            int index;

            if ((index = vehicles.FindIndex(vh => vh.VehicleIdentificationNumber == identificationNumber)) > 0)
            {
                vehicles.RemoveAt(index);
            }
            else
            {
                throw new RemoveVehicleException($"No vehicle with VIN - {identificationNumber}");
            }
        }

    }
}
