using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quran.Core
{
    public static class ArabicOperations
    {
        #region Text Utilites

        private static readonly string[] DIACRITICS = Enumerable.Range(0x0600, 0x06ff - 0x0600 + 1)
                .Where(x => CharUnicodeInfo.GetUnicodeCategory((char)x) == UnicodeCategory.NonSpacingMark)
                .Select(x => ((char)x).ToString())
                .ToArray();

            public static string StripDiacritics(this string text)
            {
                if (string.IsNullOrEmpty(text))
                    return text;

                foreach (var charValue in DIACRITICS)
                    text = text.Replace(charValue, "");

                return text;
            }



        public static string SimplifyVerse(this string text)
        {
            if(text.Length== 0) return text;
            if (text.Split("\n").Length > 3)
            {
                return text.Split("\n")[0] + "\n.\n.\n" + text.Split("\n")[text.Split("\n").Length - 1]+"\n";
            }
            else
                return text;
        }

        #endregion

    }
}
