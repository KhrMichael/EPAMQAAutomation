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
        [DataRow("", 0)]
        public void FindLengthOfLongestUniqueSubstring_StringWithRandomSymbols_ReturnsLengthOfLongesthUniqueSubstring(
            string sourceString, int expectedLength)
        {
            var textAnalyzer = new TextAnalyzer();

            var longestUniqueSubstringLength = textAnalyzer.FindLengthOfLongestUniqueSubstring(sourceString);

            Assert.AreEqual(expectedLength, longestUniqueSubstringLength);
        }

        [TestMethod]
        [DataRow("saffsdskfhkcxkasdfkhdddddd", 6)]
        [DataRow("ddiifnweiaaaaaaaaa", 9)]
        [DataRow("sajg'/w8FFFddddh", 4)]
        [DataRow("3485730250", 0)]
        public void FindLengthOfLongestSubstringOfIdenticalLatinLetters_StringWithRandomSymbols_ReturnsLengthOfLongestSubstringOfIdenticalLatinLatters(
            string sourceString, int expectedLength)
        {
            var textAnalyzer = new TextAnalyzer();

            var lengthOfLongestSubstringOfIdenticalLatinLetters = textAnalyzer.FindLengthOfLongestSubstringOfIdenticalLatinLetters(sourceString);

            Assert.AreEqual(expectedLength, lengthOfLongestSubstringOfIdenticalLatinLetters);
        }

        [TestMethod]
        [DataRow("23428898nnvznkhsa33333", 5)]
        [DataRow("ddiifn242weiaaaaaaaaa", 1)]
        [DataRow("sajg'/w8FFFddddh", 1)]
        [DataRow("sajsglldh", 0)]
        public void FindLengthOfLongestSubstringOfIdenticalDigits_StringWithRandomSymbols_ReturenLengthOfLongestSubstringOfIdenticalDigits(
            string sourceString, int expectedLength)
        {
            var textAnalyzer = new TextAnalyzer();

            var lengthOfLongestSubstringOfIdenticalDigits = textAnalyzer.FindLengthOfLongestSubstringOfIdenticalDigits(sourceString);

            Assert.AreEqual(expectedLength, lengthOfLongestSubstringOfIdenticalDigits);
        }
    }
}
