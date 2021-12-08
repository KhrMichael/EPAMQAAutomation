using System;

namespace Task5.FlyingEntities
{
    public class Bird : IFlyable
    {
        /// <summary>
        /// Unit of mesure - km per hour
        /// </summary>
        private double speed;
        public double Speed { get => speed; }
        public Coordinate CurrentPosition { get; set; }
        public Bird(Coordinate currentPosition = new())
        {
            speed = new Random().NextDouble() * 20;//random speed in range from 0 to 20 km/hour
            CurrentPosition = currentPosition;
        }
        public void FlyTo(Coordinate destinationCoordinate)
        {
            CurrentPosition = destinationCoordinate;
        }

        public double GetFlyTime(Coordinate destinationCoordinate)
        {
            double flightDistance = Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate);
            return flightDistance / Speed;
        }
    }
}
