using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using GettingStartedWebClient.ServiceReference1;
using GettingStartedWebClient.Models;
using GettingStartedWebClient.Interfaces;

namespace GettingStartedWebClient
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          // Create the container as usual.
          var container = new Container();
          container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

          // Register your types, for instance using the scoped lifestyle:
          container.Register<ICalculatorDuplexCallback, CallbackHandler>(Lifestyle.Singleton);
          container.Register<ICalculatorDuplexWcfClient, CalculatorDuplexWcfClient>(Lifestyle.Singleton);

          // This is an extension method from the integration package.
          container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

          container.Verify();

          GlobalConfiguration.Configuration.DependencyResolver =
              new SimpleInjectorWebApiDependencyResolver(container);

          GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
