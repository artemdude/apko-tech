using System.Collections.Generic;
using System.Web.Mvc;

namespace APKO.Models.ViewModels.Admin
{
    public class AnalyticsViewModel
    {
        public ICollection<AnalyticsViews> AnalyticsViewsData { get; set; }
        public ICollection<AnalyticsCountry> AnalyticsCountryData { get; set; }
        public ICollection<AnalyticsKeyword> AnalyticsKeywordData { get; set; }
        public ICollection<AnalyticsSource> AnalyticsSourceData { get; set; }
        public SelectList Date { get; set; }
        public SelectList ItemCount { get; set; }
        public SelectList Type { get; set; }
        public AnalyticsGeneral AnalyticsGeneral { get; set; }
    }


}