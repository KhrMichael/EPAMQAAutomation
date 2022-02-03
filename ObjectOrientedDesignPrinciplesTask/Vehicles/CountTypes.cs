namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class CountTypes : Command
    {
        public CountTypes(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            analyzer.Action(CommandTypes.CountTypes);
        }
    }
}
