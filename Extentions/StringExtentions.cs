using System;

namespace FlightManagement.Extentions
{
    public static class StringExtentions
    {
        public static string ConvertToTime(this string str, string format = "HHmmss", string outputFormat = "HH:mm:ss")
        {
            DateTime flightTime = DateTime.ParseExact(str, format, System.Globalization.CultureInfo.InvariantCulture);
            return flightTime.ToString(outputFormat);
        }
    }
}