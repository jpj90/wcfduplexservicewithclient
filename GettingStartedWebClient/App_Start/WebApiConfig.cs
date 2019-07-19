using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GettingStartedWebClient
{
    public static class WebApiConfig
    {
      public static void Register(HttpConfiguration config)
      {
        //https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
        // Web API configuration and services
        var cors = new EnableCorsAttribute("http://localhost:4200","*","*"); //allow any headers and methods
        config.EnableCors(cors); //enable for alle controllers and methods
        // Web API routes
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
      }
    }
}
