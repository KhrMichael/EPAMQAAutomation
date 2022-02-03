namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class AveragePriceType : Command
    {
        public string Type { get; set; }

        public AveragePriceType(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            analyzer.Action(CommandTypes.AveragePriceType, Type);
        }
    }
}
