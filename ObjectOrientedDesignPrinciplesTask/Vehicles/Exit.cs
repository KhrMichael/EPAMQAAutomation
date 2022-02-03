namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class Exit : Command
    {
        public Exit(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            analyzer.Action(CommandTypes.Exit);
        }
    }
}
