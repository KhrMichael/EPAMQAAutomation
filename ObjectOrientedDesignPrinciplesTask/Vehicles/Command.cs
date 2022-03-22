namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public abstract class Command
    {
        protected VehiclesFleet Fleet;

        public Command(VehiclesFleet fleet)
        {
            this.Fleet = fleet;
        }

        public abstract void Execute();
    }
}
