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

        public List<SeriesIdxResults> SearchForSimilar(int id, string searchText)
        {
            return  Parser.SearchForSimilar(id.SuraIdToString(), searchText, id);

        }

        void IMainDataModel.SearchForSimilar(int id, string searchText)
        {
            throw new System.NotImplementedException();
        }
    }
}
