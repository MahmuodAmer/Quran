using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Quran.UI.Converters
{
    public class HighlightConverter : IValueConverter
    {
        public static string SearchText { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                //var highlightedText = new StringBuilder();
                //foreach (var c in text)
                //{
                //    if (c == 'T' || c == 't')
                //    {
                //        highlightedText.Append($"<Span Background=\"Yellow\">{c}</Span>");
                //    }
                //    else
                //    {
                //        highlightedText.Append(c);
                //    }
                //}
                //return highlightedText.ToString();
                value = text.Replace(SearchText, $"<TextBlock Background=\"Yellow\">{SearchText}</TextBlock>");
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }
}
