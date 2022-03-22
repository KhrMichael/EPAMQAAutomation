namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public abstract class VehicleFleetCommandWithResult<T> : VehicleFleetCommand, ICommandWithResult<T>
    {
        public T Result { get; protected set; }

        protected VehicleFleetCommandWithResult(VehiclesFleet fleet) : base(fleet)
        { }
    }
}
