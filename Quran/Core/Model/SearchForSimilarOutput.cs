using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quran.Core.Model
{
    public class SearchForSimilarOutput
    {
        public SeriesIdxResults Refrence { get; set; }
        public List<SearchForSimilarResult> Results { get; set; }
    }
}
