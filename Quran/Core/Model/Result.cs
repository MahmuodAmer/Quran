namespace Quran.Core.Model
{
    public class Result
    {
        /// <summary>
        /// Index that count only the chars
        /// </summary>
        public int CharIndex { get; set; }
        /// <summary>
        /// Index that count spaces and new lines with chars
        /// </summary>
        public int SpacesIndex{ get; set; }
        /// <summary>
        /// The Index of the verse
        /// </summary>
        public int VerseIndex { get; set; }
        /// <summary>
        /// The Text of the verse
        /// </summary>
        public string VerseText { get; set; }
        /// <summary>
        /// The Next Result to the current result
        /// </summary>
        public Result Next { get; set; }
    }
}
