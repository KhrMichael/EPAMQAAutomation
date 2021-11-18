using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 2)
            {
                NumberSytemConverter numberSytemConverter = new();
                int.TryParse(args[0], out int decimalNumber);
                int.TryParse(args[1], out int numberSysBase);
                Console.WriteLine(numberSytemConverter.Convert(decimalNumber, numberSysBase));
            }
        }
    }
}
