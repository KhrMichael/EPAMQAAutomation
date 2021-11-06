using System;
using System.Collections.Generic;

namespace Task1
{
    public class ClassWithSolution
    {
        /// <summary>
        /// Searches for the longest unique sequence of chars and return the length of this sequence
        /// </summary>
        /// <param name="initialSequence">Intitial char sequence</param>
        /// <returns></returns>
        public int FindMaxUniqueSubstringLength(ReadOnlySpan<char> initialSequence)
        {
            int result = 0;
            int currentUniqueSequenceLength = 0;
            for (int i = 0; i < initialSequence.Length - 1; i++)
            {
                if (result < initialSequence.Length - i) // if the result greater than the sequence length that will be given to GetMaxUniqueSequanceLength then end iteration 
                {
                    currentUniqueSequenceLength = GetMaxUniqueSubstringLength(initialSequence[i..initialSequence.Length]);
                }
                else
                {
                    break;
                }
                if (currentUniqueSequenceLength > result)
                {
                    result = currentUniqueSequenceLength;
                }
            }
            return result;
        }
        private int GetMaxUniqueSubstringLength(ReadOnlySpan<char> charSequence)
        {
            HashSet<char> uneqStr = new HashSet<char>();
            int maxUneqCharInStr = 0;
            foreach (var ch in charSequence)
            {
                if (uneqStr.Contains(ch))
                    uneqStr.Clear();

                uneqStr.Add(ch);

                if (maxUneqCharInStr < uneqStr.Count)
                    maxUneqCharInStr++;
            }
            return maxUneqCharInStr;
        }
    }
}
