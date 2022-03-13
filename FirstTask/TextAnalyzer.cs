using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FirstTask
{
    public class TextAnalyzer
    {

        public int FindLengthOfLongestUniqueSubstring(ReadOnlySpan<char> sourceString)
        {
            Func<char, List<char>, bool> substringRestriction = (char symbol, List<char> substring) =>
                !substring.Contains(symbol);

            var longestUniqueSubstring = FindLongestSubstring(sourceString, substringRestriction);

            return longestUniqueSubstring.Length;
        }

        public int FindLengthOfLongestSubstringOfIdenticalLatinLetters(ReadOnlySpan<char> sourceString)
        {
            Func<char, List<char>, bool> substringRestriction = (char symbol, List<char> substring) => 
                substring.All(substringSymbol => substringSymbol == symbol) &&
                ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'));

            var longestSubstringOfIdenticalLatinLetters = FindLongestSubstring(sourceString, substringRestriction);

            return longestSubstringOfIdenticalLatinLetters.Length;
        }

        public int FindLengthOfLongestSubstringOfIdenticalDigits(ReadOnlySpan<char> sourceString)
        {
            Func<char, List<char>, bool> substringRestriction = (char symbol, List<char> substring) => 
                substring.All(substringSymbol => substringSymbol == symbol) &&
                symbol >= '0' && symbol <= '9';

            var longestSubstringOfIdenticalLatinLetters = FindLongestSubstring(sourceString, substringRestriction);

            return longestSubstringOfIdenticalLatinLetters.Length;
        }

        private string FindLongestSubstring(ReadOnlySpan<char> sourceString, Func<char, List<char>, bool> substringRestriction)
        { 
            var longestSubstring = string.Empty;
            var substringToCompare = new List<char>();

            for (int substringStartIndex = 0; sourceString.Length - substringStartIndex > longestSubstring.Length; substringStartIndex++)
            {
                for (int i = substringStartIndex; i < sourceString.Length; i++)
                {
                    if (!substringRestriction(sourceString[i], substringToCompare))
                    {
                        break;
                    }
                    substringToCompare.Add(sourceString[i]);
                } 

                if(longestSubstring.Length < substringToCompare.Count)
                {
                    longestSubstring = new string(substringToCompare.ToArray());
                }

                substringToCompare.Clear();
            }

            return longestSubstring;
        }
    }
}
