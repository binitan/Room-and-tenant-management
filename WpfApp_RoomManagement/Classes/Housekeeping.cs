using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp_RoomManagement.Classes
{
    public class Housekeeping : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool what = (bool)value;
            if (what)
                return "Clean";
            else
                return "In Progress";
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Contains("Is"))
                return false;
            else
                return true;
        }
    }
}
