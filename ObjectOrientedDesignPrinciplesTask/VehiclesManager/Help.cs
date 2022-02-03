using System;

namespace ObjectOrientedDesignPrinciplesTask.VehiclesManager
{
    public class Help : Command
    {
        public Help(VehiclesAnalyzer analyzer) : base(analyzer)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
