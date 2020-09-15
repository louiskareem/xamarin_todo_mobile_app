using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;

namespace MobileTodoApp
{
    public class ChangeCompleteActionTextConverter : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo cultureInfo)
        {
            var isCompleted = (bool)value;
            return isCompleted ? "Uncomplete" : "Complete";
        }

        public object ConvertBack (object value, Type type, object parameter, CultureInfo cultureInfo)
        {
            // Not used since we only want to convert a boolean to text, and not the other way around
            throw new NotImplementedException();
        }
    }
}
