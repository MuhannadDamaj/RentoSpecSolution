using RentospectShared.CommonEnum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not InspactionStatusEnum status)
                return Color.FromArgb("#E3EBF8");

            return status switch
            {
                InspactionStatusEnum.SignatureRequired => Color.FromArgb("#DBEAFE"),
                InspactionStatusEnum.Pending => Color.FromArgb("#E3EBF8"),
                InspactionStatusEnum.TAndCRequired => Color.FromArgb("#fef3c7"),
                _ => Color.FromArgb("#E3EBF8"),  // Default color
            };
        }
        public static object GetResourceValue(string keyName)
        {
            return Application.Current.Resources.TryGetValue(keyName, out var retVal) ? retVal : null;
        }
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
