using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace GettingStartedWebClient.Implementation.SignalR
{
  [HubName("testhub")]
  public class MyHub : Hub
  {
    //required to let the Hub be called from other server-side classes/controllers
    private static readonly IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

    public void DisplayResult(string calculatorValue) //todo remove this stuff
    {
      var message = $">>> Value passed to hub was {calculatorValue}";
      Debug.WriteLine(message);
      HubContext.Clients.All.display(message);
    }
  }
}