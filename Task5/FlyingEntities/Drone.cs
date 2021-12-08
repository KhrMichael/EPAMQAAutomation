using System;

namespace Task5.FlyingEntities
{
    public class Drone : IFlyable
    {
        /// <summary>
        /// Unit of mesure - km per hour
        /// </summary>
        private double speed;
        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentException">Speed must be greater then zero and lower then 40 km/hour.</exception>
        public double Speed 
        {
            get => speed;
            set
            {
                if (value < 0 && value >= 40)//Speed must be greater then zero and lower or equal then 40 km/hour.
                    throw new ArgumentException("Speed must be greater then zero and lower or equal then 40 km/hour.");
                speed = value;
            }
        }
        public Coordinate CurrentPosition { get; set; }

        /// <param name="speed">Speed of drone in km/hour</param>
        public Drone(double speed, Coordinate currentPosition = new())
        {
            Speed = speed;
            CurrentPosition = currentPosition;
        }

        public void FlyTo(Coordinate destinationCoordinate)
        {
            if (Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate) > 1000)//Drone can't fly more then 1000 km away
                throw new ArgumentException("Drone can't fly more then 1000 km away.");
            CurrentPosition = destinationCoordinate;
        }

        public double GetFlyTime(Coordinate destinationCoordinate)
        {
            double flightDistance = Coordinate.GetDistanceBetweenAB(CurrentPosition, destinationCoordinate);
            double time = flightDistance / speed;// time in hours
            time += (int)(time * 6);// each 10 minutes of flight drone hang in the air => dron can hang in the air 6(time * 60 / 10) times per hour
            return time;
        }
    }
}
