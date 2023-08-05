using Quran.Core.Extention;
using Quran.Core;
using Quran.Core.Model;

namespace Quran.UI.Data
{
    public class SingleSequanceDataModel : ISingleSequanceDataModel
    {
        private readonly IGeneralConverter generalConverter;

        public SingleSequanceDataModel(IGeneralConverter generalConverter)
        {
            this.generalConverter = generalConverter;
        }
        public SeriesIdxResults Search(int id, string searchText)
        {
            var suraText = generalConverter.SuraIdToString(id);
            return Parser.DetectIndices(suraText, searchText, id);
        }
    }
}
