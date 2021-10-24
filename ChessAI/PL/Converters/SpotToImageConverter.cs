using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PL.Converters
{
    class SpotToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parameterString = parameter as string;
            string[] parameters = parameterString.Split(new char[] { '|' });
            int i = int.Parse(parameters[0]);
            int j = int.Parse(parameters[1]);
            //if (!string.IsNullOrEmpty(parameterString) && game.board.boxes[i, j].getPiece() != null)
            //{
            //    return game.board.boxes[i, j].getPiece().getImage().ToString();
            //}
            if ((i + j) % 2 == 0)
                return @"/images/gray.png";
            return @"/images/defaultWhite.png";
        }

 

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
