using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Puzzle.Medium
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  Write code that meets the following requirements:
             *      - takes input of an arbitrary list of strings (examples provided in Resource.cs
             *      - for each string, looks at the other strings to search for anagrams (ignoring case)
             *      - returns a list of lists, where
             *          - each list contains the anagrams of the first string (not case sensitive)
             *          - list of lists is sorted alphabetically by the first item in each list
             *          - each list is also sorted alphabetically
             *          - the string occurs only once in any of the output lists
             *          - the list of lists contains all the strings in the input, but only once
             *          - does not contain duplicates or whitespace values
             *      - if the word does not have an anagram, it is still added as the only element  
             *      - does NOT use any NuGet packages or 3rd party libraries (only stuff that comes with .Net)
             *      - however, feel free to add methods or classes as you see fit
             *      
             *
             *
             *  example output:
             *
             *  given a list such as:  { "Kyoto", "London", "Portland", "Tokyo", "Wichita", "Donlon", "Anchorage" }
             *
             *  proper output should be:
             *
             *      Anchorage
             *      Donlon, London
             *      Kyoto, Tokyo
             *      Portland
             *      Wichita
             *
             *  improper output would be: 
             *      Kyoto, Tokyo
             *      London, Donlon
             *      Tokyo, Kyoto
             *      Wichita
             *      Donlon, London
             *      Anchorage
             *
             *  
             *  Example lists of anagrams are included in Resources.cs, but your code should work for ANY list of strings
             *
             *
             *
             *  Your code should be in the Output method below.
             *  
             *  You can do this challenge without using any 3rd party libraries - remember - we want to see YOUR work
             */

            
            foreach (var list in Output(Resource.SimpleList))
            {
                Console.WriteLine(string.Join(", ", list));
            }
            
            Console.WriteLine("\r\n\r\nSimpleList complete.\r\n");

            foreach (var list in Output(Resource.HarderList))
            {
                Console.WriteLine(string.Join(", ", list));
            }

            Console.WriteLine("\r\n\r\nHarderList complete.\r\n\r\n");
            
        }

        static IEnumerable<IEnumerable<string>> Output(IEnumerable<string> input)
        {
            var output = new List<List<string>>();

            // YOUR CODE GOES HERE

            foreach (var item in input)
            {
                //Don't create a string list entry for a null or empty string or one that's just whitespace
                if (String.IsNullOrWhiteSpace(item)) 
                    continue; 

                List<string> list = new List<string>();
                list.Add(item.Trim());

                foreach (var item2 in input)
                    if (!String.IsNullOrWhiteSpace(item2) && !item.Equals(item2) && IsAnagram(item, item2)) 
                        //Add this word to the list only if the list doesn't already contain the word
                        if (!list.Any(x => x.Contains(item2.Trim())))
                            list.Add(item2.Trim());

                list.Sort();
                output.Add(list);
            }

            return (output.GroupBy(l => l[0]).Select(g => g.FirstOrDefault()).OrderBy(l => l[0]).ToList());
        }

        static bool IsAnagram (string word1, string word2)
        {
            word1 = String.Concat(word1.Replace(" ", string.Empty).ToLower().OrderBy(ch => ch));
            word2 = String.Concat(word2.Replace(" ", string.Empty).ToLower().OrderBy(ch => ch));

            return (word1.Equals(word2));  
        }
    } 
}
