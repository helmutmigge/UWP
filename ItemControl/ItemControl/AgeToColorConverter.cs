using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace ItemControl
{
    class AgeToColorConverter: Windows.UI.Xaml.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int result =0;
            if (value is string)
            {
                Int32.TryParse((string)value, out result);
            }
            else {
                result = (int)value;
            }

            return GetBrush(result);
        }

        private SolidColorBrush GetBrush(int age) {
            SolidColorBrush brush = new SolidColorBrush();
            if (age > 18)
            {
                brush.Color = Color.FromArgb(255, 166, 193, 67);
            }
            else {
                brush.Color = Color.FromArgb(255, 248, 142, 174);
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
