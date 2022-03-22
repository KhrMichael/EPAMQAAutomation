namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public class CountAll : VehicleFleetCommandWithResult<uint>
    {
        public CountAll(VehiclesFleet fleet) : base(fleet)
        { }

        protected override void Execute()
        {
            Fleet.Action(CommandTypes.CountAll);
            Result = (uint)Fleet.Result;
        }

        protected override void Undo()
        { }
    }
}
