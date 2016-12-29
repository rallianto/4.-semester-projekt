using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CrossApp.PCL.ServiceModels;

namespace CrossApp.PCL.Converters
{
    public class JobTypesToStringValueConverter : MvxValueConverter<List<JobTypes>, string>
    {
        protected override string Convert(List<JobTypes> value, Type targetType, object parameter, CultureInfo culture)
        {
            var returnString = "";
            int i = 0;

            foreach (var item in value)
            {
                returnString += item.ToString();
                if ((i+1) != value.Count)
                    returnString += ", ";
                i++;
            }
            return returnString;
        }
    }
}
