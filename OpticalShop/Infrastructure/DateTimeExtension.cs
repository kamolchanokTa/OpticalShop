using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OpticalShop.Infrastructure
{
    /// <summary>
    /// Extension to provide datetime & string conversion
    /// </summary>
    public static class DateTimeExtension
    {

        /// <summary>
        /// To date format
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;
            else
                return ToDateString(date.Value);
        }

        /// <summary>
        /// To date format
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime date)
        {
            return date.ToString(WebConfiguration.DateFormat);
        }

        /// <summary>
        /// To date time format
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime? datetime)
        {
            if (!datetime.HasValue)
                return string.Empty;
            else
                return ToDateTimeString(datetime.Value);
        }

        /// <summary>
        /// To date time format
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime datetime)
        {
            return datetime.ToString(WebConfiguration.DateFormat + " " + WebConfiguration.TimeFormat);
        }


        /// <summary>
        /// To date (if string is empty it will be return null value)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime? ToDate(this string date)
        {
            if (string.IsNullOrEmpty(date))
                return null;
            else
                return DateTime.ParseExact(date, WebConfiguration.DateFormat, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// To date (if string is empty it will be return null value)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string datetime)
        {
            if (string.IsNullOrEmpty(datetime))
                return null;
            else
                return DateTime.ParseExact(datetime, WebConfiguration.DateFormat + " " + WebConfiguration.TimeFormat, CultureInfo.CurrentCulture);
        }
    }
}