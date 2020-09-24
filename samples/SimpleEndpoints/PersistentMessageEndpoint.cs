using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;

namespace SimpleEndpoints
{
  [PersistMessage("message", QueueSize = 100, Retention ="0.00:10:10")]
  [EndpointMetadata(Name = "PersistentMessage", SupportedRoles = SupportedRoles.Both)]
  public class PersistentMessageEndpoint : IHandler
  {
    private readonly ILogger _logger;
    public PersistentMessageEndpoint(ILogger logger) => _logger = logger;

    public bool CanHandle(string messageId, ICorrelationContext context = null) => true;

    public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      _logger.Information($"Received id: {messageId}, message: {message}");
      return Task.FromResult<Acknowledgement>(new Ack());
    }
  }
}
