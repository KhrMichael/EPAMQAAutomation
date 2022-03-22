using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;
using ObjectOrientedDesignPrinciplesTaskTest.Doubles;

namespace ObjectOrientedDesignPrinciplesTaskTest;

[TestClass]
public class AveragePriceTypeTest
{
    [TestMethod]
    [DataRow("volvo", 5861.63)]
    [DataRow("subaru", 2097.90)]
    public void Execute_StringWithType_InResultStoredAveragePriceForType(string type, double expectedAveragePrise)
    {
        var vehiclesFleet = new VehiclesFleetData().Fleet;
        var vehiclesFleetManager = new VehiclesFleetManager();
        var averagePriceTypeCommand = new AveragePriceType(vehiclesFleet, type);

        vehiclesFleetManager.StoreCommand(averagePriceTypeCommand);
        vehiclesFleetManager.ExecuteCommand();
        var averagePriceTypeCommandResult = averagePriceTypeCommand.Result.ToNumberWithTwoDecimalPlaces();

        Assert.AreEqual(expectedAveragePrise, averagePriceTypeCommandResult);
    }
}