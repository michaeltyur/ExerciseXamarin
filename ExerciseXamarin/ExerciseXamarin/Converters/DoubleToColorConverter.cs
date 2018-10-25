using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Windows.UI.Xaml.Data;

namespace ExerciseXamarin.Converters
{
   public class DoubleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            return new Color();
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
