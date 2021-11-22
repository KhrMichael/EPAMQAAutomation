using System;

namespace Task5.FlyingEntities
{
    public class Drone : IFlyable
    {
        /// <summary>
        /// Unit of mesure - km per hour
        /// </summary>
        private double speed;
        public double Speed 
        {
            get => speed;
            set
            {
                if (value < 0 && value > 40)
                    throw new ArgumentException("Speed must be greater then zero and lower then 40 km/hour.");
                speed = value;
            }
        }
        public Coordinate CurrentPosition { get; set; }
        public Drone(double speed)
        {
            Speed = speed;
        }
        public void FlyTo(Coordinate destinationCoordinate)
        {
            if (Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate) > 1000)
                throw new ArgumentException("Drone can't fly more then 1000 km away.");
            CurrentPosition = destinationCoordinate;
        }

        public double GetFlyTime(Coordinate destinationCoordinate)
        {
            double distanceAB = Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate);
            double time = ((int)(distanceAB * 60)) / 10 / 60.0;
            time += distanceAB / speed;
            return time;
        }
    }
}
