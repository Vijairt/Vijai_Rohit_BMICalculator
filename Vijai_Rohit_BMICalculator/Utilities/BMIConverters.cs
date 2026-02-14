using System.Globalization;

namespace Vijai_Rohit_BMICalculator.Utilities;

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isSelected && isSelected)
        {
            return Colors.Blue;
        }
        return Colors.LightGray;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class ColorToBgConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string colorHex)
        {
            // Convert hex color to Color and then to a semi-transparent background
            try
            {
                var color = Color.FromArgb(colorHex);
                return new Color(color.Red, color.Green, color.Blue, 0.1f);
            }
            catch
            {
                return Colors.Transparent;
            }
        }
        return Colors.Transparent;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
