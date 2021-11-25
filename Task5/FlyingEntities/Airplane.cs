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
        public Airplane()
        {
            startSpeed = 200;
            CurrentPosition = new();
        }
        public void FlyTo(Coordinate coordinate)
        {
            CurrentPosition = coordinate;
        }

        public double GetFlyTime(Coordinate destinationCoordinate)
        {
            double time = 0;
            double currentSpeed = startSpeed;
            double distanceAB = Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate);
            while (distanceAB > 0)
            {
                if (distanceAB > 10)
                {
                    time += 10 / currentSpeed;
                }
                else
                {
                    time += distanceAB / currentSpeed;
                }
                distanceAB -= 10;
                currentSpeed += 10;
            }
            return time;
        }
    }
}
