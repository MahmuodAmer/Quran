using Newtonsoft.Json;
using Quran.Core.Extention;
using Quran.Core.Model;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using Math4Lib;
using System.Numerics;

namespace Quran.Core
{
    public static class Parser
    {
        public static SeriesIdxResults DetectIndices(string verse, string charsDetection, int suraId)
        {
            List<Result> searchResults = new List<Result>();


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

                if (checkValue)
                {
                    Match m = Regex.Match(verse.Substring(idx), @"\d+");
                    if (m.Success)
                    {
                        var newResult = new Result
                        {
                            CharIndex = charIndex,
                            SpacesIndex = idx + 1,
                            VerseIndex = int.Parse(m.Value),
                            VerseText = GetVarseThatIndexWillBeIn(verse, idx)
                        };
                        searchResults.Add(newResult);
                    }
                }
                var currentChar = verse[idx];
                bool isNumber = Regex.IsMatch(verse[idx].ToString(), "\\d");
                if (verse[idx] != '\n' & verse[idx] != ' ' & !isNumber & currentChar != 'ـ')
                    charIndex++;
            }
            var diffList = searchResults.Select(r => r.CharIndex).ToList().GetDifference();
            var output = new SeriesIdxResults
            {
                DiffrenceList = new ObservableCollection<int>(diffList),
                SearchChars = charsDetection,
                SuraId = suraId,
                SearchResults = new ObservableCollection<Result>(searchResults),
                Sequances = GetSequances(diffList)
            };

            //Modification - Add the equation
            //Create X -axes
            var x=new List<double>(output.DiffrenceList.Count);
            for (int i = 0; i < output.DiffrenceList.Count; i++)
            {
                x.Add(i);
            }
            output.PolynomialRepresentation = 
                                            FittingCurves.GeneratePolynomial(x,
                                            output.DiffrenceList.Select(num=> (double)num).ToList(),
                                            output.DiffrenceList.Count-1);
            return output;
        }

        private static string GetVarseThatIndexWillBeIn(string verse, int idx)
        {

            int startIndex = idx;

            string leftText = verse.Substring(0, idx).Split('\n').Last();
            string rightText = verse.Substring(idx).Split('\n')[0];

            return leftText + rightText;
        }

        private static Dictionary<string, int> GetSequances(List<int> inputList)
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
            //return shows.Keys.Select(x => JsonConvert.DeserializeObject<List<int>>(x)).ToList();
            return shows;
        }

        public static SearchForSimilarOutput SearchForSimilar(string verse, string searchText, int id)
        {
            var searchList = DetectSubStrings(verse);
            var output = new SearchForSimilarOutput();
            if (searchText.Length == 0)
            {
                return output;
            }

            //Get the refrence object 
            var refrence = DetectIndices(verse, searchText, id);
            output.Refrence = refrence;

            //for each string the the stringList
            //--search for it 
            //--find similarity percentage
            foreach (var item in searchList)
            {
                var result = DetectIndices(verse, item, id);
                var error = DetectedError(refrence, result);

                output.Results.Add(new SearchForSimilarResult { Result = result, Error = error });

            }
            output.Results.Sort(new SearchSimilarResultComparator());
            return output;
        }
        /// <summary>
        /// Detect all posible characheters to search for using
        /// </summary>
        /// <param name="verse"></param>
        /// <returns></returns>
        private static List<string> DetectSubStrings(string verse)
        {
            HashSet<string> result = new HashSet<string>();
            for (int i = 1; i < 20; i++)
            {
                for (int index = 0; index < verse.Length - i; index += i)
                {
                    string pattern = @"[\|\s\n\dـ]";
                    string subString = verse.Substring(index, i);

                    if (Regex.IsMatch(subString, pattern) == false)
                    {
                        result.Add(verse.Substring(index, i));
                    }
                    
                }
            }

            return result.ToList();
        }

        private static BigInteger DetectedError(SeriesIdxResults refrence, SeriesIdxResults newObj)
        {
            BigInteger error = 0;
            var evaluationList=refrence.DiffrenceList;
            var refEquation = refrence.PolynomialRepresentation;
            var selectedEquation = newObj.PolynomialRepresentation;

            foreach (var item in evaluationList)
            {
               error += Math.Abs((refEquation.Evalute(item) - selectedEquation.Evalute(item)));
               //TODO: Implement the DetectedError Function
            }
            return error;

        }

    }
}
