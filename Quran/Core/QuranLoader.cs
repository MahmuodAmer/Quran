using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Force.DeepCloner;
using Quran.Core.Extention;
using Quran.Core.Model;

namespace Quran.Core
{
    /// <summary>
    /// Load all the Quran text into it
    /// </summary>
    public class QuranLoader:ISuraNamesLoader
    {
        
        private readonly IArabicOperations arabicOperations = new ArabicOperations();

        public List<Sura> Suras { get; set; }=new List<Sura>();

        public QuranLoader()
        {
            var lines=File.ReadAllText(@".\raw\quran-simple.txt", Encoding.UTF8).Split("\n");
            Load(lines);
        }

        private void Load(IEnumerable<string> lines)
        {
            int lineId = 0;
            //Fill the Suras List with 114 Id
            for(int i=1;i<115;i++)
            {
                var sura = new Sura() { Id = i };
                while(true)
                {
                    if(lineId == lines.Count())
                    {
                        break;
                    }
                    var line = lines.ElementAt(lineId);
                    string pattern = @"(\d+)\|(\d+)\|(.+)";
                    if(Regex.Match(line, pattern).Success)
                    {
                        int idSura= Convert.ToInt32(Regex.Match(line, pattern).Groups[1].Value);
                        int idVersa= Convert.ToInt32(Regex.Match(line, pattern).Groups[2].Value);
                        string versaText= Regex.Match(line, pattern).Groups[3].Value;
                        if (i == idSura && lineId<lines.Count())
                        {
                            //Remove Harakat
                            versaText = arabicOperations.StripDiacritics(versaText);
                            sura.verses.Add(new Verse() { Text = versaText, Id = idVersa });
                            lineId++;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
                
                Suras.Add(sura);
            }
        }

        private List<LightItem> SurasNames = null;
        /// <summary>
        /// Get the names of the Quran Suras
        /// </summary>
        /// <returns></returns>
        public List<LightItem> GetNames()
        {
            if (SurasNames == null)
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
            else
                return SurasNames.DeepClone();

        }
    }
}
