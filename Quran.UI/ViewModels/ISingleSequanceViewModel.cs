using Quran.Core.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quran.UI.ViewModels
{
    public interface ISingleSequanceViewModel
    {
        SeriesIdxResults Results { get; set; }
        ICommand SearchCommand { get; }
        string SearchText { get; set; }
        Result SelectedResult { get; set; }
        LightItem SelectedSura { get; set; }
        ObservableCollection<LightItem> Suras { get; set; }

        Task Load();
    }
}