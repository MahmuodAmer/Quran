﻿using Quran.Core.Model;

namespace Quran.UI.Data
{
    public interface IMainDataModel
    {
        public SeriesIdxResults Load(int id, string searchText);
        public void SearchForSimilar(int id, string searchText);
    }
}