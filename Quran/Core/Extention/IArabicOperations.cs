namespace Quran.Core.Extention
{
    public interface IArabicOperations
    {
        string SimplifyVerse(string text);
        string StripDiacritics(string text);
    }
}