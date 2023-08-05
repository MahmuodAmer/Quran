using Quran.Core.Model;

namespace Quran.UI.Data
{
    public interface ISingleSequanceDataModel
    {
        SeriesIdxResults Search(int id, string searchText);
    }
}