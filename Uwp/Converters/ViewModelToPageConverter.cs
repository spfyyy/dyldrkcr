using System;
using System.Linq;
using System.Reflection;
using Windows.UI.Xaml.Data;

namespace Uwp.Converters
{
    /// <summary>
    /// This converter uses reflection to find a Page type that matches the given viewmodel.
    /// For example, LoginPageViewModel will map to LoginPage.
    /// </summary>
    public class ViewModelToPageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var name = value.GetType().Name.Split("ViewModel")[0];
            var type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == name).First();
            return Activator.CreateInstance(type);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
