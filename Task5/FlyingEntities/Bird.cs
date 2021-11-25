using System;

namespace Task5.FlyingEntities
{
    public class Bird : IFlyable
    {
        /// <summary>
        /// Unit of mesure - km per hour
        /// </summary>
        private double speed;
        public Coordinate CurrentPosition { get; set; }
        public Bird()
        {
            speed = new Random().NextDouble() * 20;
            CurrentPosition = new();
        }
        public void FlyTo(Coordinate destinationCoordinate)
        {
            CurrentPosition = destinationCoordinate;
        }

        public double GetFlyTime(Coordinate destinationCoordinate)
        {
            double distanceAB = Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate);
            return distanceAB / speed;
        }
    }
}
