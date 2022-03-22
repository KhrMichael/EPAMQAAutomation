namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public class CountTypes : VehicleFleetCommandWithResult<int>
    {
        public CountTypes(VehiclesFleet fleet) : base(fleet)
        { }

        protected override void Execute()
        {
            Fleet.Action(CommandTypes.CountTypes);
            Result = (int)Fleet.Result;
        }

        protected override void Undo()
        { }
    }
}
