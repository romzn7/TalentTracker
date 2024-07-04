using Microsoft.AspNetCore.Mvc;

namespace TalentTracker.Web.Routing;

public class TalentTrackerRouteAttribute : RouteAttribute

{
    private const string _routePrefix = "api/tms";

    /// <summary>
    /// Creates a route, prefixed by the api/master-settings
    /// </summary>
    /// <param name="template"></param>
    public TalentTrackerRouteAttribute(string template) :
            base($"{_routePrefix}{template}")
    {
    }
}
