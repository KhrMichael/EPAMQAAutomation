using System;

namespace Task7
{
    /// <summary>
    /// Represent Truck and Bus engine fields.
    /// </summary>
    [Serializable]
    public class EngineTuple
    {
        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public double Power { get; set; }

        public EngineTuple() {}

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
