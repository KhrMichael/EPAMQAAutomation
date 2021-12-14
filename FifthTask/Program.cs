using System;
using System.Collections.Generic;
using Task5.FlyingEntities;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Airplane airplane = new Airplane();
            Drone drone = new Drone(33);
            Coordinate destination = new Coordinate(100, 1000, 10);

            List<IFlyable> flyableEntities = new List<IFlyable>() { bird, airplane, drone };

            foreach (var flyableEntity in flyableEntities)
            {
                Console.WriteLine("Flight time of {0} - {1:0.00} hours.", flyableEntity.GetType().Name, flyableEntity.GetFlyTime(destination));

                try
                {
                    flyableEntity.FlyTo(destination);
                }
                catch(ArgumentException flightRangeError)
                {
                    Console.WriteLine(flightRangeError.Message);
                }
            }
        }
    }
}
