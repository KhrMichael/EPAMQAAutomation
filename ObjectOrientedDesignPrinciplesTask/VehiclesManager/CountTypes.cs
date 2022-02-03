using System;

namespace ObjectOrientedDesignPrinciplesTask.VehiclesManager
{
    public class CountTypes : Command
    {
        public CountTypes(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
