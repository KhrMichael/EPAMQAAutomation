namespace ObjectOrientedDesignPrinciplesTask.VehiclesManager
{
    public abstract class Command
    {
        private VehiclesAnalyzer analyzer;

        public Command(VehiclesAnalyzer analyzer)
        {
            this.analyzer = analyzer;
        }

        public abstract void Execute();
    }
}
