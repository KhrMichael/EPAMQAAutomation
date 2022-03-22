namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class Exit : Command
    {
        public Exit(VehiclesFleet fleet) : base(fleet)
        {
        }

        public override void Execute()
        {
            Fleet.Action(CommandTypes.Exit);
        }
    }
}
