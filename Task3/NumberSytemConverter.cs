using System;
using System.Linq;
using System.Text;

namespace Task3
{
    public class NumberSytemConverter
    {
        private int maxNumberSystemBase = 20;
        private int minNumberSystemBase = 2;
        /// <summary>
        /// Converts a decimal number to a number in the new number system.
        /// </summary>
        /// <param name="decimalNumber">Number in decimal number system</param>
        /// <param name="numberSysBase">Base of the number system to convert(2 - 20)</param>
        /// <param name="numberInNewSysBase">Converted number</param>
        /// <returns>Number in a new number system</returns>
        public void TryConvert(int decimalNumber, int numberSysBase, out string numberInNewSysBase)
        {
            numberInNewSysBase = null;
            if (numberSysBase > maxNumberSystemBase || numberSysBase < minNumberSystemBase)
            {
                return;
            }

            StringBuilder convertedNumber = new StringBuilder();
            string sign = "";
            if(decimalNumber < 0)
            {
                sign = "-";
                decimalNumber = Math.Abs(decimalNumber);
            }
            while (decimalNumber != 0)
            {
                int remainder = decimalNumber % numberSysBase;
                decimalNumber /= numberSysBase;
                char digit = ConvertNumberToDigit(remainder);
                convertedNumber.Append(digit);
            }
            convertedNumber.Append(sign);

            numberInNewSysBase = new string(convertedNumber.ToString().Reverse().ToArray());
        }

        private char ConvertNumberToDigit(int decimalNumber)
        {
            char digit;
            if (decimalNumber > 9)
            {
                digit = (char)(55 + decimalNumber); //ASCII - 65(A)
            }
            else
            {
                Char.TryParse(decimalNumber.ToString(), out digit);
            }
            return digit;
        }
    }
}
