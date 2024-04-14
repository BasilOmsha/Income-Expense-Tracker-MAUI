using System.Globalization;

namespace incomeExpensTrckMAUI.Helpers
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringDate)
            {
                return DateTime.Parse(stringDate); 
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dt)
            {
                return dt.ToString(); 
            }
            return value;
        }
    }
}
