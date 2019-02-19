using System;
using Windows.UI.Xaml.Data;

namespace Uwp.Converters
{
    public class PercentageToWidthDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var percentage = (value as int?).Value;
            var inverse = bool.Parse(parameter.ToString());
            if (inverse)
            {
                return $"{100 - percentage}*";
            }
            return $"{percentage}*";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
