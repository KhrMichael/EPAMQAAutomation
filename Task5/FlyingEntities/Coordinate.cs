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

        public static double GetDistanceBetweenAB(Coordinate A, Coordinate B)
        {
            return Math.Sqrt(
                Math.Pow(A.X - B.X, 2) +
                Math.Pow(A.Y - B.Y, 2) +
                Math.Pow(A.Z - B.Z, 2));
        }
    }
}
