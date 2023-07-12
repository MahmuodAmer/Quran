using Newtonsoft.Json.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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

    public class MainViewModel : INotifyPropertyChanged
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
            Suras = new ObservableCollection<LightItem>(ImportDataExtentions.GetNames());

            //set the selectedSura
            SelectedSura = Suras[0];
            //*********************************************//****************************************************//
            Results = _dataModel.Load(SelectedSura.Id, SearchText);
            // _dataModel.SearchForSimilar(SelectedSura.Id, SearchText);
            GraphModel = CreatePlotModel();
        }

        public PlotModel GraphModel { get; set; }

        public PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel();
            var verticalAxis = new LinearAxis { Position = AxisPosition.Left, Minimum = -10, Maximum = 10 };
            plotModel.Series.Add(new FunctionSeries(x => 3 * x * x, -10, 10, .1));

            return plotModel;
        }

        public SearchForSimilarOutput SearchForSimilar()
        {
            return _dataModel.SearchForSimilar(SelectedSura.Id, SearchText);
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
