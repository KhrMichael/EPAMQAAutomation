using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VehicleFleet.Vehicles.Vehicles
{
    /// <summary>
    /// Vehicle Identification Number
    /// </summary>
    [DataContract]
    public class VIN 
    {
        [DataMember]
        public string Number { get; private set; }

        public VIN()
        {
            Number = new VINGenerator().GenerateVIN();
        }
    }
}
