using Quran.Core.Model;
using System.Collections.Generic;

namespace Quran.Core.Extention
{
    public interface ISuraNamesLoader
    {
        public List<LightItem> GetNames();
    }
}