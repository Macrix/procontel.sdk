using System;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;
using TelegramDefinitions.Telegrams;

namespace TelegramHandlingEndpoints
{
  [EndpointMetadata(Name = "Telegram Receiver", SupportedRoles = SupportedRoles.Subscriber)]
  // In order to receive telegrams from ProconTEL Standard Endpoints make sure to
  // support one of the protocols XML or Binary
  [SupportsXmlProtocol, SupportsBinaryProtocol]
  public class TelegramReceiverEndpoint : IHandler
  {
    private readonly ILogger _logger;

    public TelegramReceiverEndpoint(ILogger logger)
    {
      _logger = logger;
    }

    public bool CanHandle(string messageId, ICorrelationContext context = null)
      => messageId == TelegramIdentifiers.TELEGRAM_A || messageId == TelegramIdentifiers.TELEGRAM_B;

    public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      switch (messageId)
      {
        case TelegramIdentifiers.TELEGRAM_A:
          var telegramA = Telegram_A.Create(message);
          _logger.Information($"Received telegram A with integer field set to {telegramA.Integer_4Byte} using {context.ProtocolId}");
          break;

        case TelegramIdentifiers.TELEGRAM_B:
          var telegramB = Telegram_B.Create(message);
          _logger.Information($"Received telegram B with integer array fields set to [{String.Join(", ", telegramB.Integer_4Byte)}] using {context.ProtocolId}");
          break;
      }

      return Task.FromResult<Acknowledgement>(new Ack());
    }
  }
}
