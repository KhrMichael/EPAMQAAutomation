using System;
using System.Xml.Serialization;

namespace Task4.Vehicles.Parts
{
    [XmlInclude(typeof(Chassis))]
    [XmlInclude(typeof(Engine))]
    [XmlInclude(typeof(Transmission))]
    [Serializable]
    public abstract class VehiclePart
    {
        protected abstract string GetInfo();
        public override string ToString()
        {
            return GetInfo();
        }
    }
}
