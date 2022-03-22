using System.Collections.Generic;
using ObjectOrientedDesignPrinciplesTask.Vehicles;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet;

namespace ObjectOrientedDesignPrinciplesTaskTest;

public class VehiclesFleetData
{
    public VehiclesFleet Fleet => new VehiclesFleet()
    {
        Vehicles = new List<Vehicle>()
        {
            new Vehicle("volvo", "A23", 10000, 100.25),
            new Vehicle("volvo", "A3", 15000, 10025),
            new Vehicle("volvo", "A2", 1000, 1025),
            new Vehicle("subaru", "S15", 100, 100000),
            new Vehicle("subaru", "S1", 100000, 2000),
        }
    };
}