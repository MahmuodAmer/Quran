using Quran.Core;
using Quran.Core.Extention;
using Quran.Core.Model;
using Quran.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quran.UI.Data
{
    public class SearchInVerseDataModel : ISearchInVerseDataModel
    {
        private readonly QuranLoader loader;

        public SearchInVerseDataModel(QuranLoader loader)
        {
            this.loader = loader;
        }

        public IReadOnlyList<Sura> LoadSuras()
        {
            return loader.Suras;
        }

        public List<Verse> LoadVerses(int suraId)
        {
            return loader.Suras[suraId - 1].verses;
        }

        public SeriesIdxResults Search(string InputText, string searchText)
        {
            return Parser.DetectIndices(InputText, searchText);
        }
    }
}
