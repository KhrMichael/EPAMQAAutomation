namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAdditionalFeatures classWithSolution = new TextAdditionalFeatures();
            foreach (var arg in args)
            {
                System.Console.WriteLine(classWithSolution.FindMaxUniqueSubstringLength(arg));
            }
        }
    }
}
