using System;
using System.Web;

namespace APKO.Helpers
{
    public class GetUrl
    {
        public static string Domain()
        {
            return HttpContext.Current.Request.Url.Scheme + Uri.SchemeDelimiter
                   + HttpContext.Current.Request.Url.Host;
        }
    }
}