using ObjectOrientedDesignPrinciplesTask.Vehicles.Exceptions;
using System.Collections.Generic;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class CommandsInvoker
    {
        private List<Command> commands;
        private int currentCommand;

        public CommandsInvoker()
        {
            commands = new List<Command>();
            currentCommand = 0;
        }

        public void StoreCommand(Command command)
        {
            commands.Add(command);
        }

        /// <summary>
        /// Executes the next command in the queue.
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
