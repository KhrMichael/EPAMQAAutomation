using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedDesignPrinciplesTask.Vehicles;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;
using ObjectOrientedDesignPrinciplesTaskTest.Doubles;

namespace ObjectOrientedDesignPrinciplesTaskTest;

[TestClass]
public class AveragePriceTest
{

    [TestMethod]
    public void Execute_Nothig_InResultStoredAveragePrice()
    {
        var vehiclesFleet = new VehiclesFleetData().Fleet;
        var vehiclesFleetManager = new VehiclesFleetManager();
        var averagePriceCommand = new AveragePrice(vehiclesFleet);
        var expectedResult = 2873.92;

        vehiclesFleetManager.StoreCommand(averagePriceCommand);
        vehiclesFleetManager.ExecuteCommand();
        var averagePriceCommandResult = averagePriceCommand.Result.ToNumberWithTwoDecimalPlaces();

        Assert.AreEqual(expectedResult, averagePriceCommandResult);
    }
    
}