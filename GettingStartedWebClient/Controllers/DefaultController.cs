using System.ServiceModel;
using System.Threading;
using System.Web.Http;
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
        // Call the AddTo service operation.
        double value = 100.00D;
        _client.AddTo(value);

        // Call the SubtractFrom service operation.
        value = 50.00D;
        _client.SubtractFrom(value);

        // Call the MultiplyBy service operation.
        value = 17.65D;
        _client.MultiplyBy(value);

        // Call the DivideBy service operation.
        value = 2.00D;
        _client.DivideBy(value);

        // Complete equation
        _client.Clear();

        //Thread.Sleep(10000); //todo this ought to be better
        
        return Ok("process completed, check Debug console");
      }
    }
}
