using System;

namespace Task7
{
    [Serializable]
    public class EngineTuple
    {
        public EngineTuple()
        {

        }

        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public double Power { get; set; }

        public static implicit operator EngineTuple(Tuple<string, string, double> t)
        {
            return new EngineTuple() { Type = t.Item1, SerialNumber = t.Item2, Power = t.Item3 };
        }

        public static implicit operator Tuple<string, string, double>(EngineTuple t)
        {
            return Tuple.Create(t.Type, t.SerialNumber, t.Power);
        }

    }
}
