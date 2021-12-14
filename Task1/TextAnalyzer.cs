using System;
using System.Collections.Generic;

namespace Task1
{
    public class TextAnalyzer
    {

        /// <summary>
        /// Searches for the longest substring without repeating characters and return the length of this substring.
        /// </summary>
        /// <param name="initialString">Intitial string.</param>
        /// <returns>Length of the longest substring without repeating characters.</returns>
        public int FindMaxUniqueSubstringLength(ReadOnlySpan<char> initialString)
        {
            int maxUniqSubstringLength = 0;
            int currentUniqSequenceLength;

            for (int startSubstIndex = 0; maxUniqSubstringLength < initialString.Length - startSubstIndex; startSubstIndex++)
            // if maxUniqSubstringLength greater than the substring length that will be given to GetMaxUniqueSubstringLength method
            // then iteration process finish
            {
                currentUniqSequenceLength = GetMaxUniqueSubstringLength(initialString.Slice(startSubstIndex, initialString.Length - startSubstIndex));

                if (currentUniqSequenceLength > maxUniqSubstringLength)
                {
                    maxUniqSubstringLength = currentUniqSequenceLength;
                }
            }

            return maxUniqSubstringLength;
        }

        private int GetMaxUniqueSubstringLength(ReadOnlySpan<char> sourceString)
        {
            var uniqueSubstring = new HashSet<char>();
            int maxUniqueSubstringLength = 0;

            foreach (var symbol in sourceString)
            {
                if (uniqueSubstring.Contains(symbol))
                {
                    uniqueSubstring.Clear();
                }

                uniqueSubstring.Add(symbol);

                if (uniqueSubstring.Count > maxUniqueSubstringLength)
                {
                    maxUniqueSubstringLength++;
                }
            }

            return maxUniqueSubstringLength;
        }
    }
}
