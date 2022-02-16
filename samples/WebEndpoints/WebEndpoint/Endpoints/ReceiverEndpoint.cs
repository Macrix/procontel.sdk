using System;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications.Attributes;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;
using ProconTel.shortbasic;

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
        switch (messageId)
        {
          case nameof(SimpleTelegram):
            ProcessSimpleTelegram(message.ToString()); 
            break;
        }
      }
      catch (Exception ex)
      {
        _logger.Error(ex);
      }

      return Task.FromResult(new Acknowledgement());
    }

    private void ProcessSimpleTelegram(string message)
    {
      var telegram = SimpleTelegram.Create(message);
      _logger.Warning($"Received telegram {_receivedTelegramCounter} " +
                      $"with ID {nameof(SimpleTelegram)} {telegram.GetXml()}");
      _receivedTelegramCounter++;
    }
  }
}
