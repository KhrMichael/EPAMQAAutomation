namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class AveragePrice : Command
    {
        public AveragePrice(VehiclesFleet fleet) : base(fleet)
        {
        }

        public override void Execute()
        {
            Fleet.Action(CommandTypes.AveragePrice);
        }
    }
}
