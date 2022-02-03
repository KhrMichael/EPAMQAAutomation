using ObjectOrientedDesignPrinciplesTask.VehiclesManager.Exceptions;
using System.Collections.Generic;

namespace ObjectOrientedDesignPrinciplesTask.VehiclesManager
{
    public class Invoker
    {
        private List<Command> commands;
        private int currentCommand;

        public Invoker()
        {
            commands = new List<Command>();
            currentCommand = 0;
        }

        public void StoreCommand(Command command)
        {
            commands.Add(command);
        }

        /// <summary>
        /// Execute next command.
        /// </summary>
        /// <exception cref="ExecuteCommandException"></exception>
        public void ExecuteCommand()
        {
            if (commands.Count <= currentCommand)
            {
                throw new ExecuteCommandException("Nothing to execute.");
            }
            commands[currentCommand].Execute();
            currentCommand++;
        }
    }
}
