namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAnalyzer textAnalyzer = new TextAnalyzer();
            if (args != null)
            {
                System.Console.WriteLine(textAnalyzer.FindMaxUniqueSubstringLength(args[0]));
            }
        }
    }
}
