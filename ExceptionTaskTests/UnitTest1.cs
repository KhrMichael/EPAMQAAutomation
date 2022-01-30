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
    public class UnitTest1
    {
        private const string vehiclesListPath = "VehiclesList.xml";

        private static IEnumerable<object[]> ActionsWithIncorrectVehiclesInitialization
        {
            get
            {
                return new[]
                {
                    new object[]{ new Action(() => new Truck(new Engine(220, 4.3, "electrical", "34347910DFS"), null, null)) },
                    new object[]{ new Action(() => new Scooter(null, new Chassis(4, "344548DKU", 200.25), null))},
                    new object[]{ new Action(() => new Bus(new Engine(12, 4.3, "electrical", "3253880LPK"), null, null)) },
                };
            }
        }
        private static IEnumerable<object[]> IncorrectParametersForAddVehicle
        {
            get
            {
                return new[]
                {
                   new object[]{ new Bus(null, null, null, "Impossible color")}
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
        [DynamicData("ActionsWithIncorrectVehiclesInitialization")]
        public void VehicleThrowInitializationExceptionForIncorectInputValues(Action testVehicleInitialization)
        {
            Assert.ThrowsException<InitializationException>(testVehicleInitialization);
        }

        [TestMethod]
        [DynamicData("IncorrectParametersForAddVehicle")]
        public void AddVehicleThrowAddExceptionForIncorrectInputValues(Vehicle vehicle)
        {
            List<Vehicle> vehicles = Vehicles;
            Action testAddVehicle = () => vehicles?.AddVehicle(vehicle);

            Assert.ThrowsException<AddException>(testAddVehicle);
        }

        [TestMethod]
        [DynamicData("IncorrectParametersForGetVehicleByParameter")]
        public void GetVehicleByParameterThrowGetVehicleByParameterExceptionForIncorrectValues(string parameter, object value)
        {
            List<Vehicle> vehicles = Vehicles;
            Action testGetVehicleByParameter = () => vehicles?.GetVehicleByParameter(parameter, value.ToString());

            Assert.ThrowsException<GetVehicleByParametrException>(testGetVehicleByParameter);
        }
    }
}
