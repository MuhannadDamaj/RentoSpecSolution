using RentospectShared.CommonEnum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Converters
{
    public class StatusToTextColorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not InspactionStatusEnum status)
                return Color.FromArgb("#4C71AF");

            return status switch
            {
                InspactionStatusEnum.SignatureRequired => Color.FromArgb("#193CB8"),
                InspactionStatusEnum.Pending => Color.FromArgb("#4C71AF"),
                InspactionStatusEnum.TAndCRequired => Color.FromArgb("#973C00"),
                _ => Color.FromArgb("#4C71AF"),  // Default color
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
