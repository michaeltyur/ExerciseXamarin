using System;
using System.Globalization;
using Xamarin.Forms;

namespace ExerciseXamarin.Converters
{
   public class DoubleToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = (int)((double)value);
             
            return  Color.FromRgb(doubleValue, 255, doubleValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
