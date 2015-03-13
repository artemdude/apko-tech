using System;
using APKO.Helpers;

namespace APKO.Models
{
 

    public class AnalyticsViews
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Views { get; set; }
        public string Visitors { get; set; }
        public string Entrances { get; set; }
    }

    public class AnalyticsGeneral
    {
        public string Visits { get; set; }
        public string Views { get; set; }
    }

    public class AnalyticsCountry
    {
        public string Visits { get; set; }
        public string Country { get; set; }
    }

    public class AnalyticsKeyword
    {
        public string Visits { get; set; }
        public string Keyword { get; set; }
    }

    public class AnalyticsSource
    {
        public string Visits { get; set; }
        public string Source { get; set; }
    }

    public class GaFeedParameters
    {
        public string Metrics { get; set; }
        public string Dimension { get; set; }
        public string Token { get; set; }
        public string Account { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ResultCount { get; set; }
        public string SortBy { get; set; }
    }

    internal class DateConsts
    {
        public const string Month = "month";
        public const string Week = "week";
        public const string Yesterday = "yesterday";
    }
}