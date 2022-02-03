namespace ObjectOrientedDesignPrinciplesTask.VehiclesManager
{
    public class VehiclesManager
    {
        protected VehiclesManager manager;

        protected VehiclesManager()
        { }

        public VehiclesManager Instance()
        {
            return manager != null ? manager : manager = new VehiclesManager();
        }

        public void Start()
        {

        }
    }
}
