using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications.Middlewares;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;
using TelegramDefinitions.Telegrams;

namespace SendingTelegramsEndpoint
{
  [EndpointMetadata(Name = "Telegram Sender", SupportedRoles = SupportedRoles.Provider)]
  // Declarative way of defining what messages (telegrams) can be send by endpoint
  [MessageMetadata(TelegramIdentifiers.TELEGRAM_A, "Telegram A")]
  [MessageMetadata(TelegramIdentifiers.TELEGRAM_B, "Telegram A")]
  public class TelegramSenderEndpoint : IEndpointLifeTimeCycle
  {
    private readonly ILogger _logger;
    private readonly IMessageBus _messageBus;

    public TelegramSenderEndpoint(ILogger logger, IMessageBus messageBus)
    {
      _logger = logger;
      _messageBus = messageBus;
    }

    public Task InitializeAsync(IMiddlewareBuilder builder)
    {
      Task.Factory
        .StartNew(SendMessages)
        .ContinueWith(result =>
        {
          if (result.Exception != null)
            _logger.Error(result.Exception);
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
      for (int i = 1; i <= 10; i++)
      {
        await Task.Delay(1000);
        var telegramA = new Telegram_A(true) { Integer_4Byte = i };

        // Assuming telegram should be received by one of ProconTEL Standard Endpoints, then
        // XML or Binary protocols should be used. In other cases, any protocol supported by receiver
        // can be used.
        await _messageBus.BroadcastAsync(TelegramIdentifiers.TELEGRAM_A, telegramA.GetXml(), new XmlProtocol());
        //_messageBus.Broadcast(TelegramIdentifiers.TELEGRAM_A, telegramA.GetBytes(), new BinaryProtocol());
      }
    }
  }
}
