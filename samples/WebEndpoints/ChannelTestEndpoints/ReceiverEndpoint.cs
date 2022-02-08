using System;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using WebEndpoint.WebCommon.Commands;

namespace WebEndpoints.ChannelTestEndpoints
{
  [EndpointMetadata(Name = "[Test] Receiver Endpoint", SupportedRoles = SupportedRoles.Subscriber)]
  public class ReceiverEndpoint : IHandler
  {
    private readonly ILogger _logger;
    private int _counter = 1;

    public ReceiverEndpoint(ILogger logger)
    {
      _logger = logger;
    }

    public bool CanHandle(string messageId, ICorrelationContext context = null)
    {
      return true;
    }

    public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      if (message == null)
        return Task.FromResult(new Acknowledgement());
      try
      {
        switch (message)
        {
          case BroadcastMessageCommand broadcastMessageCommand:
            ProcessBroadcastMessageCommand(broadcastMessageCommand);
            break;
        }
      }
      catch (Exception ex)
      {
        _logger.Error(ex);
      }

      return Task.FromResult(new Acknowledgement());
    }

    private void ProcessBroadcastMessageCommand(BroadcastMessageCommand command)
    {
      _logger.Warning($"Received telegram number {_counter} " +
                      $"with ID {nameof(BroadcastMessageCommand)} {command.Message}");
      _counter++;
    }
  }
}
