//https://docs.microsoft.com/en-us/dotnet/framework/wcf/how-to-create-a-wcf-client
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using GettingStartedClient.ServiceReference1;
using GettingStartedLib;
using ICalculatorDuplexCallback = GettingStartedClient.ServiceReference1.ICalculatorDuplexCallback;

namespace GettingStartedClient
{
  class Program
  {
    static void Main(string[] args)
    {
      // Construct InstanceContext to handle messages on callback interface
      InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

      //Step 1: Create an instance of the WCF proxy.
      CalculatorDuplexClient client = new CalculatorDuplexClient(instanceContext);

      Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.");
      Console.WriteLine();

      // Call the AddTo service operation.
      double value = 100.00D;
      client.AddTo(value);

      // Call the SubtractFrom service operation.
      value = 50.00D;
      client.SubtractFrom(value);

      // Call the MultiplyBy service operation.
      value = 17.65D;
      client.MultiplyBy(value);

      // Call the DivideBy service operation.
      value = 2.00D;
      client.DivideBy(value);

      // Complete equation
      client.Clear();

      Console.ReadLine();

      //Closing the client gracefully closes the connection and cleans up resources
      client.Close();
    }
  }

  public class CallbackHandler : ICalculatorDuplexCallback
  {
    public void Equals(double result)
    {
      Console.WriteLine("Client CallbackHandler: Equals({0})", result);
    }

    public void Equation(string eqn)
    {
      Console.WriteLine("Client CallbackHandler: Equation({0})", eqn);
    }
  }
}