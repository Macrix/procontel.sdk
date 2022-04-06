using System.Threading.Tasks;
using ProconTel.CommunicationCenter.Kernel;
using ProconTel.Logging;

namespace Communications.OldSdk.Sender
{
    [Endpoint(Name = "[Old SDK] Sender", SupportedRoles = SupportedRoles.Provider)]
    public class OldSdkSender : ChannelEndpointBase
    {
        public override void Initialize()
        {
            Task.Factory.StartNew(async () =>
            {
                Logger.Information("[Old SDK]Two messages will be send.");
                await Task.Delay(2000);
                Logger.Information("[Old SDK]First message sent!");
                SendContent(null, "MessageSendContent", "MessageSendContentText", DefaultProtocol.Instance);
                await Task.Delay(2000);
                Logger.Information("[Old SDK]Second message sent!");
                BroadcastContent("MessageBroadcastContent", "MessageBroadcastText", DefaultProtocol.Instance);
                await Task.Delay(2000);
                Logger.Information("[Old SDK]Two messages were sent");
            });
        }
        public override void Terminate()
        {
        }
        public override ProviderStrategyBase InstantiateProviderStrategy()
        {
            return new OldSdkSenderProviderStrategy();
        }
        public override SubscriberStrategyBase InstantiateSubscriberStrategy()
        {
            return null;
        }
    }
}
