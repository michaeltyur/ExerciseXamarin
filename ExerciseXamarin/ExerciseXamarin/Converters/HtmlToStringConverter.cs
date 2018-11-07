using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExerciseXamarin.Converters
{
    public class HtmlToStringConverter : IValueConverter
    {

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>|", string.Empty);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = StripTagsRegex((string)value);
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
