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
            string longestSubstring = FindLongestUniqueSubstring(sourceString);
            return longestSubstring.Length;
        }

        public string FindLongestUniqueSubstring(ReadOnlySpan<char> sourceString)
        {
            var longestSubstring = string.Empty;
            var substringToCompare = new List<char>();

            for (int substringStartIndex = 0; sourceString.Length - substringStartIndex > longestSubstring.Length; substringStartIndex++)
            {
                for (int i = substringStartIndex; i < sourceString.Length; i++)
                {
                    if (substringToCompare.Contains(sourceString[i]))
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
