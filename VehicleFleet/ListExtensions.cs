using System.Collections.Generic;
using VehicleFleet.Vehicles.Vehicles;

namespace VehicleFleet
{
    static class ListExtensions
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

            throw new GetVehicleByParametrException($"Vehicles in vehicles collection don't have parameter {parameter} with given value \"{value}\"");
        }
    }
}
