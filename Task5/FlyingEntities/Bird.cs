using System;

namespace Task5.FlyingEntities
{
    public class Bird : IFlyable
    {
        /// <summary>
        /// Unit of mesure - km per hour
        /// </summary>
        private double startSpeed;
        public Coordinate CurrentPosition { get; set; }
        public Bird()
        {
            startSpeed = new Random().NextDouble() * 20;
        }
        public void FlyTo(Coordinate destinationCoordinate)
        {
            CurrentPosition = destinationCoordinate;
        }

        public double GetFlyTime(Coordinate destinationCoordinate)
        {
            double distanceAB = Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate);
            return distanceAB / startSpeed;
        }
    }
}
