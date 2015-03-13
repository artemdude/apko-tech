using System.Web.Mvc;

namespace APKO.Helpers
{
    public static class CustomHtmlHelpers
    {
        public static string RouteUrl(this HtmlHelper helper, string routeName)
        {
            return RouteUrl(helper, routeName, null);
        }


        public static string RouteUrl(this HtmlHelper helper, string routeName, object routeValues)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            string url = urlHelper.RouteUrl(routeName, routeValues);

            if (url == "/")
            {
                return url;
            }

            return url + "/";
        }
    }
}