namespace Pigeon.Zipper.Events
{
    using System;
    using System.Globalization;

    public static class EventDateHelper
    {
        private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;

        private const string DateFormat = "O";

        public static DateTime DeserialiseDate(string dateString)
        {
            return DateTime.ParseExact(dateString, DateFormat, Culture);
        }

        public static string SerialiseDate(DateTime date)
        {
            return date.ToString(DateFormat, Culture);
        }
    }
}