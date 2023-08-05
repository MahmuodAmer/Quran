using System.Collections.Generic;

namespace Quran.Core.Model
{
    public class SearchForSimilarOutput
    {
        public SeriesIdxResults Refrence { get; set; }
        public List<SearchForSimilarResult> Results { get; set; } = new List<SearchForSimilarResult>();
    }   
}
