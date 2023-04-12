using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quran.Core
{
    public class Sura
    {
        public int Id { get; set; }
        public List<Verse> verses { get; set; } = new List<Verse>();

        public override string ToString()
        {
            string output = "";
            foreach (var element in verses.Select(v => v.Text + " | " + v.Id.ToString()).ToList())
                output += element.ToString() + "\n";

            return output;

        }
    }
}
