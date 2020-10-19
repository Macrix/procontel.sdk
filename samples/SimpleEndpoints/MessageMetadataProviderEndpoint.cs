using System.Collections.Generic;
using System.Linq;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Providers;

namespace SimpleEndpoints
{
  public class MessageMetadataProvider : IMessageMetadataProvider
  {
    public MessageMetadataProvider()
    {

    }
    public IEnumerable<MessageDetails> MessagesMetadata => Enumerable.Empty<MessageDetails>();
  }

  [MessageMetadataProviderAttribute(typeof(MessageMetadataProvider))]
  [EndpointMetadata(Name = "MessageMetadataProvider", SupportedRoles = SupportedRoles.Provider)]
  public class MessageMetadataProviderEndpoint
  {
  }
}
