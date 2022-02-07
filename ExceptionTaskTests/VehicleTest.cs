using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VehicleFleet.Vehicles.Exceptions;
using VehicleFleet.Vehicles.Parts;
using VehicleFleet.Vehicles.Vehicles;

namespace ExceptionTaskTests
{
    [TestClass]
    public class VehicleTest
    {
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

        [TestMethod]
        [DynamicData("ActionsWithIncorrectVehiclesInitialization")]
        public void VehicleThrowInitializationExceptionForIncorectInputValues(Action testVehicleInitialization)
        {
            Assert.ThrowsException<InitializationException>(testVehicleInitialization);
        }

    }
}
