namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public class AveragePrice : VehicleFleetCommandWithResult<double>
    {
        public AveragePrice(VehiclesFleet fleet) : base(fleet)
        { }

        protected override void Execute()
        {
            Fleet.Action(CommandTypes.AveragePrice);
            Result = (double)Fleet.Result;
        }

        protected override void Undo()
        { }
    }
}
