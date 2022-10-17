using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using _3.BonusChallenge.ViewModel;

namespace _3.BonusChallenge_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Results(string wordList, string id)
        {
            if (id == null) id = "input";

            List<string> inputList = new List<string>();

            if (id == "list1" || id == "list2")
            {
                Resource resource = new Resource();
                inputList = (id == "list1") ? resource.SimpleList.ToList() : resource.HarderList.ToList();
                var output = (List<List<string>>)Output(inputList);

            } else
            {
                if (wordList != null && wordList.Length > 0)
                    inputList = wordList.Split(',').ToList();

                var output = (List<List<string>>)Output(inputList);
            }

            AnagramVM anagramVM = new AnagramVM();
            anagramVM.InputList = inputList;

            return View(anagramVM);
        }

        public ActionResult About()
        {
            return View();
        }

        private IEnumerable<IEnumerable<string>> Output(IEnumerable<string> input)
        {
            var output = new List<List<string>>();

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

        private bool IsAnagram(string word1, string word2)
        {
            word1 = String.Concat(word1.Replace(" ", string.Empty).ToLower().OrderBy(ch => ch));
            word2 = String.Concat(word2.Replace(" ", string.Empty).ToLower().OrderBy(ch => ch));

            return (word1.Equals(word2));
        }
    }
}