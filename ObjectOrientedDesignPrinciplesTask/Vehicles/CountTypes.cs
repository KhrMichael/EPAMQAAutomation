namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class CountTypes : Command
    {
        public CountTypes(VehiclesFleet fleet) : base(fleet)
        {
        }

        public override void Execute()
        {
            Fleet.Action(CommandTypes.CountTypes);
        }
    }
}
