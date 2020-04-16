using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using System.Threading.Tasks;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "Handler", SupportedRoles = SupportedRoles.Subscriber)]
  public class HandlerEndpoint : IHandler
  {
    private readonly ILogger _logger;
    public HandlerEndpoint(ILogger logger) => _logger = logger;

    public bool CanHandle(string messageId, ICorrelationContext context = null) => true;

    public Task HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      _logger.Information($"Received message id: {messageId}, message: {message}");
      return Task.CompletedTask;
    }
  }
}
