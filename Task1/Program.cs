namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAnalyzer textAnalyzer = new TextAnalyzer();
            foreach (var arg in args)
            {
                System.Console.WriteLine(textAnalyzer.FindMaxUniqueSubstringLength(arg));
            }
        }
    }
}
