using System.Runtime.Serialization;

namespace VehicleFleet.Vehicles.Parts
{
    [KnownType(typeof(Engine))]
    [KnownType(typeof(Chassis))]
    [KnownType(typeof(Transmission))]
    [DataContract]
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
