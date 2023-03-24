using ProconTel.CommunicationCenter.Kernel;
using ProconTel.Logging;

namespace Communications.OldSdk.Sender
{
    public class OldSdkSenderProviderStrategy : ProviderStrategyBase
    {
        public override void Initialize()
        {
        }
        public override void Terminate()
        {
        }
        protected override void OnContentAcknowledged(ContentAcknowledgment acknowledgment)
        {
            Logger.Information($"[Old SDK]Received acknowledgment: {acknowledgment.Message}");
        }
    }
}
