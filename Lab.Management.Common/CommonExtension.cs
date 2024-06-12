using System;
using System.Globalization;

namespace Lab.Management.Common
{

    public static class CommonExtensions
    {
        public static string ToUstDate(this DateTime? dtValue)
        {
            return dtValue.HasValue ? dtValue.Value.ToString(Constants.UstDateFormat) : DateTime.Now.ToString(Constants.UstDateFormat);
        }

        public static DateTime ToLmsSystemDate(this string inValue)
        {
            if (string.IsNullOrEmpty(inValue))
            {
                return DateTime.Now;
            }

            inValue = inValue.IndexOf(':') > 0 ? inValue : string.Format("{0} 23:58:00", inValue);
            if (inValue.Contains("-"))
            {
                inValue = inValue.Replace("-", "/").Replace("AM", "").Replace("PM", "");
            }

            if (inValue.Contains("AM") || inValue.Contains("PM"))
            {
                inValue = inValue.Replace("AM", "").Replace("PM", "");
            }

            var culture = new CultureInfo("en-US", true);
            try
            {
                var dateValue = DateTime.ParseExact(inValue, "dd/MM/yyyy HH:mm:ss", culture);
                return dateValue;
            }
            catch (Exception)
            {
                return Convert.ToDateTime(inValue);
            }
        }

        public static DateTime AddBeginTime(this DateTime dtValue)
        {
            return new DateTime(dtValue.Year, dtValue.Month, dtValue.Day, 0, 0, 0);
        }

        public static DateTime AddEndTime(this DateTime dtValue)
        {
            return new DateTime(dtValue.Year, dtValue.Month, dtValue.Day, 23, 59, 59);
        }

        public static string ToLmsSystemUsDate(this string inValue)
        {
            if (string.IsNullOrEmpty(inValue))
            {
                return DateTime.Now.ToString("MM/dd/yyyy");
            }

            inValue = inValue.IndexOf(':') > 0 ? inValue : string.Format("{0} 00:00:00", inValue);
            if (inValue.Contains("-"))
            {
                inValue = inValue.Replace("-", "/");
            }

            var culture = new CultureInfo("en-US", true);
            DateTime dateValue = DateTime.ParseExact(inValue, "dd/MM/yyyy HH:mm:ss", culture);
            return dateValue.ToString("MM/dd/yyyy");
        }

        public static string ToLmsSystemIstDateString(this DateTime inValue)
        {
            var culture = new CultureInfo("en-US", true);
            DateTime dateValue = DateTime.ParseExact(inValue.ToString(), "dd/MM/yyyy HH:mm:ss", culture);
            return dateValue.ToString("dd/MM/yyyy");
        }
    }
}
