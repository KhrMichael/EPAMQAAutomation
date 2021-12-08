using System;

namespace Task5.FlyingEntities
{
    public class Airplane : IFlyable
    {
        /// <summary>
        /// Unit of mesure - km per hour
        /// </summary>
        private double startSpeed;
        public Coordinate CurrentPosition { get; set; }
        public Airplane(Coordinate currentPosition = new())
        {
            startSpeed = 200;//start speed of airplane is 200 km/hour
            CurrentPosition = currentPosition;
        }
        public void FlyTo(Coordinate coordinate)
        {
            CurrentPosition = coordinate;
        }

        public double GetFlyTime(Coordinate destinationCoordinate)
        {
            double time = 0;
            double currentSpeed = startSpeed;
            double flightDistance = Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate);
            while (flightDistance > 0) // airplane increase its own speed by 10 km/hour every 10 km of flight 
            {
                if (flightDistance > 10)
                {
                    time += 10 / currentSpeed;// next 10 km fly with current speed
                }
                else
                {
                    time += flightDistance / currentSpeed;
                }
                flightDistance -= 10;
                currentSpeed += 10;
            }
            return time;
        }
    }
}
