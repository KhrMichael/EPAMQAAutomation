using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedDesignPrinciplesTask.Vehicles;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;

namespace ObjectOrientedDesignPrinciplesTaskTest;

[TestClass]
public class AveragePriceTest
{

    [TestMethod]
    public void Execute_Nothig_InResultStoredAveragePrice()
    {
        var vehiclesFleet = new VehiclesFleetData().Fleet;
;
        var vehiclesFleetManager = new VehiclesFleetManager();
        var averagePriceCommand = new AveragePrice(vehiclesFleet);
        var expectedResult = 22630.05;

        vehiclesFleetManager.StoreCommand(averagePriceCommand);
        vehiclesFleetManager.ExecuteCommand();

        Assert.AreEqual(expectedResult, averagePriceCommand.Result);
    }
    
}