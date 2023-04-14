using Quran.UI.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quran.UI.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel(IMainModel mainModel)
        {
            MainModel = mainModel;
        }
        public void Load()
        {
            SearchResult = new ObservableCollection<VerseIndex>(MainModel.Load());
        }

        public ObservableCollection<VerseIndex> SearchResult { get; set; }
        public IMainModel MainModel { get; set; }
    }
}
