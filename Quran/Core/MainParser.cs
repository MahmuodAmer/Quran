
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quran.Core
{
    public static class MainParser
    {
        private static Tuple<string, string, int, List<int>, Dictionary<int, Tuple<int, int>>> DetectSeriesIdx(string verse, string charsDetection)
        {
            List<int> vals = new List<int>();
            List<string> verseNumbers = new List<string>();
            List<int> valsSpacesIncluded = new List<int>();
            Dictionary<int, Tuple<int, int>> mapping = new Dictionary<int, Tuple<int, int>>();

            verse = verse.Replace("|", "");

            // get the list of index of ayat
            for (int idx = 0; idx < verse.Length - charsDetection.Length; idx++)
            {
                int lengthOfChars = charsDetection.Length;
                //int endIndex = idx + lengthOfChars;

                string partOfText = verse.Substring(idx, lengthOfChars);
                bool checkValue = partOfText == charsDetection;

                if (checkValue)
                {
                    Match m = Regex.Match(verse.Substring(idx), @"\d+");
                    if (m.Success)
                    {
                        verseNumbers.Add(m.Value);
                    }
                }
            }

            // get the ayat without the index (d)
            verse = new string(verse.Where(c => !char.IsDigit(c)).ToArray());
            verse = verse.Replace(")", "");
            verse = verse.Replace("(", "");
            verse = verse.Replace("|", "");

            // get the index of the char with space included
            for (int idx = 0; idx < verse.Length - charsDetection.Length; idx++)
            {
                int lengthOfChars = charsDetection.Length;
                int endIndex = idx + lengthOfChars;

                string partOfText = verse.Substring(idx, lengthOfChars);
                bool checkValue = partOfText == charsDetection;

                if (checkValue)
                {
                    valsSpacesIncluded.Add(idx);
                }
            }

            string unspacesVerse = verse;//.Replace(" ", "");

            // get the index of the char with space excluded
            for (int idx = 0; idx < unspacesVerse.Length - charsDetection.Length; idx++)
            {
                int lengthOfChars = charsDetection.Length;
                int endIndex = idx + lengthOfChars;

                string partOfText = unspacesVerse.Substring(idx, lengthOfChars).Replace("\n", "");
                bool checkValue = partOfText == charsDetection;

                if (checkValue)
                {
                    vals.Add(idx);
                }
            }

            for (int idx = 0; idx < vals.Count; idx++)
            {
                int val = valsSpacesIncluded[idx];
                string verseNumber = verseNumbers[idx];
                mapping[vals[idx]] = Tuple.Create(val, int.Parse(verseNumber));
            }

            return Tuple.Create(verse, unspacesVerse, vals.Count, vals, mapping);
        }


        private static Tuple<int, List<int>> GetDifference(List<int> series)
        {
            List<int> diffList = new List<int>();
            for (int idx = 1; idx < series.Count; idx++)
            {
                int difference = series[idx] - series[idx - 1];
                diffList.Add(difference);
            }
            return Tuple.Create(diffList.Count, diffList);
        }


        //private static List<List<int>> GroupConsecutive(List<int> inputList)
        //{
        //    List<List<int>> result = new List<List<int>>();
        //    List<int> currentGroup = new List<int>();
        //    for (int i = 0; i < inputList.Count; i++)
        //    {
        //        int currentItem = inputList[i];
        //        if (currentGroup.Count == 0 || Equals(currentGroup.Last(), currentItem))
        //        {
        //            currentGroup.Add(currentItem);
        //        }
        //        else
        //        {
        //            result.Add(currentGroup);
        //            currentGroup = new List<int> { currentItem };
        //        }
        //    }
        //    result.Add(currentGroup);
        //    return result;
        //}


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
                    matches =matches.Concat(substring);
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
                    }else if(counter >0 && counter < pattern.Count)
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



        
        public static ParseResult Parse(string text, string chars)
        {
            ParseResult result = new ParseResult();

            var ids_result = DetectSeriesIdx(text, chars);

            result.NumberOfAppearing = ids_result.Item3;
            result.RepeatedIndexs = ids_result.Item4;
            //Call the get diffrence method
            var diffrence_results = GetDifference(result.RepeatedIndexs);

            result.DiffrencesList = diffrence_results.Item2;

            var matches_series = GetMatchesAndSeries(result.DiffrencesList, ids_result.Item4, ids_result.Item5, ids_result.Item2);

            result.Matches = matches_series.Item1;
            result.Series = matches_series.Item2;
            result.OutputString = matches_series.Item3;
            return result;
        }

        public static ParseResult Parse(int id, string chars)
        {
            ParseResult result = new ParseResult();
            result.SuraId= id;
            result.SearchText= chars;
            var ids_result = DetectSeriesIdx(id.SuraIdToString(), chars);

            result.NumberOfAppearing = ids_result.Item3;
            result.RepeatedIndexs = ids_result.Item4;
            //Call the get diffrence method
            var diffrence_results = GetDifference(result.RepeatedIndexs);

            result.DiffrencesList = diffrence_results.Item2;

            var matches_series = GetMatchesAndSeries(result.DiffrencesList, ids_result.Item4, ids_result.Item5, ids_result.Item2);

            result.Matches = matches_series.Item1;
            result.Series = matches_series.Item2;
            result.OutputString = matches_series.Item3;
            return result;
        }

    }
}
