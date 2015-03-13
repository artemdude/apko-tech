using System;


namespace APKO.Helpers
{
    public static class DateFormatter
    {

        public static string DateToShort(DateTime dateTime)
        {
            return dateTime.ToString("d MMMM yyyy");
        }

        public static string DateToShortString(DateTime dateTime)
        {
            string dayOfWeek;

            if (dateTime.Date == DateTime.Today)
            {
                dayOfWeek = Resources.Additional.DateFormatter.Today;
            }
            else if (dateTime.Date == DateTime.Today.AddDays(+1))
            {
                dayOfWeek = Resources.Additional.DateFormatter.Tomorrow;
            }
            else
            {
                dayOfWeek = dateTime.ToString("dddd");
            }

            string date;

            if (dateTime.Year == DateTime.Today.Year)
            {
                date = dateTime.ToString("d MMMM");
            }
            else
            {
                date = dateTime.ToString("d MMMM yyyy");
            }

            return string.Format("{0} {1}, {2}", dayOfWeek, date, dateTime.ToShortTimeString());
        }

        public static string DateToShortStringDay(DateTime dateTime)
        {
            string dayOfWeek;

            if (dateTime.Date == DateTime.Today)
            {
                dayOfWeek = Resources.Additional.DateFormatter.Today;
            }
            else if (dateTime.Date == DateTime.Today.AddDays(+1))
            {
                dayOfWeek = Resources.Additional.DateFormatter.Tomorrow;
            }
            else
            {
                dayOfWeek = dateTime.ToString("ddd");
            }

            string date;

            if (dateTime.Year == DateTime.Today.Year)
            {
                date = dateTime.ToString("d MMM");
            }
            else
            {
                date = dateTime.ToString("d MMM yyyy");
            }

            return string.Format("{0}, {1}", dayOfWeek, date);
        }

        public static string DateToLongString(DateTime dateTime)
        {
            return "Method is not implemented";
        }

        public static string DateToLongDetailedString(DateTime dateTime)
        {
            return "Method is not implemented";
        }

    }
}