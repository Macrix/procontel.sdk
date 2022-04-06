using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications;
using ProconTel.Sdk.Communications.Middlewares;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;

namespace Communications.NewSdk.Tests
{
    [EndpointMetadata(Name = "[New SDK] Sender", SupportedRoles = SupportedRoles.Both)]
    public class NewSdkSender : IEndpointLifeTimeCycle
    {
        protected IMessageBus MessageBus { get; private set; }
        protected ILogger Logger { get; private set; }
        protected IRuntimeContext RuntimeContext { get; private set; }

        public NewSdkSender(
          IMessageBus messageBus,
          ILogger logger,
          IRuntimeContext runtimeContext)
        {
            MessageBus = messageBus;
            Logger = logger;
            RuntimeContext = runtimeContext;
        }
        public Task InitializeAsync(IMiddlewareBuilder builder)
        {
            Task.Factory.StartNew(async () =>
            {
                Logger.Information("[New SDK]Three messages will be send.");
                await Task.Delay(2000);
                Logger.Information("[New SDK]First message sent!");
                MessageBus.Send(null, "MessageSend", "MessageSendText", DefaultProtocol.Instance);
                await Task.Delay(2000);
                Logger.Information("[New SDK]Second message sent!");
                MessageBus.SendWithAck(null, "MessageSendWithAck", "MessageSendWithAckText", ProcessContentAck, new BinaryProtocol());
                await Task.Delay(2000);
                Logger.Information("[New SDK]Third message sent!");
                MessageBus.Broadcast("MessageBroadcast", "MessageBroadcastText", DefaultProtocol.Instance);
                await Task.Delay(2000);
                Logger.Information("[New SDK]Three messages were sent");
            });
            return Task.CompletedTask;
        }
        public Task TerminateAsync()
        {
            return Task.CompletedTask;
        }
        public void ProcessContentAck(Acknowledgement ack)
        {
            if (ack is Ack)
            {
                Logger.Information($"[New SDK]Received acknowledgment: {ack.Body}");
            }
        }
    }
}
