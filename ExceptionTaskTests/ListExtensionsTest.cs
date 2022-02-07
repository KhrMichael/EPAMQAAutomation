using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using VehicleFleet;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;
using VehicleFleet.Vehicles.Vehicles;

namespace ExceptionTaskTests
{
    [TestClass]
    public class ListExtensionsTest
    {
        private const string vehiclesListPath = "VehiclesList.xml";

        private static IEnumerable<object[]> IncorrectParametersForAddVehicle
        {
            get
            {
                return new[]
                {
                   new object[]{ new Bus( new Engine( 300, 3, "electical", "234234"), new Chassis(4, "344548DKU", 200.25), new Transmission("auto", 6, "Transmission Inc."), color: "Impossible color")}
                };
            }
        }
        private static IEnumerable<object[]> IncorrectParametersForGetVehicleByParameter
        {
            get
            {
                return new[]
                {
                    new object[]{ "parameter", string.Empty},
                    new object[]{ "Engine", new Engine(double.MaxValue, double.MinValue, string.Empty, string.Empty)},
                    new object[]{ "Driver", "The best"}
                };
            }
        }
        private static IEnumerable<object[]> IncorrectParametersForUpdateVehicle
        {
            get
            {
                return new[]
                {
                    new object[]{ new VIN(), null},
                    new object[]{ new VIN(), null},
                    new object[]{ new VIN(), null}
                };
            }
        }
        private static IEnumerable<object[]> IncorrectParametersForRemoveVehicle
        {
            get
            {
                return new[]
                {
                    new object[]{ new VIN()},
                    new object[]{ new VIN()},
                    new object[]{ new VIN()}
                };
            }
        }

        private List<Vehicle> Vehicles
        {
            get
            {
                var xmlSerializer = new DataContractSerializer(typeof(List<Vehicle>));
                List<Vehicle> vehicles;

                using (FileStream vehiclesListXmlFileStream = new FileStream(vehiclesListPath, FileMode.Open))
                {
                    vehicles = (List<Vehicle>)xmlSerializer.ReadObject(vehiclesListXmlFileStream);
                }

                return vehicles;
            }
        }


        [TestMethod]
        [DynamicData("IncorrectParametersForAddVehicle")]
        public void AddVehicle_ThrowAddException_ForIncorrectInputValues(Vehicle vehicle)
        {
            List<Vehicle> vehicles = Vehicles;
            Action testAddVehicle = () => vehicles.AddVehicle(vehicle);

            Assert.ThrowsException<AddException>(testAddVehicle);
        }

        [TestMethod]
        [DynamicData("IncorrectParametersForGetVehicleByParameter")]
        public void GetVehicleByParameter_ThrowGetVehicleByParameterException_ForIncorrectValues(string parameter, object value)
        {
            List<Vehicle> vehicles = Vehicles;
            Action testGetVehicleByParameter = () => vehicles.GetVehicleByParameter(parameter, value.ToString());

            Assert.ThrowsException<GetVehicleByParametrException>(testGetVehicleByParameter);
        }

        [TestMethod]
        [DynamicData("IncorrectParametersForUpdateVehicle")]
        public void UpdateVehicle_ThrowUpdateVehicleException_ForIncorrectParameters(VIN vin, Vehicle vehicle)
        {
            List<Vehicle> vehicles = Vehicles;
            Action testVehicleUpdate = () => vehicles.Update(vin, vehicle);

            Assert.ThrowsException<UpdateVehicleException>(testVehicleUpdate);
        }

        [TestMethod]
        [DynamicData("IncorrectParametersForRemoveVehicle")]
        public void RemoveVehicle_ThrowRemoveVehicleException_ForIncorrectParameter(VIN vin)
        {
            List<Vehicle> vehicles = Vehicles;
            Action testRemoveVehcle = () => vehicles.Remove(vin);

            Assert.ThrowsException<RemoveVehicleException>(testRemoveVehcle);
        }

    }
}
