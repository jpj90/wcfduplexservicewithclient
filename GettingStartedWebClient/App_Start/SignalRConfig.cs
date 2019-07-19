using GettingStartedWebClient.Implementation.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Owin;

namespace GettingStartedWebClient.App_Start
{
  public static class SignalRConfig
  {
    public static IAppBuilder UseSignalR(this IAppBuilder app)
    {
      var settings = JsonSettings.GetSettings();
      settings.ContractResolver = new SignalRContractResolver();

      GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => JsonSerializer.Create());

      return app.Map("/signalr", map =>
      {
        map.UseCors(CorsOptions.AllowAll);
        map.RunSignalR(new HubConfiguration
        {
          EnableDetailedErrors = true
        });
      });
    }
  }
}