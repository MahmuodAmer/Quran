using Quran.Core.Model;

namespace Quran.Core
{
    public class SearchSimilarResultComparator : IComparer<SearchForSimilarResult>
    {
        public int Compare(SearchForSimilarResult x, SearchForSimilarResult y)
        {
            if(x.Error == y.Error)
            {
                return 0;
            }
            if (x.Error > y.Error)
            {
                return -1;
            }
            else
                return +1;

        }
    }
}
