using Avalonia.Data.Converters;
using DegenesisCharGen.Enums;
using DegenesisCharGen.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DegenesisCharGen.Converters;

public class SkillsFilterConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is IEnumerable<Skill> skills && parameter is AttributeName attributeName
            ? skills.Where(skill => skill.Attribute == attributeName).ToList()
            : (object?)null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
