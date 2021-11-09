using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFindMaxUniqueSubstringLength()
        {
            const int testElemNumber = 5;
            string[] initialStrings = new string[testElemNumber]{
                "absddabssdfansfekol",
                "zx.clk390xc;;f0935m",
                "23r0z/astlvn; d",
                "asd98hgoia4eli",
                "wq0tzvxlg,abscdbascd" };
            int[] testResults = new int[testElemNumber];
            int[] expectedResults = new int[testElemNumber]
            {
                8,
                9,
                15,
                12,
                15
            };
            //string[] expectedResults = new string[testElemNumber] {
            //    "ansfekol",
            //    "zx.clk390",
            //    "23r0z/astlvn; d",
            //    "sd98hgoia4el",
            //    "wq0tzvxlg,abscd"
            //};

            ClassWithSolution solution = new ClassWithSolution();
            for (int index = 0; index < testElemNumber; index++)
            {
                testResults[index] = solution.FindMaxUniqueSubstringLength(initialStrings[index]);
            }
            CollectionAssert.AreEqual(testResults, expectedResults);
        }
    }
}
