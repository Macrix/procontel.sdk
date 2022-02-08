using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Services;
using System;
using System.Text.Json;

namespace WebEndpoints.WebApiEndpoint.Common
{
  public static class ConfigurationExtensions
  {
    public static void JsonSerializeAndWrite<T>(this IConfigurationWriter configurationWriter, T configuration)
    {
      var confString = JsonSerializer.Serialize<T>(configuration);
      configurationWriter.SaveConfiguration(confString);
    }
    

    public static T ReadAndJsonDeserialize<T>(this IConfigurationReader configurationReader, Action<Exception> onException = null)
      where T : class, new()
    {
      var confString = configurationReader.GetConfiguration();
      if (string.IsNullOrWhiteSpace(confString))
      {
        confString = "{}";
      }
      var configuration = new T();
      try
      {
        configuration = JsonSerializer.Deserialize<T>(confString);
      }
      catch (Exception ex)
      {
        if (onException != null)
        {
          onException(ex);
        }
      }
      return configuration;
    }
  }
}
