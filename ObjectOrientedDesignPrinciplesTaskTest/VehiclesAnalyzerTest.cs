using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOrientedDesignPrinciplesTask;
using ObjectOrientedDesignPrinciplesTask.Vehicles;
using System.Collections.Generic;

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
        [DataRow(CommandTypes.CountAll, "21000")]
        [DataRow(CommandTypes.AveragePrice, "168")]
        [DataRow(CommandTypes.AveragePriceType, "184.72", "Volvo")]
        [DataRow(CommandTypes.CountTypes, "2")]
        public void Action_VehiclesAnalysisCommand_ValidMessage(CommandTypes command, string expectedMessage, params object[] parameters)
        {
            VehiclesAnalyzer vehiclesAnalyzer = new VehiclesAnalyzer() { Vehicles = Vehicles };

            vehiclesAnalyzer.Action(command, parameters);

            Assert.AreEqual(expectedMessage, vehiclesAnalyzer.Message);
        }

        [TestMethod]
        public void Action_HelpCommand_ValidHelpMessage()
        {
            VehiclesAnalyzer vehiclesAnalyzer = new VehiclesAnalyzer() { Vehicles = Vehicles };
            string expectedMessage = "count types - number of car stemps\ncount all - total number of vehicles\naverage price - average vehicle price\naverage price [type] - average price of each type, such as average price volvo\nexit - exit.";

            vehiclesAnalyzer.Action(CommandTypes.Help);

            Assert.AreEqual(expectedMessage, vehiclesAnalyzer.Message);
        }
    }
}
