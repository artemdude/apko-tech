using System;
using System.Web;
using System.Web.Routing;

namespace APKO.Helpers.routs
{
    public class IsCategory : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object value;

            if (!values.TryGetValue(parameterName, out value))
            {
                return false;
            }

            if ((string) value == "cat1")
            {
                return true;
            }

            return false;
        }
    }
}