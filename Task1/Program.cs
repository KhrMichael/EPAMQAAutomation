namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAnalyzer textAnalyzer = new TextAnalyzer();
            if (args != null && args.Length == 1)
            {
                System.Console.WriteLine(textAnalyzer.FindMaxUniqueSubstringLength(args[0]));
            }
        }
    }
}
