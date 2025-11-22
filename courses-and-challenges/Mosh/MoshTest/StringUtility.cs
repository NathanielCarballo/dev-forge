using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshTest
{
    public class StringUtility
    {
        public static string SummarizeText(string text, int maxLength = 20)
        {
            //const int maxLength = 20;

            if (text.Length < maxLength)
                return text;
            //else
            {
                var words = text.Split(' ');
                var totalCharacters = 0;
                var summaryWords = new List<string>();

                foreach (var word in words)
                {
                    summaryWords.Add(word);

                    totalCharacters += word.Length + 1;
                    if (totalCharacters > maxLength)
                        break;
                }

                //var summary = String.Join(" ", summaryWords) + "...";
                return String.Join(" ", summaryWords) + "...";
                //sentence.Substring(0, maxLength);
            }
        }
    }
}
