using System;

namespace ObjectOrientedDesignPrinciplesTask.VehiclesManager
{
    public class AveragePrice : Command
    {
        public AveragePrice(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
