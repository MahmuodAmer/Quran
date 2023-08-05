using System.Threading.Tasks;

namespace Quran.UI.ViewModels
{
    public class TwoVerseComparisonViewModel : ViewModelBase, ITwoVerseComparisonViewModel
    {
        public TwoVerseComparisonViewModel(ISearchInVerseViewModel searchInVerseViewModel1, ISearchInVerseViewModel searchInVerseViewModel2)
        {
            SearchInVerseViewModel1 = searchInVerseViewModel1;
            SearchInVerseViewModel2 = searchInVerseViewModel2;
        }

        public async Task Load()
        {
            await SearchInVerseViewModel1.Load();
            await SearchInVerseViewModel2.Load();
        }
        public ISearchInVerseViewModel SearchInVerseViewModel1 { get; set; }
        public ISearchInVerseViewModel SearchInVerseViewModel2 { get; set; }
    }
}
