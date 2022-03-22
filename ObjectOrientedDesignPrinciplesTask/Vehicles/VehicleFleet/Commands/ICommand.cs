namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
