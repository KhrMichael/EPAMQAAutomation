using System;
using Task4.Vehicles.Parts;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(34, 5, "TYf34", "3754945df854c");
            Console.WriteLine(engine.GetInfo());
        }
    }
}
