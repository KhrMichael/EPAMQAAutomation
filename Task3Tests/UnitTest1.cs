using Task3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task3Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestNumberSystemConverterConvertMethod()
        {
            List<int> decimalNumbers = new() { 234, 12, 345853};
            List<int> numberSysBases = new() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            List<string> expectedOutput = new() { "11101010", "22200", "3222", "1414", "1030", "453", "352", "280", "234", "1A3", "176", "150", "12A", "109", "EA", "DD", "D0", "C6", "BE",
                "1100", "110", "30", "22", "20", "15", "14", "13", "12", "11", "10", "C", "C", "C", "C", "C", "C", "C", "C",
                "1010100011011111101", "122120102101", "1110123331", "42031403", "11225101", "2640214", "1243375", "576371", "345853", "216932", "148191", "C1561", "9007B", "6C71D", "546FD", "426C5", "35581", "2C80F", "234CD"
            };
            List<string> testResults = new();

            NumberSystemConverter numberSystemConverter = new();
            foreach (var decimalNumber in decimalNumbers)
            {
                foreach (var numberSysBase in numberSysBases)
                {
                    testResults.Add(numberSystemConverter.Convert(decimalNumber, numberSysBase));
                }
            }

            CollectionAssert.AreEqual(expectedOutput, testResults);

        }
    }
}
