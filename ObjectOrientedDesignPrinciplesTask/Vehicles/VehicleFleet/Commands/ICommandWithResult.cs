using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesignPrinciplesTask.Vehicles.VehicleFleet.Commands
{
    public interface ICommandWithResult<TResult> : ICommand
    {
        TResult Result { get; }
    }
}
