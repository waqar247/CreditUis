using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CreditCard.Converter
{
    public class CreditCardNumberValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          //  if (value != null)
          //  {
                
                var builder = new StringBuilder(Regex.Replace(value.ToString(), @"\D", ""));
                foreach (var i in Enumerable.Range(0, builder.Length / 4).Reverse())
                    builder.Insert(4 * i + 4, " ");

                return builder.ToString().Trim();
          //  }
           // return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
         //   if (value != null)
         //   {
                return Regex.Replace(value.ToString(), @"\D", "");
           // }
           // return "";
          
        }
    }
}
