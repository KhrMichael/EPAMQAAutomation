namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class AveragePriceType : Command
    {
        public string Type { get; set; }

        public AveragePriceType(VehiclesFleet fleet) : base(fleet)
        {
        }

        public override void Execute()
        {
            Fleet.Action(CommandTypes.AveragePriceType, Type);
        }
    }
}
