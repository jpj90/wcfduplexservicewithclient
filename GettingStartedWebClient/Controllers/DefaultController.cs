using System.ServiceModel;
using System.Threading;
using System.Web.Http;
using GettingStartedWebClient.Implementation.SignalR;
using GettingStartedWebClient.Interfaces;
using GettingStartedWebClient.Models;
using GettingStartedWebClient.ServiceReference1;

namespace GettingStartedWebClient.Controllers
{
  public class DefaultController : ApiController
    {
      private readonly ICalculatorDuplexWcfClient _client;
      public DefaultController(ICalculatorDuplexWcfClient client)
      {
        _client = client;
      }

      [HttpGet]
      public IHttpActionResult CallWcf()
      {
        var hub = new MyHub();
        // Call the AddTo service operation.
        double value = 100.00D;
        _client.AddTo(value);

        hub.DisplayResult(value.ToString());
        // Call the SubtractFrom service operation.
        value = 50.00D;
        _client.SubtractFrom(value);

        hub.DisplayResult(value.ToString());
        // Call the MultiplyBy service operation.
        value = 17.65D;
        _client.MultiplyBy(value);

        hub.DisplayResult(value.ToString());
        // Call the DivideBy service operation.
        value = 2.00D;
        _client.DivideBy(value);

        hub.DisplayResult(value.ToString());
        // Complete equation
        _client.Clear();
        
        return Ok("process completed, check Debug console");
      }
    }
}
