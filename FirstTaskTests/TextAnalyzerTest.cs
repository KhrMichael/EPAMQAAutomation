using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstTask;

namespace Task1Tests
{
    [TestClass]
    public class TextAnalyzerTest
    {
        [TestMethod]
        [DataRow("absddabssdfansfekol", 8)]
        [DataRow("zx.clk390xc;;f0935m", 9)]
        [DataRow("23r0z/astlvn; d", 15)]
        [DataRow("asd98hgoia4eli", 12)]
        [DataRow("wq0tzvxlg,abscdbascd", 15)]
        public void TestFindMaxUniqueSubstringLength(string sourceString, int expectedLength)
        {
            TextAnalyzer textAnalyzer = new TextAnalyzer();

            int longestUniqueSubstringLength = textAnalyzer.FindLengthOfLongestUniqueSubstring(sourceString);

            Assert.AreEqual(expectedLength, longestUniqueSubstringLength);
        }
    }
}
