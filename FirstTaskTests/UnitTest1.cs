using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("absddabssdfansfekol", 8)]
        [DataRow("zx.clk390xc;;f0935m", 9)]
        [DataRow("23r0z/astlvn; d", 15)]
        [DataRow("asd98hgoia4eli", 12)]
        [DataRow("wq0tzvxlg,abscdbascd", 15)]
        public void TestFindMaxUniqueSubstringLength(string initialString, int longestUniqueSubstringLength)
        {
            TextAnalyzer textAnalyzer = new TextAnalyzer();

            int substringLength = textAnalyzer.FindMaxUniqueSubstringLength(initialString);

            Assert.AreEqual(substringLength, longestUniqueSubstringLength);
        }
    }
}
