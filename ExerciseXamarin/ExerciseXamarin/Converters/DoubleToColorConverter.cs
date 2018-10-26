using System;
using System.Globalization;
using Xamarin.Forms;

namespace ExerciseXamarin.Converters
{
   public class DoubleToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var _value = (int)value;
             
            return  Color.FromRgb(255-_value, _value, 255);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.FromRgb(255, 255, 255 );
        }
    }
}
