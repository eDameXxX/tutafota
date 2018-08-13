using System;
using Windows.UI.Xaml.Data;

namespace Fotooo.Common
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var invert = (parameter != null) && System.Convert.ToBoolean(parameter);

            var isVisible = value != null;

            if (invert)
            {
                isVisible = !isVisible;
            }

            return isVisible.ToVisibility();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
