using Quran.Core.Model;
using System.Collections.Generic;

namespace Quran.UI.Data
{
    public interface ISearchInVerseDataModel
    {
        IReadOnlyList<Sura> LoadSuras();
        List<Verse> LoadVerses(int suraId);
        SeriesIdxResults Search(string InputText, string searchText);
    }
}