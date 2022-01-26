using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VehicleFleet.Vehicles.Parts
{
    [XmlInclude(typeof(Engine))]
    [XmlInclude(typeof(Chassis))]
    [XmlInclude(typeof(Transmission))]
    [Serializable]
    public abstract class VehiclePart : IXmlSerializable
    {
        /// <summary>
        /// Provide information about Vehicle part in string format.
        /// </summary>
        protected abstract string GetInfo();

        public override string ToString()
        {
            return GetInfo();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }
        public virtual void ReadXml(XmlReader reader)
        {}
        public virtual void WriteXml(XmlWriter writer)
        {}
    }
}
