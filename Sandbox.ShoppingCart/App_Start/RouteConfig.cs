using System.Web.Mvc;
using System.Web.Routing;

namespace Sandbox.ShoppingCart
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "categoryFilter",
                url: "Product/Overview/{categoryName}",
                defaults: new { controller = "Product", action = "OverviewCategory"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Product", action = "Overview"}
            );
        }
    }
}
