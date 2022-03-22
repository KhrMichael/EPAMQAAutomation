using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public abstract class VehicleFleetCommand : ICommand
    {
        public VehiclesFleet Fleet { get; }

        protected VehicleFleetCommand(VehiclesFleet fleet)
        {
            Fleet = fleet;
        }

        void ICommand.Execute() => Execute();
        protected abstract void Execute();

        void ICommand.Undo() => Undo();

        protected abstract void Undo();
    }
}
