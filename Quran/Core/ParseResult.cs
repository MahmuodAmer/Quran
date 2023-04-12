namespace Quran.Core
{
    public class ParseResult
    {
        /// <summary>
        /// The Id of the sura
        /// </summary>
        public int SuraId { get; set; }
        /// <summary>
        /// The SearchText => the text to search with it in the sura
        /// </summary>
        public string SearchText { get; set; }
        public int NumberOfAppearing { get; set; }
        public List<int> RepeatedIndexs { get; set; }
        /// <summary>
        /// مصفوفة الفروقات بين اماكن ظهور الاحرف
        /// </summary>
        public List<int> DiffrencesList { get; set; }
        public int DiffrencesListCount
        {
            get
            {
                return DiffrencesList.Count;
            }
        }
        /// <summary>
        /// المتكرر من   مصفوفة الفروقات بين الاحرف 
        /// </summary>
        public IEnumerable<int> Matches { get; set; }
        /// <summary>
        /// التعويض باماكن ظهور الأحرف في مصفوفة الفروقات"
        /// </summary>
        public List<List<List<int>>> Series { get; set; }
        /// <summary>
        ///  الايات التي ظهر فيها التكرار'
        /// </summary>
        public string OutputString { get; set; }
    }
}