namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class AveragePrice : Command
    {
        public AveragePrice(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            analyzer.Action(CommandTypes.AveragePrice);
        }
    }
}
