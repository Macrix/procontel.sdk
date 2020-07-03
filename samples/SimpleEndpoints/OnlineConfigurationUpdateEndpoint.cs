using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using System;
using System.Threading.Tasks;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "OnlineConfigurationUpdate", SupportedRoles = SupportedRoles.None)]
  public class OnlineConfigurationUpdateEndpoint : IOnlineConfigurationUpdate
  {
    private readonly ILogger _logger;
    private readonly IConfigurationReader _configurationReader;
    public OnlineConfigurationUpdateEndpoint(ILogger logger, IConfigurationReader configurationReader)
    {
      _logger = logger;
      _configurationReader = configurationReader;
    }

    public Task ConfigurationChangedAsync()
    {
      _logger.Information($"Configuration was changed. Current values: {_configurationReader.GetConfiguration()})");
      return Task.CompletedTask;
    }
  }
}
