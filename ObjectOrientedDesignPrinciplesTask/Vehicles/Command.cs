namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public abstract class Command
    {
        protected VehiclesAnalyzer analyzer;

        public Command(VehiclesAnalyzer analyzer)
        {
            this.analyzer = analyzer;
        }

        public abstract void Execute();
    }
}
