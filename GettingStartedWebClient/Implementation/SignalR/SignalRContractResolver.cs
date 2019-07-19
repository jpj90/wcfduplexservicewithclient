using Microsoft.AspNet.SignalR.Infrastructure;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GettingStartedWebClient.Implementation.SignalR
{
  public class SignalRContractResolver: IContractResolver
  {
    private readonly Assembly _assembly;
    private readonly IContractResolver _defaultContractSerializer;
    private readonly IContractResolver _camelCaseContractResolver;

    public SignalRContractResolver()
    {
      _defaultContractSerializer = new DefaultContractResolver();
      _camelCaseContractResolver = new CamelCasePropertyNamesContractResolver();
      _assembly = typeof(Connection).Assembly;
    }

    public JsonContract ResolveContract(Type type)
    {
      return type.Assembly.Equals(_assembly)
        ? _defaultContractSerializer.ResolveContract(type)
        : _camelCaseContractResolver.ResolveContract(type);
    }
  }
}