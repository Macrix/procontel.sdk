using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Models;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Attributes;
using ProconTel.Sdk.UI.Models;
using VisualEndpoints.Wpf.UI;

namespace VisualEndpoints.Wpf
{
  [SimpleCustomProtocol]
  [StatusControl(typeof(StreamingEndpointStatusControl), EndpointStatusControlType.Wpf, false, false)]
  [EndpointMetadata(Name = "StreamingEndpoint", SupportedRoles = SupportedRoles.Both)]
  public class StreamingEndpoint: IHandler
  {
    private readonly ILogger _logger;
    private readonly IStreamingService _streamingService;
    private readonly IMessageBus _messageBus;

    private const string MessageId = "MessageId";
                                
    public StreamingEndpoint(ILogger logger, IStreamingService streamingService, IMessageBus messageBus)
    {
      _logger = logger;
      _streamingService = streamingService;
      _messageBus = messageBus;
    }

    #region Handle_message_with_stream
    
    public bool CanHandle(string messageId, ICorrelationContext context = null)
    {
      return messageId == MessageId;
    }

    public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      if (message is IStreamDescriptor descriptor)
      {
        var stream = _streamingService.GetStream(descriptor.StreamId);
      }

      return Task.FromResult(new Acknowledgement());
    }

    #endregion

    #region Broadcast_message_with_stream

    public Task<object> HandleCommandAsync(object command, ICorrelationContext context = null)
    {
      if(command.ToString() == "broadcast")
        Broadcast();
      return Task.FromResult(new object());
    }

    private void Broadcast()
    {
      var data = new byte[100];
      var rnd = new Random();
      rnd.NextBytes(data);
      var stream = new MemoryStream(data);
      _messageBus.Broadcast(MessageId, "empty message", stream, StreamCallback, new SimpleCustomProtocol(), null);
      _logger.Warning($"Sent stream with hash {stream.GetHashCode()}");
    }

    private void StreamCallback(Stream stream)
    {
      _logger.Warning($"Release stream with hash {stream.GetHashCode()}");
    }

    #endregion

  }
}

