using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GettingStartedWebClient.Implementation.SignalR
{
  public static class JsonSettings
  {
    public static JsonSerializerSettings GetSettings()
    {
      return new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Include,
        Converters = new List<JsonConverter> { new StringEnumConverter() },
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.Populate,
        Formatting = Formatting.None,
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      };
    }
  }
}