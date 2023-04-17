using System.Text;
using System.Text.RegularExpressions;
using Quran.Core.Model;

namespace Quran.Core
{
    /// <summary>
    /// Load all the Quran text into it
    /// </summary>
    public class QuranLoader
    {
        private static QuranLoader _instance=null;
        public List<Sura> Suras { get; set; }=new List<Sura>();
        public static QuranLoader GetInstance()
        {
            if(_instance == null )
                _instance= new QuranLoader();

            return _instance;
        }

        private QuranLoader()
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
                            versaText = versaText.StripDiacritics();
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
    }
}
