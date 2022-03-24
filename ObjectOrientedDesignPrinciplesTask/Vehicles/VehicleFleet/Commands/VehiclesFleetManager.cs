using System;
using System.Collections.Generic;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands;
using ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands.Exceptions;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public class VehiclesFleetManager
    {
        private List<ICommand> commands;
        private int currentCommand;

        public VehiclesFleetManager()
        {
            commands = new List<ICommand>();
            currentCommand = 0;
        }

        public void StoreCommand(VehicleFleetCommand command)
        {
            commands.Add(command);
        }

        /// <exception cref="ExecuteCommandException"></exception>
        public void ExecuteCommand()
        {
            if (commands.Count <= currentCommand)
            {
                throw new ExecuteCommandException("Nothing to execute.");
            }
            try
            {
                commands[currentCommand].Execute();
                currentCommand++;
            }
            catch (ExecuteCommandException)
            {
                commands.RemoveAt(currentCommand);
                throw;
            }
        }
    }
}
