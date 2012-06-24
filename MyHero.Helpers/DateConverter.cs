using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace MyHero.Helpers
{
    public class DateConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                DateTime dateNow = DateTime.Now;
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                dtDateTime = dtDateTime.AddSeconds((int)value).ToLocalTime();
                TimeSpan datediff = dateNow.Subtract(dtDateTime);

                if (datediff.Days == 0)
                {
                    return datediff.Hours + " h";
                }
                else
                    return String.Format("{0} j {1} h",datediff.Days, datediff.Hours);

            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
