using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "MessageMetadataProvider", SupportedRoles = SupportedRoles.Provider)]
  public class MessageMetadataProviderEndpoint : IMessageMetadataProvider
  {
    public IEnumerable<MessageDetails> MessagesMetadata => Enumerable.Empty<MessageDetails>();
    public MessageMetadataProviderEndpoint()
    {
    }
  }
}
