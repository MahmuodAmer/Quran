using Newtonsoft.Json.Linq;
using PropertyChanged;
using Quran.Core.Extention;
using Quran.Core.Model;
using Quran.UI.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Quran.UI.ViewModels
{
    
    public class MainViewModel:INotifyPropertyChanged
    {
        private IMainDataModel _dataModel { get; set; }

        public MainViewModel(IMainDataModel dataModel)
        {
            _dataModel = dataModel;
            Load();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Load()
        {
            //Load the quran suras names
            Suras= new ObservableCollection<LightItem>(ImportDataExtentions.GetNames());

            //set the selectedSura
            SelectedSura = Suras[0];
            //*********************************************//****************************************************//
            Results = _dataModel.Load(SelectedSura.Id, SearchText);
        }

        /// <summary>
        /// Results 
        /// </summary>
        public SeriesIdxResults Results { get; set; }
        

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
