using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedWebClient.Interfaces
{
  public interface ICalculatorDuplexWcfClient
  {
    void AddTo(double value);
    void SubtractFrom(double value);
    void MultiplyBy(double value);
    void DivideBy(double value);
    void Clear();
  }
}
