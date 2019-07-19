using GettingStartedWebClient.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GettingStartedWebClient.Startup))]

namespace GettingStartedWebClient
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
      app.UseSignalR();
    }
  }
}
