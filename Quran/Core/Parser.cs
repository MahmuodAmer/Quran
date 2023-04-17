using Newtonsoft.Json;
using Quran.Core.Model;
using System.Text.RegularExpressions;

namespace Quran.Core
{
    public static class Parser
    {
        private static SeriesIdxResults DetectSeriesIdx(string verse, string charsDetection)
        {
            List<int> vals = new List<int>();
            List<int> indecis = new List<int>();
            List<string> verseNumbers = new List<string>();
            List<int> valsSpacesIncluded = new List<int>();
            Dictionary<int, Tuple<int, int>> mapping = new Dictionary<int, Tuple<int, int>>();

            verse = verse.Replace("|", "");

            int pureIndex = 1;
            // get the list of index of ayat
            for (int idx = 0; idx < verse.Length - charsDetection.Length; idx++)
            {
                int lengthOfChars = charsDetection.Length;

                string partOfText = verse.Substring(idx, lengthOfChars);
                bool checkValue = (partOfText == charsDetection);
                if (verse[idx] != '\n' | verse[idx] != ' ')
                    pureIndex++;

                if (checkValue)
                {
                    Match m = Regex.Match(verse.Substring(idx), @"\d+");
                    if (m.Success)
                    {
                        verseNumbers.Add(m.Value);
                        indecis.Add(pureIndex);
                    }
                }
            }

            return new SeriesIdxResults { Indecis = indecis };
        }

        private static List<int> GetDifference(List<int> series)
        {
            List<int> diffList = new List<int>();
            for (int idx = 1; idx < series.Count; idx++)
            {
                int difference = series[idx] - series[idx - 1];
                diffList.Add(difference);
            }
            return diffList;
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
                    var stringRepresintationOfTheList=JsonConvert.SerializeObject(chunk);
                    if(shows.ContainsKey(stringRepresintationOfTheList))
                    {
                        shows[stringRepresintationOfTheList] += 1;
                    }
                    else
                    {
                        shows[stringRepresintationOfTheList] =0 ;
                    }
                }
            }

