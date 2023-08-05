namespace Quran.Core.Model
{
    public class Verse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Id_Text
        {
            get
            {
                return " "+Id.ToString() + " - "+ Text;
            }
        }
    }
}
