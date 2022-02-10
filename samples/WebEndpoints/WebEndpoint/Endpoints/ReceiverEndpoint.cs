using System;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications.Attributes;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;
using ProconTel.shortbasic;
using WebEndpoints.WebApiEndpoint.Commands;

namespace WebEndpoints.WebApiEndpoint.Endpoints
{
  [EndpointMetadata(Name = "[Test] Receiver Endpoint", SupportedRoles = SupportedRoles.Subscriber)]
  [SupportsXmlProtocol]
  [DefaultProtocol]
  public class ReceiverEndpoint : IHandler
  {
    private readonly ILogger _logger;
    private int _receivedTelegramCounter = 1;

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
          case SimpleTelegram simpleTelegram:
            ProcessSimpleTelegram(simpleTelegram); 
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
      _logger.Warning($"Received message " +
                      $"with ID {nameof(BroadcastMessageCommand)} {command.Message}");
    }

    private void ProcessSimpleTelegram(SimpleTelegram command)
    {
      _logger.Warning($"Received telegram {_receivedTelegramCounter} " +
                      $"with ID {nameof(BroadcastMessageCommand)} {command.GetXml()}");
      _receivedTelegramCounter++;
    }
  }
}
