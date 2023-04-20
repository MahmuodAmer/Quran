﻿using Quran.Core.Model;

namespace Quran.Core.Extention
{
    public static class ImportDataExtentions
    {
        private static List<LightItem> SurasNames;
        /// <summary>
        /// Get the names of the Quran Suras
        /// </summary>
        /// <returns></returns>
        public static List<LightItem> GetNames()
        {
            if (SurasNames != null)
            {
                return SurasNames;
            }
            else
            {
                SurasNames = new List<LightItem>();
                //Load the names from the file suras.txt file
                foreach (var line in File.ReadAllLines("raw\\suras.txt"))
                {
                    int id = int.Parse(line.Split(",")[0]);
                    string name = line.Split(",")[1].Replace("\"", "");
                    SurasNames.Add(new LightItem() { Id = id, Name = name });
                }
                return SurasNames;
            }
        }
    }
}