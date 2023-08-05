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
                value = text.Replace(SearchText, $"<TextBlock Background=\"Yellow\">{SearchText}</TextBlock>");
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
