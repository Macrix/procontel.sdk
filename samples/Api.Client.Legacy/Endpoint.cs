using System;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications.Middlewares;
using ProconTel.Api.Client.Legacy;
using System.Collections.Generic;
using System.Linq;
using ProconTel.Sdk.Services;

namespace Api.Client.Legacy
{
  [EndpointMetadata(Name = "[Test] Api.Client.Legacy", SupportedRoles = SupportedRoles.Both)]
  public class Endpoint : IEndpointLifeTimeCycle
  {
    private readonly ILogger _logger;

    public Endpoint(ILogger logger)
    {
      _logger = logger;
    }

    public Task InitializeAsync(IMiddlewareBuilder builder)
    {
      Task.Run(LogChannelsAndPoolsNames);
      return Task.CompletedTask;
    }

    public Task TerminateAsync()
    {
      return Task.CompletedTask;
    }

    private void LogChannelsAndPoolsNames()
    {
      var names = GetNamesOfAllChannelsAndPools("http://localhost:1010/api");
      var message = $"Lis of channel and pools: {Environment.NewLine}";
      foreach (var name in names)
      {
        message += $"{name}{Environment.NewLine}";
      }
      _logger.Warning(message);
    }

    private string[] GetNamesOfAllChannelsAndPools(string address)
    {
      var connection = new Connection(address);

      if (!connection.Open())
        return Array.Empty<string>(); 

      try
      {
        var channelsAndPools = new List<string>();
        
        var channels = connection.Manager.GetChannels();
        channelsAndPools.AddRange(channels.Select(c => c.Name));
        
        var pools = connection.Manager.GetEndpointPools();
        channelsAndPools.AddRange(pools.Select(c => c.Name));

        return channelsAndPools.ToArray();
      }
      finally
      {
        connection.Close();
      }
    }
  }
}
