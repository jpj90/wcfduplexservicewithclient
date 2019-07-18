using System.Web.Http;
using GettingStartedWebClient.ServiceReference1;

namespace GettingStartedWebClient.Controllers
{
  public class DefaultController : ApiController
    {
      [HttpGet]
      public IHttpActionResult CallWcf()
      {
        CalculatorClient client = new CalculatorClient();
        double value1 = 100.00D;
        double value2 = 19.99D;

        System.Random random = new System.Random();
        int randomNumber = random.Next(1, 100);
        value2 = randomNumber;

        double result = client.Add(value1, value2);
        result = client.Subtract(value1, value2);
        client.Close();
        return Ok(string.Format("Subtract({0},{1}) = {2}", value1, value2, result));
      }
    }
}
