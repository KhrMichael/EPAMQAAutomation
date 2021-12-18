using System;
using System.Xml.Serialization;

namespace VehicleFleet.Vehicles.Parts
{
    [XmlInclude(typeof(Engine))]
    [XmlInclude(typeof(Chassis))]
    [XmlInclude(typeof(Transmission))]
    [Serializable]
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
