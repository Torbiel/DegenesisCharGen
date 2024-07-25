using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace DegenesisCharGen.Converters;

public class IntToBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is int intValue && parameter is string paramString && int.TryParse(paramString, out var paramValue)
            ? intValue == paramValue
            : (object)false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool boolValue && boolValue && parameter is string paramString && int.TryParse(paramString, out var paramValue)
            ? paramValue
            : (object)0;
    }
}
