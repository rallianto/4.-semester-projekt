using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CrossApp.PCL.Converters
{
    public class DateTimeToStringValueConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString("dd/MM/yyyy");
        }
    }
}
