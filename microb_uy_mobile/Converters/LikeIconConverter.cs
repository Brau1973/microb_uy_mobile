using System;
using System.Globalization;

namespace microb_uy_mobile.Converters
{
    public class LikeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Asume que el valor es un booleano que indica si el post está likeado o no
            bool isLiked = (bool)value;

            // Retorna la imagen correspondiente
            return isLiked ? "fully_like_icon.png" : "empty_like_icon.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // No es necesario en este caso
            throw new NotImplementedException();
        }
    }
}
