namespace Task4.Vehicles.Parts
{
    public abstract class VehiclePart
    {
        protected abstract string GetInfo();
        public override string ToString()
        {
            return GetInfo();
        }
    }
}
