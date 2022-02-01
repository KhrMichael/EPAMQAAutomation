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
                    new object[]{ new Action(() => new Truck(new Engine(220, 4.3, "electrical", "34347910DFS"), new Chassis(6, "3434", 12000), new Transmission("auto", 6, "Transmission Inc."))) },
                    new object[]{ new Action(() => new Scooter(new Engine(220, 4.3, "electrical", "34347910DFS"), new Chassis(4, "344548DKU", 200.25), new Transmission("auto", 6, "Transmission Inc.")))},
                    new object[]{ new Action(() => new Bus(new Engine(12, 4.3, "electrical", "3253880LPK"), new Chassis(4, "344548DKU", 200.25), new Transmission("auto", 6, "Transmission Inc."))) },
                };
            }
        }
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

        [TestMethod]
        [DynamicData("IncorrectParametersForUpdateVehicle")]
        public void UpdateVehicleThrowUpdateVehicleExceptionForIncorrectParameters(VIN vin, Vehicle vehicle)
        {
            List<Vehicle> vehicles = Vehicles;
            Action testVehicleUpdate = () => vehicles.Update(vin, vehicle);

            Assert.ThrowsException<UpdateVehicleException>(testVehicleUpdate);
        }

        [TestMethod]
        [DynamicData("IncorrectParametersForRemoveVehicle")]
        public void RemoveVehicleThrowRemoveVehicleExceptionForIncorrectParameter(VIN vin)
        {
            List<Vehicle> vehicles = Vehicles;
            Action testRemoveVehcle = () => vehicles.Remove(vin);

            Assert.ThrowsException<RemoveVehicleException>(testRemoveVehcle);
        }

    }
}
