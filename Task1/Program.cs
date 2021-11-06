namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassWithSolution classWithSolution = new ClassWithSolution();
            foreach (var arg in args)
            {
                System.Console.WriteLine(classWithSolution.FindMaxUniqueSubstringLength(arg));
            }
        }
    }
}
