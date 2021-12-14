using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAnalyzer textAnalyzer = new TextAnalyzer();

            if (args != null && args.Length == 1)
            {
                Console.WriteLine(textAnalyzer.FindMaxUniqueSubstringLength(args[0]));
            }
        }
    }
}
