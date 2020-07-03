using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using System;
using System.Threading.Tasks;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "OnlineUpgradeLifetimeCycle", SupportedRoles = SupportedRoles.None)]
  public class OnlineUpgradeLifetimeCycleEndpoint : IOnlineUpgradeLifetimeCycle
  {
    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    public OnlineUpgradeLifetimeCycleEndpoint(ILogger logger, IRuntimeContext runtimeContext)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
    }

    public Task AfterUpgradeAsync()
    {
      _logger.Information($"Update endpoint finished (id: {_runtimeContext.MetadataContext.Id})");
      return Task.CompletedTask;
    }

    public Task<bool> CanUpgradeAsync() => Task.FromResult(true);
  }
}
