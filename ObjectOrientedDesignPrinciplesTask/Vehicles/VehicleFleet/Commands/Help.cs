namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public class Help : VehicleFleetCommandWithResult<string>
    {
        public Help(VehiclesFleet fleet) : base(fleet)
        {
        }

        protected override void Execute()
        {
            Fleet.Action(CommandTypes.Help);
            Result = (string)Fleet.Result;
        }

        protected override void Undo()
        { }
    }
}
