using Quran.Core.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quran.UI.ViewModels
{
    public interface ISearchInVerseViewModel
    {
        SeriesIdxResults Results { get; set; }
        ICommand SearchCommand { get; }
        string SearchText { get; set; }
        LightItem SelectedSura { get; set; }
        Verse SelectedVerse { get; set; }
        IEnumerable<LightItem> SuraNames { get; set; }
        ObservableCollection<Verse> Verses { get; set; }

        Task Load();
    }
}