namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public class AveragePriceType : VehicleFleetCommandWithResult<double>
    {
        public string Type { get; }

        public AveragePriceType(VehiclesFleet fleet, string type) : base(fleet)
        {
            Type = type;
        }

        protected override void Execute()
        {
            Fleet.Action(CommandTypes.AveragePriceType, Type);
            Result = (double)Fleet.Result;
        }

        protected override void Undo()
        { }
    }
}
