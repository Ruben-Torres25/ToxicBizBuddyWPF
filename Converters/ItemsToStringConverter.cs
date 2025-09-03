using System;
using System.Globalization;
using System.Windows.Data;

namespace ToxicBizBuddyWPF.Converters
{
    public sealed class ItemsToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int count)
                return count == 1 ? "1 item" : $"{count} items";
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => Binding.DoNothing;
    }
}
