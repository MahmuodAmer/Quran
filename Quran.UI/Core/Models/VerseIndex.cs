using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quran.UI.Core.Models
{
    public class VerseIndex
    {
        public VerseIndex()
        {

        }
        public int SuraId { get; set; }
        public int VerseId { get; set; }
        public int CharIndex { get; set; }
    }
}
