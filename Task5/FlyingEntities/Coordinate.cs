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
        public static double GetDistanceBetweenTwoCoordinates(Coordinate A, Coordinate B)
        {
            int power = 2;

            return Math.Sqrt(
                Math.Pow((double)A.X - B.X, power) +
                Math.Pow((double)A.Y - B.Y, power) +
                Math.Pow((double)A.Z - B.Z, power));
        }
    }
}
