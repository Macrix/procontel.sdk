using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Services;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "Last Messages Endpoint", SupportedRoles = SupportedRoles.Both)]
  public class LastMessagesEndpoint : IRequestLastContent
  {
    private readonly ILogger _logger;

    public LastMessagesEndpoint(ILogger logger)
    {
      _logger = logger;
    }

    public Task OnRequestLastContentReceivedAsync(string requestingEndpointId, string providerId, params string[] contentIds)
    {
      _logger.Information("requestingEndpointId endpoint asked for messages with contentsIds sent by providerId");
      return Task.CompletedTask;
    }
  }
}
