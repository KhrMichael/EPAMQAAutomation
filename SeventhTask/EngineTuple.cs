using System;
using System.Runtime.Serialization;

namespace SeventhTask
{
    /// <summary>
    /// Represent Truck and Bus engine fields.
    /// </summary>
    [DataContract]
    public class EngineTuple
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }
        [DataMember]
        public double Power { get; set; }

        public EngineTuple() { }

        public static implicit operator EngineTuple(Tuple<string, string, double> tuple)
        {
            return new EngineTuple() { Type = tuple.Item1, SerialNumber = tuple.Item2, Power = tuple.Item3 };
        }

        public static implicit operator Tuple<string, string, double>(EngineTuple engineTuple)
        {
            return Tuple.Create(engineTuple.Type, engineTuple.SerialNumber, engineTuple.Power);
        }

    }
}
