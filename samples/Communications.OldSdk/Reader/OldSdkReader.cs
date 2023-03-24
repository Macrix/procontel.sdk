using ProconTel.CommunicationCenter.Kernel;

namespace Communications.OldSdk.Reader
{
  [Endpoint(Name = "[Old SDK] Receiver", SupportedRoles = SupportedRoles.Subscriber)]
  public class OldSdkReader : ChannelEndpointBase
  {
    public override void Initialize()
    {
    }
    public override void Terminate()
    {
    }
    public override ProviderStrategyBase InstantiateProviderStrategy()
    {
      return null;
    }
    public override SubscriberStrategyBase InstantiateSubscriberStrategy()
    {
      return new OldSdkReaderSubscriberStrategy();
    }
  }
}
