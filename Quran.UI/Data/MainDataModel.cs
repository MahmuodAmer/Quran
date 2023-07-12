using Quran.Core;
using Quran.Core.Extention;
using Quran.Core.Model;
using System.Collections.Generic;

namespace Quran.UI.Data
{
    public class MainDataModel : IMainDataModel
    {
        public SeriesIdxResults Load(int id, string searchText)
        {
            return Parser.DetectIndices(id.SuraIdToString(), searchText, id);
        }





        public SearchForSimilarOutput SearchForSimilar(int id, string searchText)
        {
            return Parser.SearchForSimilar(id.SuraIdToString(), searchText, id);
        }
    }
}
