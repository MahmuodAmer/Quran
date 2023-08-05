namespace Quran.Core.Extention
{
    public class GeneralConverter : IGeneralConverter
    {
        private readonly QuranLoader loader;

        public GeneralConverter(QuranLoader loader)
        {
            this.loader = loader;
        }
        /// <summary>
        /// Give it the Sura Id and it will return the text of the sura
        /// </summary>
        /// <param name="id">The index of the sura starts from 1</param>
        /// <returns></returns>
        public string SuraIdToString(int id)
        {
            var s = loader.Suras;
            return s[id - 1].ToString();
        }
    }
}
