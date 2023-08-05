using System.Threading.Tasks;

namespace Quran.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ISingleSequanceViewModel singleSequanceViewModel;
        private readonly ISingleSequanceViewModel singleSequanceViewModel2;
        private readonly ISingleSequanceViewModel singleSequanceViewModel3;
        private readonly ITwoVerseComparisonViewModel twoVerseComparisonViewModel;

        public MainViewModel(ISingleSequanceViewModel singleSequanceViewModel,
                                ISingleSequanceViewModel singleSequanceViewModel2,
                                ISingleSequanceViewModel singleSequanceViewModel3,
                                ITwoVerseComparisonViewModel TwoVerseComparisonViewModel)
        {
            this.singleSequanceViewModel = singleSequanceViewModel;
            this.singleSequanceViewModel2 = singleSequanceViewModel2;
            this.singleSequanceViewModel3 = singleSequanceViewModel3;
            this.twoVerseComparisonViewModel = TwoVerseComparisonViewModel;
            Load();
        }

        public async Task Load()
        {
            await singleSequanceViewModel.Load();
            await singleSequanceViewModel2.Load();
            await singleSequanceViewModel3.Load();
            await twoVerseComparisonViewModel.Load();
        }

        public ISingleSequanceViewModel SingleSequanceViewModel
        {
            get
            {
                return singleSequanceViewModel;
            }
        }
        public ISingleSequanceViewModel SingleSequanceViewModel2
        {
            get
            {
                return singleSequanceViewModel2;
            }
        }
        public ISingleSequanceViewModel SingleSequanceViewModel3
        {
            get
            {
                return singleSequanceViewModel3;
            }
        }
        public ITwoVerseComparisonViewModel TwoVerseComparisonViewModel
        {
            get
            {
                return twoVerseComparisonViewModel;
            }
        }

    }
}
