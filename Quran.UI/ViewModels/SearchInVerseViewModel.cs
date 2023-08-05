using Quran.Core.Extention;
using Quran.Core.Model;
using Quran.UI.Command;
using Quran.UI.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quran.UI.ViewModels
{
    public class SearchInVerseViewModel : ViewModelBase, ISearchInVerseViewModel
    {
        private readonly ISearchInVerseDataModel dataModel;
        private readonly ISuraNamesLoader suraNamesLoader;

        public SearchInVerseViewModel(ISearchInVerseDataModel dataModel, ISuraNamesLoader suraNamesLoader)
        {
            this.dataModel = dataModel;
            this.suraNamesLoader = suraNamesLoader;
            Verses = new ObservableCollection<Verse>();
            Load();
        }

        public async Task Load()
        {
            SuraNames = suraNamesLoader.GetNames();
        }

        public ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {

                    _searchCommand = new RelayCommand(
                        param => this.Search(),
                        param => this.CanSave()
                    );
                }
                return _searchCommand;
            }
        }

        private void Search()
        {
            if (SelectedVerse == null || SearchText == null || SearchText == "")
                return;

            var inputText = SelectedVerse.Text;
            var searchText = SearchText;


            Results = dataModel.Search(inputText, searchText);
        }

        private bool CanSave()
        {
            return true;
        }
        public SeriesIdxResults Results { get; set; }
        public IEnumerable<LightItem> SuraNames { get; set; }
        private LightItem selectedSura;
        public LightItem SelectedSura
        {
            get { return selectedSura; }
            set
            {
                selectedSura = value;

                if (selectedSura != null)
                {
                    Verses.Clear();
                    dataModel.LoadVerses(selectedSura.Id).ForEach(element => Verses.Add(element));
                }
            }
        }
        public ObservableCollection<Verse> Verses { get; set; } = new ObservableCollection<Verse>();
        public Verse SelectedVerse { get; set; }
        public string SearchText { get; set; }
    }
}
