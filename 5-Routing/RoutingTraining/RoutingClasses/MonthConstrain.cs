using System.Text.RegularExpressions;

namespace RoutingTraining.RoutingClasses
{
    public class MonthConstrain : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route,
            string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
                return false;
            Regex x = new Regex("^(jan|spr|jul|oct)$");
            if (x.IsMatch((string)values[routeKey])) 
                return true;
            return false;
        }
    }
}
