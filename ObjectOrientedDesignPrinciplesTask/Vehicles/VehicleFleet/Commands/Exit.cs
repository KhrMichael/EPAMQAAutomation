namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public class Exit : VehicleFleetCommand
    {
        public Exit(VehiclesFleet fleet) : base(fleet)
        { }

        protected override void Execute()
        {
            Fleet.Action(CommandTypes.Exit);
        }

        protected override void Undo()
        { }
    }
}
