using Quran.Core.Extention;
using Quran.Core.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Quran.UI.Data;
using System.Windows.Input;
using Quran.UI.Command;

namespace Quran.UI.ViewModels
{
    public class SingleSequanceViewModel : ViewModelBase, ISingleSequanceViewModel
    {
        private ISingleSequanceDataModel dataModel;
        private readonly ISuraNamesLoader suraNamesLoader;

        public SingleSequanceViewModel(ISingleSequanceDataModel dataModel, ISuraNamesLoader suraNamesLoader)
        {
            this.dataModel = dataModel;
            this.suraNamesLoader = suraNamesLoader;
        }

        /// <summary>
        /// Results 
        /// </summary>
        public SeriesIdxResults Results { get; set; }

        public async Task Load()
        {
            //Load the quran suras names
            Suras = new ObservableCollection<LightItem>(suraNamesLoader.GetNames());

            //set the selectedSura
            SelectedSura = Suras[0];
            //*********************************************//****************************************************//
            Results = dataModel.Search(SelectedSura.Id, SearchText);
            // dataModel.SearchForSimilar(SelectedSura.Id, SearchText);
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

        private bool CanSave()
        {
            return true;
        }

        private void Search()
        {
            Results = dataModel.Search(SelectedSura.Id, SearchText);
        }

        /// <summary>
        /// The names of quran suras to show in the combobox
        /// </summary>
        public ObservableCollection<LightItem> Suras { get; set; }

        /// <summary>
        /// Selected sura to work with 
        /// </summary>
        public LightItem SelectedSura { get; set; }

        /// <summary>
        /// Search Text that will be linked to the TextBox
        /// </summary>
        public string SearchText { get; set; } = "";


        /// <summary>
        /// The selected Result
        /// </summary>
        public Result SelectedResult { get; set; }
    }
}
