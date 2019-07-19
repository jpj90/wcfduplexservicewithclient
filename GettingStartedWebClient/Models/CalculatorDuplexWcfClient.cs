using GettingStartedWebClient.Interfaces;
using GettingStartedWebClient.ServiceReference1;
using System;
using System.Diagnostics;
using System.ServiceModel;

namespace GettingStartedWebClient
{
  public class CalculatorDuplexWcfClient: ICalculatorDuplexWcfClient, IDisposable
  {
    private readonly CalculatorDuplexClient client;
    bool disposed = false;

    public CalculatorDuplexWcfClient(ICalculatorDuplexCallback callbackHandler)
    {
      InstanceContext instanceContext = new InstanceContext(callbackHandler);
      client = new CalculatorDuplexClient(instanceContext);
      Debug.WriteLine("CalculatorDuplexWcfClient has been called");
    }

    void ICalculatorDuplexWcfClient.AddTo(double value) => client.AddTo(value);

    void ICalculatorDuplexWcfClient.SubtractFrom(double value) => client.SubtractFrom(value);

    void ICalculatorDuplexWcfClient.MultiplyBy(double value) => client.MultiplyBy(value);

    void ICalculatorDuplexWcfClient.DivideBy(double value) => client.DivideBy(value);

    void ICalculatorDuplexWcfClient.Clear() => client.Clear();

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    // Private implementation of Dispose pattern.
    private void Dispose(bool disposing)
    {
      if (disposed)
        return;

      if (disposing)
      {
        client.Close();
      }
      disposed = true;
    }

    ~CalculatorDuplexWcfClient()
    {
      Dispose(false);
    }
  }
}