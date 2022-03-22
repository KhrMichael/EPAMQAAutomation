using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedDesignPrinciplesTask;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;
using System.Collections.Generic;
using ObjectOrientedDesignPrinciplesTask.Vehicles;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet;

namespace ObjectOrientedDesignPrinciplesTaskTest
{
    [TestClass]
    public class VehiclesAnalyzerTest
    {
        private List<Vehicle> Vehicles
        {
            get
            {
                return new List<Vehicle>
                {
                    new Vehicle(){ Type = "Volvo", Model = "S60", Price = 124.44, Quantity= 10000},
                    new Vehicle(){ Type = "Volvo", Model = "S30", Price = 245.0, Quantity = 10000},
                    new Vehicle(){ Type = "Toyota", Model= "Camry", Price = 134.56, Quantity = 1000}
                };
            }
        }
        
        [TestMethod]
        public void Action_ExitCommand_ExitIsTrue()
        {
            var vehiclesAnalyzer = new VehiclesFleet() { Vehicles = Vehicles };

            vehiclesAnalyzer.Action(CommandTypes.Exit);

            Assert.IsTrue(vehiclesAnalyzer.Exit);
        }
    }
}
