using ObjectOrientedDesignPrinciplesTask.Vehicles;
namespace ObjectOrientedDesignPrinciplesTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehiclesManager = VehiclesManager.Instance();
            vehiclesManager.Start();
        }
    }
}
