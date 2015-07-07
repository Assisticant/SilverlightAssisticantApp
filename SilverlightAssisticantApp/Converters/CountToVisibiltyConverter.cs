using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightAssisticantApp.Converters
{
    public class CountToVisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            culture = new System.Globalization.CultureInfo("en-GB");
            if (value == System.Windows.DependencyProperty.UnsetValue)
            {
                return Visibility.Visible;
            }

            if (value != null)
            {
                int dt = System.Convert.ToInt32(value);
                if (dt > 0)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;

                }

            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
