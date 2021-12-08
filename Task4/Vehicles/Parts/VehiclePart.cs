namespace Task4.Vehicles.Parts
{
    public abstract class VehiclePart
    {
        /// <summary>
        /// Provide information about Vehicle part in string format.
        /// </summary>
        protected abstract string GetInfo();
        public override string ToString()
        {
            return GetInfo();
        }
    }
}
