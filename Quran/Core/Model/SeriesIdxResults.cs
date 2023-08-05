using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Quran.Core.Model
{
    public class SeriesIdxResults
    {
        public int SuraId { get; set; }
        public string SearchChars { get; set; }
        public ObservableCollection<Result> SearchResults { get; set; }
        public ObservableCollection<int> DiffrenceList { get; set; }
        public Dictionary<string, int> Sequances { get; set; }
        public double[] PolynomialRepresentation { get; set; }
    }
}
