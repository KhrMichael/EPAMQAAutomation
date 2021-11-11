using System;
using System.Linq;
using System.Text;

namespace Task3
{
    public class NumberSytemConverter
    {
        private int maxNumberSystemBase = 20;
        private int minNumberSystemBase = 20;
        /// <summary>
        /// Converts a decimal number into a new number system.
        /// </summary>
        /// <param name="decimalNumber">Number in decimal number system</param>
        /// <param name="numberSysBase">Base of the number system to convert(2 - 20)</param>
        public string Convert(int decimalNumber, int numberSysBase)
        {
            if (numberSysBase > maxNumberSystemBase || numberSysBase < minNumberSystemBase)
            {
                return null;
            }

            StringBuilder convertedNumber = new StringBuilder();
            string sign = "";
            if(decimalNumber < 0)
            {
                sign = "-";
            }
            decimalNumber = Math.Abs(decimalNumber);
            int remainder;
            while (decimalNumber >= numberSysBase)
            {
                remainder = decimalNumber % numberSysBase;
                decimalNumber /= numberSysBase;
                convertedNumber.Append(ConvertNumberToDigit(remainder));
            }
            convertedNumber.Append(ConvertNumberToDigit(decimalNumber));
            convertedNumber.Append(sign);

            return new string(convertedNumber.ToString().Reverse().ToArray());
        }

        private char ConvertNumberToDigit(int number)
        {
            char digit;
            if (number > 9)
            {
                digit = (char)(65 + number - 10); //ASCII - 65(A)
            }
            else
            {
                Char.TryParse(number.ToString(), out digit);
            }
            return digit;
        }
    }
}
