using System;

namespace Task5.FlyingEntities
{
    /// <summary>
    /// Represents a 3D coordinates.
    /// </summary>
    public struct Coordinate
    {
        public uint X { get; set; }
        public uint Y { get; set; }
        public uint Z { get; set; }
        public Coordinate(uint x, uint y, uint z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns the distnace between point A and point B.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double GetDistanceBetweenAB(Coordinate A, Coordinate B)
        {
            return Math.Sqrt(
                Math.Pow((double)A.X - B.X, 2) +
                Math.Pow((double)A.Y - B.Y, 2) +
                Math.Pow((double)A.Z - B.Z, 2));
        }
    }
}
