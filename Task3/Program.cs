using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length == 2)
            {
                NumberSytemConverter numberSytemConverter = new();
                if (int.TryParse(args[0], out int decimalNumber) == true && int.TryParse(args[1], out int numberSysBase) == true)
                {
                    try
                    {
                        Console.WriteLine(numberSytemConverter.Convert(decimalNumber, numberSysBase));
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
