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
                8,//    "ansfekol"
                9,//    "zx.clk390"
                15,//    "23r0z/astlvn; d"
                12,//    "sd98hgoia4el"
                15//    "wq0tzvxlg,abscd"
            };
            TextAnalyzer textAnalyzer = new TextAnalyzer();
            for (int index = 0; index < testElemNumber; index++)
            {
                testResults[index] = textAnalyzer.FindMaxUniqueSubstringLength(initialStrings[index]);
            }
            CollectionAssert.AreEqual(testResults, expectedResults);
        }
    }
}
