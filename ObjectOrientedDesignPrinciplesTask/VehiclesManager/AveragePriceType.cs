using System;

namespace ObjectOrientedDesignPrinciplesTask.VehiclesManager
{
    public class AveragePriceType : Command
    {
        public AveragePriceType(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
