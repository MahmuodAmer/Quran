﻿using System.Collections.Generic;

namespace Quran.Core.Extention
{
    public static class ListsExtension
    {
        public static List<int> GetDifference(this List<int> series)
        {
            List<int> diffList = new List<int>();
            for (int idx = 1; idx < series.Count; idx++)
            {
                int difference = series[idx] - series[idx - 1];
                diffList.Add(difference);
            }
            return diffList;
        }
    }
}
