using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

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
