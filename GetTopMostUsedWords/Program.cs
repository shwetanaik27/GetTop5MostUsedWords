using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetTopMostUsedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string strSpeech = "A paragraph is a number of sentences grouped together and relating to one topic. Or, a group of related sentences that develop a single point."+
                                "This definition shows that the paragraphs of compositions are not mere arbitrary divisions. The division of a chapter into paragraphs must be made according to the changes of ideas introduced."+
                                "There is, therefore, no rule as to the length of a paragraph. It may be short or long according to the necessity of the case. A paragraph may consist of a single sentence or of many sentences.";

            //Remove special characters like ',', '.', '(', ')'
            strSpeech = Regex.Replace(strSpeech.ToLower(), @"[^0-9a-zA-Z]+", " ");

            //Split the string into words
            string[] arrWords = strSpeech.Split(' ');

            //Group by the same words and then place them in descending order. Get the top 5 words.
            var words = arrWords.GroupBy(x => x.ToLower())                        
                        .OrderByDescending(y => y.Count())
                        .ToList()
                        .Take(5);            

            foreach(var word in words)
            {
                Console.WriteLine(word.Key.ToString() + " " + word.Count());
            }
            Console.ReadLine();
        }
    }
}
