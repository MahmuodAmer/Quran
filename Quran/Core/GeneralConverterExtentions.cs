namespace Quran.Core
{
    public static class GeneralConverterExtentions
    {
        /// <summary>
        /// Give it the Sura Id and it will return the text of the sura
        /// </summary>
        /// <param name="id">The index of the sura starts from 1</param>
        /// <returns></returns>
        public static string SuraIdToString(this int id)
        {
            QuranLoader manager = QuranLoader.GetInstance();
            var s = manager.Suras;
            return s[id - 1].ToString();
        }
    }
}
