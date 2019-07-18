using GettingStartedWebClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GettingStartedWebClient.Models
{
  public class CallbackHandler : ICalculatorDuplexCallback
  {
    public void Equals(double result)
    {
      Debug.WriteLine("Webclient CallbackHandler: Equals({0})", result);
    }

    public void Equation(string eqn)
    {
      Console.WriteLine("Webclient CallbackHandler: Equation({0})", eqn);
    }
  }
}