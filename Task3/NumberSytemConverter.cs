using System;
using System.Linq;
using System.Text;

namespace Task3
{
    public class NumberSytemConverter
    {
        /// <summary>
        /// Converts a decimal number into a new number system.
        /// </summary>
        /// <param name="decimalNumber">Number in decimal number system</param>
        /// <param name="numberSysBase">Base of the number system to convert(2 - 20)</param>
        public string Convert(int decimalNumber, int numberSysBase)
        {
            if (numberSysBase > 20 || numberSysBase < 2)
            {
                return null;
            }

            StringBuilder convertedNumber = new StringBuilder();
            string sign = "";
            if(decimalNumber < 0)
            {
                sign = "-";
            }
            int remainder;
            decimalNumber = Math.Abs(decimalNumber);
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
                digit = (char)(65 + number - 10);
            }
            else
            {
                Char.TryParse(number.ToString(), out digit);
            }
            return digit;
        }
    }
}
