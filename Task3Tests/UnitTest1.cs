using Task3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task3Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        [DataRow(234, 2, "11101010")]
        [DataRow(234, 10, "234")]
        [DataRow(234, 20, "BE")]
        [DataRow(345853, 2, "1010100011011111101")]
        [DataRow(-345853, 10, "-345853")]
        [DataRow(345853, 20, "234CD")]
        public void TestNumberSystemConvertation(int decimalNumber, int numberSystemBase, string numberInNewSystemBase)
        {
            NumberSystemConverter numberSystemConverter = new NumberSystemConverter();

            string convertationResult = numberSystemConverter.Convert(decimalNumber, numberSystemBase);

            Assert.AreEqual(convertationResult, numberInNewSystemBase);
        }
    }
}
