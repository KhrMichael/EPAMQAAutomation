namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class CountAll : Command
    {
        public CountAll(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            analyzer.Action(CommandTypes.CountAll);
        }
    }
}
