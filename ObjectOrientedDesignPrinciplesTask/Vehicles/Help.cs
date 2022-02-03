namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class Help : Command
    {
        public Help(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            analyzer.Action(CommandTypes.Help);
        }
    }
}
