using System.Threading.Tasks;

namespace Quran.UI.ViewModels
{
    public interface ITwoVerseComparisonViewModel
    {
        ISearchInVerseViewModel SearchInVerseViewModel1 { get; set; }
        ISearchInVerseViewModel SearchInVerseViewModel2 { get; set; }

        Task Load();
    }
}