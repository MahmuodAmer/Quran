using Quran.UI.Core.Models;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Quran.UI.ViewModels
{
    public interface IMainModel
    {
        public List<VerseIndex> Load();
    }
}