using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications;
using ProconTel.Sdk.Communications.Attributes;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using System.Threading.Tasks;

namespace AvancedEndpoints
{
  [EndpointMetadata(Name = "CustomProtocols", SupportedRoles = SupportedRoles.Both)]
  [CustomEndpointProtocol]
  public class CustomProtocolsEndpoint : IEndpointLifeTimeCycle, IHandler
  {
    private readonly ILogger _logger;
    private readonly IMessageBus _messageBus;

    public CustomProtocolsEndpoint(ILogger logger, IMessageBus messageBus)
    {
      _logger = logger;
      _messageBus = messageBus;
    }

    public Task InitializeAsync()
    {
      Task.Factory.StartNew(() => SendMessages());
      
      return Task.CompletedTask;
    }

    public Task TerminateAsync()
    {
      return Task.CompletedTask;
    }

    private void SendMessages()
    {
      while (true)
      {
        Task.Delay(2000).Wait();
        _messageBus.Broadcast<object>("message id", "message content", new CustomEndpointProtocol());
      }
    }

    public bool CanHandle(string messageId, ICorrelationContext context = null) => messageId == "message id";

    public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      _logger.Information($"Received message with ID '{messageId}'.");
      return Task.FromResult<Acknowledgement>(new Ack());
    }
  }

  public class CustomEndpointProtocol : IProtocol
  {
    public string Id => "Custom Endpoint Protocol";
  }

  public class CustomEndpointProtocolAttribute : SupportedProtocolAttribute
  {
    public CustomEndpointProtocolAttribute()
    {
      Name = new CustomEndpointProtocol();
    }
  }
}
