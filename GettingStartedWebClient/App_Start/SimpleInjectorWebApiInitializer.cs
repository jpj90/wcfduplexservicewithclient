[assembly: WebActivator.PostApplicationStartMethod(typeof(GettingStartedWebClient.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace GettingStartedWebClient.App_Start
{
    using System.Web.Http;
  using GettingStartedWebClient.Interfaces;
  using GettingStartedWebClient.Models;
  using GettingStartedWebClient.ServiceReference1;
  using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
          // Register your services here , for instance:
          container.Register<ICalculatorDuplexCallback, CallbackHandler>(Lifestyle.Singleton);
          container.Register<ICalculatorDuplexWcfClient, CalculatorDuplexWcfClient>(Lifestyle.Singleton);
    }
  }
}