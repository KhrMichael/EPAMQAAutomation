namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class Help : Command
    {
        public Help(VehiclesFleet fleet) : base(fleet)
        {
        }

        public override void Execute()
        {
            Fleet.Action(CommandTypes.Help);
        }
    }
}
