namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class CountAll : Command
    {
        public CountAll(VehiclesFleet fleet) : base(fleet)
        {
        }

        public override void Execute()
        {
            Fleet.Action(CommandTypes.CountAll);
        }
    }
}