            return shows.Keys.Select(x=>JsonConvert.DeserializeObject<List<int>>(x)).ToList();
        }



        /// <summary>
        /// Item1 ==> المتكرر من الفروقات بين الاحرف 
        /// Item2 ==> التعويض باماكن ظهور الأحرف في مصفوفة الفروقات
        /// </summary>
        /// <param name="diffList"></param>
        /// <param name="repeatedCharIdx"></param>
        /// <param name="spacesMapping"></param>
        /// <param name="unspaceVerse"></param>
        /// <returns></returns>
        private static Tuple<IEnumerable<int>, List<List<List<int>>>, string> GetMatchesAndSeries(List<int> diffList, List<int> repeatedCharIdx, Dictionary<int, Tuple<int, int>> spacesMapping, string unspaceVerse)
        {
            int idxX = 0;
            int charX = 0, charY = 0;
            IEnumerable<int> matches;
            matches = new List<int>();

            var series = new List<List<List<int>>>();
            List<List<string>> patterns = new List<List<string>>();
            while (idxX < diffList.Count)
            {
                int idxY = idxX + 1;
                bool flag = false;
                var substring = new List<int>();
                var similarity1 = new List<int>();
                var similarity2 = new List<int>();

                while (idxY < diffList.Count)
                {
                    if (diffList[idxX] == diffList[idxY])
                    {
                        charX = idxX;
                        charY = idxY;
                        similarity1.Add(repeatedCharIdx[charX]);
                        similarity2.Add(repeatedCharIdx[charY]);
                        substring.Add(diffList[idxX]);
                        idxX++;
                        idxY++;
                        charX = idxX;
                        charY = idxY;
                        flag = true;
                    }
                    else if (flag && (diffList[idxX] != diffList[idxY]))
                    {
                        idxX--;
                        break;
                    }
                    else if (!flag && (diffList[idxX] != diffList[idxY]))
                    {
                        idxY++;
                    }
                }

                idxX++;

                if (substring.Count > 0)
                {
                    matches = matches.Concat(substring);
                    similarity1.Add(repeatedCharIdx[charX]);
                    similarity2.Add(repeatedCharIdx[charY]);
                    series.Add(new List<List<int>> { similarity1, similarity2 });
                }

                patterns = new List<List<string>>();

                foreach (var patternsMatching in series)
                {
                    var firstVerse = patternsMatching[0];
                    var lastVerse = patternsMatching[patternsMatching.Count - 1];
                    var pattern1 = new List<string>();
                    var pattern2 = new List<string>();
                    var resetCounter = spacesMapping[firstVerse[0]].Item1;

                    for (int idx = spacesMapping[firstVerse[0]].Item1; idx <= spacesMapping[firstVerse[firstVerse.Count - 1]].Item1; idx++)
                    {
                        pattern1.Add(unspaceVerse[resetCounter].ToString());
                        resetCounter++;
                    }

                    pattern1.Add("(" + spacesMapping[firstVerse[0]].Item2 + ")");
                    resetCounter = spacesMapping[lastVerse[0]].Item1;

                    for (int idx = spacesMapping[lastVerse[0]].Item1; idx <= spacesMapping[lastVerse[lastVerse.Count - 1]].Item1; idx++)
                    {
                        pattern2.Add(unspaceVerse[resetCounter].ToString());
                        resetCounter++;
                    }

                    pattern2.Add("(" + spacesMapping[lastVerse[0]].Item2 + ")");
                    bool reverse = false;

                    if (reverse)
                    {
                        pattern1.Reverse();
                        pattern2.Reverse();
                    }

                    patterns.Add(new List<string> { string.Join("", pattern1), string.Join("", pattern2) });
                }
            }

            var output = "";

            foreach (var pattern in patterns)
            {
                output += "------Start ------\n";
                int counter = 0;
                foreach (var verse in pattern)
                {
                    if (counter == 0)
                    {
                        output += verse.SimplifyVerse();
                        counter++;
                    }
                    else if (counter > 0 && counter < pattern.Count)
                    {
                        continue;

                    }
                    else if (counter > 0 && counter == pattern.Count)
                    {
                        output += verse;
                    }
                }

                output += "\n------End------\n";
            }

            return Tuple.Create(matches, series, output);
        }




        //public static ParseResult Parse(string text, string chars)
        //{
        //    ParseResult result = new ParseResult();

        //    var ids_result = DetectSeriesIdx(text, chars);

        //    result.NumberOfAppearing = ids_result.Item3;
        //    result.RepeatedIndexs = ids_result.Item4;
        //    //Call the get diffrence method
        //    var diffrence_results = GetDifference(result.RepeatedIndexs);

        //    result.DiffrencesList = diffrence_results.Item2;

        //    var matches_series = GetMatchesAndSeries(result.DiffrencesList, ids_result.Item4, ids_result.Item5, ids_result.Item2);

        //    result.Matches = matches_series.Item1;
        //    result.Series = matches_series.Item2;
        //    result.OutputString = matches_series.Item3;
        //    return result;
        //}

        //public static ParseResult Parse(int id, string chars)
        //{
        //    ParseResult result = new ParseResult();
        //    result.SuraId= id;
        //    result.SearchText= chars;
        //    var ids_result = DetectSeriesIdx(id.SuraIdToString(), chars);

        //    result.NumberOfAppearing = ids_result.Item3;
        //    result.RepeatedIndexs = ids_result.Item4;
        //    //Call the get diffrence method
        //    var diffrence_results = GetDifference(result.RepeatedIndexs);

        //    result.DiffrencesList = diffrence_results.Item2;

        //    var matches_series = GetMatchesAndSeries(result.DiffrencesList, ids_result.Item4, ids_result.Item5, ids_result.Item2);

        //    result.Matches = matches_series.Item1;
        //    result.Series = matches_series.Item2;
        //    result.OutputString = matches_series.Item3;
        //    return result;
        //}

    }
}
