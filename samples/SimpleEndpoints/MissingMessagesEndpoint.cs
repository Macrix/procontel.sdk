using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Services;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "Missing Messages Endpoint", SupportedRoles = SupportedRoles.Both)]
  public class MissingMessagesEndpoint : IRequestMissedContent
  {
    private readonly ILogger _logger;

    public MissingMessagesEndpoint(ILogger logger)
    {
      _logger = logger;
    }

    public Task ProcessMissedContentsRequestAsync(string subscriberId, IEnumerable<string> contentIds, DateTime? startingDateTime)
    {
      _logger.Information("SubscribedId endpoint asked for messages with contentsIds sent from startingDateTime up to now");
      return Task.CompletedTask;
    }
  }

}
