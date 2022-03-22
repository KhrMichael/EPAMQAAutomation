using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;

namespace ObjectOrientedDesignPrinciplesTaskTest;

[TestClass]
public class CountTypesTest
{
    [TestMethod]
    public void Execute_Nothing_InResultStoredNumberOfTypes()
    {
        var vehiclesFleet = new VehiclesFleetData().Fleet;
        var vehiclesFleetManager = new VehiclesFleetManager();
        var countTypesCommand = new CountTypes(vehiclesFleet);
        var expectedResult = 2;

        vehiclesFleetManager.StoreCommand(countTypesCommand);
        vehiclesFleetManager.ExecuteCommand();

        Assert.AreEqual(expectedResult, countTypesCommand.Result);
    }
    
}