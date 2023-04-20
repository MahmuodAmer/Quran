using Quran.Core;
using Quran.Core.Extention;
using Quran.Core.Model;


namespace Quran.UI.Data
{
    public class MainDataModel : IMainDataModel
    {
        public SeriesIdxResults Load(int id, string searchText)
        {
            return Parser.DetectIndices(id.SuraIdToString(), searchText, id);
        }
        //public SeriesIdxResults Load(int id, string searchText)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
