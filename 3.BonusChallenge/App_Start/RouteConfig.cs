using System.Web.Mvc;
using System.Web.Routing;

namespace _3.BonusChallenge_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("Index", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("About", "{controller}/{action}/{id}", new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
        }
    }
}
