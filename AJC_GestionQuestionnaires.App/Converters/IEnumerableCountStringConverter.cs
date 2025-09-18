using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AJC_GestionQuestionnaires.App.Converters;


[ValueConversion(typeof(IEnumerable<object>), typeof(string))]
class IEnumerableCountConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var count = ((IEnumerable<object>)value).Count();
        return $"({count} Questions)";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
