using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications;
using ProconTel.Sdk.Services;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "MessageBombardier", SupportedRoles = SupportedRoles.Both)]
  public class MessageBombardierEndpoint : IEndpointLifeTimeCycle
  {
    private readonly ILogger _logger;
    private readonly IMessageBus _messageBus;

    public MessageBombardierEndpoint(ILogger logger, IMessageBus messageBus)
    {
      _logger = logger;
      _messageBus = messageBus;
    }

    public Task InitializeAsync()
    {
      Task.Factory
        .StartNew(SendMessages)
        .ContinueWith(result =>
        {
          if (result.Exception != null)
          {
            _logger.Error(result.Exception);
          }
        },
        TaskContinuationOptions.OnlyOnFaulted);
      return Task.CompletedTask;
    }

    public Task TerminateAsync()
    {
      return Task.CompletedTask;
    }

    private async Task SendMessages()
    {
      while (true)
      {
        await Task.Delay(1000);
        _messageBus.Broadcast<object>("message", "message content", DefaultProtocol.Instance);
      }
    }
  }
}
