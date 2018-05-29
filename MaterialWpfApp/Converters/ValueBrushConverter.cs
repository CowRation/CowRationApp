using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MaterialWpfApp.Converters
{
    class ValueBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double day = System.Convert.ToDouble(value);
            if (day<0)
            {
                return Brushes.Red;
            }
            if (day == 0)
            {
                return Brushes.YellowGreen;
            }
            if (day > 0)
            {
                return Brushes.Green;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
