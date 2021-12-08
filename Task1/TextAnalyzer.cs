using System;
using System.Collections.Generic;

namespace Task1
{
    public class TextAnalyzer
    {
        /// <summary>
        /// Searches for the longest substring without repeating characters and return the length of this substring.
        /// </summary>
        /// <param name="sourceString">Intitial string.</param>
        /// <returns>Length of the longest substring without repeating characters.</returns>
        public int FindMaxUniqueSubstringLength(ReadOnlySpan<char> sourceString)
        {
            int maxUniqSubstringLength = 0;
            int currentUniqSequenceLength;
            for (int startSubstIndex = 0; maxUniqSubstringLength < sourceString.Length - startSubstIndex; startSubstIndex++)
            // if maxUniqSubstringLength greater than the substring length that will be given to GetMaxUniqueSubstringLength method
            // then iteration process finish
            {
                currentUniqSequenceLength = GetMaxUniqueSubstringLength(sourceString.Slice(startSubstIndex, sourceString.Length - startSubstIndex));
                if (currentUniqSequenceLength > maxUniqSubstringLength)
                {
                    maxUniqSubstringLength = currentUniqSequenceLength;
                }
            }
            return maxUniqSubstringLength;
        }
        private int GetMaxUniqueSubstringLength(ReadOnlySpan<char> sourceString)
        {
            HashSet<char> uniqSubstring = new HashSet<char>();
            int maxUniqSubstringLength = 0;
            foreach (var ch in sourceString)
            {
                if (uniqSubstring.Contains(ch))
                    uniqSubstring.Clear();

                uniqSubstring.Add(ch);

                if (uniqSubstring.Count > maxUniqSubstringLength)
                    maxUniqSubstringLength++;
            }
            return maxUniqSubstringLength;
        }
    }
}
