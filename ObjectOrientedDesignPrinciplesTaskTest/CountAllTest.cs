using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;
using ObjectOrientedDesignPrinciplesTaskTest.Doubles;

namespace ObjectOrientedDesignPrinciplesTaskTest;

[TestClass]
public class CountAllTest
{

    [TestMethod]
    public void Execute_Nothing_InResultCountOfVehicles()
    {
        var vehiclesFleet = new VehiclesFleetData().Fleet;
        var vehiclesFleetManager = new VehiclesFleetManager();
        var countAllCommand = new CountAll(vehiclesFleet);
        var expectedResult = 126100u;

        vehiclesFleetManager.StoreCommand(countAllCommand);
        vehiclesFleetManager.ExecuteCommand();

        Assert.AreEqual(expectedResult, countAllCommand.Result);
    }
}