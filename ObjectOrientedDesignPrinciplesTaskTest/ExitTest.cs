using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedDesignPrinciplesTask;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;
using System.Collections.Generic;
using ObjectOrientedDesignPrinciplesTask.Vehicles;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet;

namespace ObjectOrientedDesignPrinciplesTaskTest
{
    [TestClass]
    public class ExitTest
    {
        [TestMethod]
        public void Execute_Nothing_ExitIsTrue()
        {
            var vehiclesFleet = new VehiclesFleetData().Fleet;
            var vehiclesFleetManager = new VehiclesFleetManager();
            var exitCommand = new Exit(vehiclesFleet);

            vehiclesFleetManager.StoreCommand(exitCommand);
            vehiclesFleetManager.ExecuteCommand();

            Assert.IsTrue(vehiclesFleet.Exit);
        }
    }
}
