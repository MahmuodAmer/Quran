using Newtonsoft.Json;
using Quran.Core.Extention;
using Quran.Core.Model;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.Text;

namespace Quran.Core
{
    public static class Parser
    {
        public static SeriesIdxResults DetectIndices(string verse, string charsDetection, int suraId)
        {
            List<Result> searchResults = new List<Result>();

            //if charsDetection == "" did not complete the process
            if (charsDetection == "")
                return new SeriesIdxResults();

            verse = verse.Replace("|", "");

            //indexer that count the indecies without spaces and new line
            int charIndex = 1;

            // get the list of index of ayat
            for (int idx = 0; idx < verse.Length - charsDetection.Length; idx++)
            {
                int lengthOfChars = charsDetection.Length;

                string partOfText = verse.Substring(idx, lengthOfChars);
                bool checkValue = (partOfText == charsDetection);
                if (verse[idx] != '\n' | verse[idx] != ' ')
                    charIndex++;

                if (checkValue)
                {
                    Match m = Regex.Match(verse.Substring(idx), @"\d+");
                    if (m.Success)
                    {
                        searchResults.Add(new Result
                        {
                            CharIndex = charIndex,
                            SpacesIndex = idx + 1,
                            VerseIndex = int.Parse(m.Value),
                            VerseText = GetVarseThatIndexWillBeIn(verse, idx)
                        });
                    }
                }
            }
            var diffList = searchResults.Select(r => r.CharIndex).ToList().GetDifference();
            var output = new SeriesIdxResults
            {
                DiffrenceList = new ObservableCollection<int>(diffList),
                SearchChars = charsDetection,
                SuraId = suraId,
                SearchResults = new ObservableCollection<Result>(searchResults)
            };

            return output;
        }

        private static string GetVarseThatIndexWillBeIn(string verse, int idx)
        {
            
            int startIndex = idx;

            string leftText = verse.Substring(0, idx).Split('\n').Last();
            string rightText = verse.Substring( idx).Split('\n')[0];

            return leftText+ rightText;
        }

        private static List<List<int>> GetSequances(List<int> inputList)
        {
            Dictionary<string, int> shows = new Dictionary<string, int>();

            //Loop in the numbers (Lengths) from the half of the length of list to 1
            //for every number in loop through the mainList check if it in the result list if it found add 1 to the value of it 
            // else add it to the Dictionary with the value 0 

            for (int i = (int)inputList.Count / 2; i >= 1; i--)
            {
                //check if in range
                //var check = (endIndex + length)! > inputList.Count;

                //get the sub list from the inputs array
                var chanks = inputList.Chunk(i).Where(x => x.Length == i);

                foreach (var chunk in chanks)
                {
                    var stringRepresintationOfTheList = JsonConvert.SerializeObject(chunk);
                    if (shows.ContainsKey(stringRepresintationOfTheList))
                    {
                        shows[stringRepresintationOfTheList] += 1;
                    }
                    else
                    {
                        shows[stringRepresintationOfTheList] = 0;
                    }
                }
            }
            //Delete the lists that appear only one time (value =0)
            foreach (var list in shows)
            {
                if (list.Value == 0)
                {
                    shows.Remove(list.Key);
                }
            }
            return shows.Keys.Select(x => JsonConvert.DeserializeObject<List<int>>(x)).ToList();
        }

    }
}
