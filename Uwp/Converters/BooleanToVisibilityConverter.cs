using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Uwp.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter is null)
            {
                return (value as bool?).Value ? Visibility.Visible : Visibility.Collapsed;
            }
            return (value as bool?).Value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
