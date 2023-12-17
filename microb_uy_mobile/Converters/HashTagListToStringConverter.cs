using microb_uy_mobile.DTOs;
using System.Globalization;

namespace microb_uy_mobile.Converters
{
    public class HashTagListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<HashTagDto> hashTags)
            {
                return string.Join(" ", hashTags.Select(tag => $"#{tag.NombreHT}"));
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
