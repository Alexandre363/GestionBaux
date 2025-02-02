using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace projet_location.View.converter
{
    public class ConvertisseurLargeurPadding : IValueConverter
    {
        /// <summary>
        /// Utilisé pour convertire la largeur d'un padding en fonction de la taille de la fenetre
        /// </summary>
        /// <param name="value">la valeur a convertir</param>
        /// <param name="targetType">le type dans lequel on veut convertir la valeur</param>
        /// <param name="parameter">les paramètres utilisée pour convertir</param>
        /// <param name="culture">La culture à utilisé pour convertir</param>
        /// <returns>La valeur convertie</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object res = new Thickness(0);
            if (value is double width)
            {
                double paddingValue = width / 12.5;
                res = new Thickness(paddingValue, 2, paddingValue, 2);
            }
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}