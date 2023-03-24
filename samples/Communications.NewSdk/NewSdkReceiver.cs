using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;

namespace Communications.NewSdk.Tests
{
    [EndpointMetadata(Name = "[NEW SDK] Receiver", SupportedRoles = SupportedRoles.Subscriber)]
    public class NewSdkReceiver : IHandler
    {
        private readonly ILogger _logger;
        public NewSdkReceiver(ILogger logger)
        {
            _logger = logger;
        }
        public bool CanHandle(string messageId, ICorrelationContext context = null)
        {
            return true;
        }
        public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context)
        {
            _logger.Debug($"[New SDK]Received message: {message}");        
            return Task.FromResult<Acknowledgement>(new Ack());
        }
    }
}
