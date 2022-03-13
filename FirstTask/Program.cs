using System;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var textAnalyzer = new TextAnalyzer();

            if (args.Length == 1)
            {
                Console.WriteLine(textAnalyzer.FindLengthOfLongestUniqueSubstring(args[0]));
            }
        }
    }
}
