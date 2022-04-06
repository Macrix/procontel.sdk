using System.Collections.Generic;
using ProconTel.CommunicationCenter.Kernel;
using ProconTel.Logging;
using ProconTel.Sdk.Messages;

namespace Communications.OldSdk.Reader
{
  public class OldSdkReaderSubscriberStrategy : SubscriberStrategyBase
  {
    public override void Initialize()
    {
    }
    public override void Terminate()
    {
    }
    public override IEnumerable<IProtocol> SubscribingProtocols => new IProtocol[] { new XmlProtocol(), new BinaryProtocol(), DefaultProtocol.Instance};
    public override bool ProcessContent(string contentId, object content, ContentInfo contentInfo)
    {
            switch (contentId)
            {
                case "MessageSend":
                    Logger.Information($"[Old SDK]Received message: {content}");
                    break;
                case "MessageSendWithAck":
                    contentInfo.Metadata.Add(Acknowledgement.ACKNOWLEDGEMENT_VALUE, new Ack() { Body = "AcknowledgementText" });
                    this.AcknowledgeContent(new ContentAcknowledgment("SenderNewSDK", "ReceiverOldSDK", "CommunicationNewToOldSDK", contentId, DefaultProtocol.Instance.Id, ContentProcessingResult.Processed, "", contentInfo.Metadata));
                    Logger.Debug($"[Old SDK]Received message with ACK: {content}");
                    break;
                case "MessageBroadcast":
                    Logger.Debug($"[Old SDK]Received broadcast: {content}");
                    break;
                default:
                    break;
            }
            return true;
    }
  }
}
