using ProconTel.Sdk.Communications;
using ProconTel.Sdk.Communications.Attributes;

namespace WebEndpoints.WebApiEndpoint
{
  public class SimpleCustomProtocol : IProtocol
  {
    public string Id => "Custom Simple Endpoint Protocol";
  }

  public class SimpleCustomProtocolAttribute : SupportedProtocolAttribute
  {
    public SimpleCustomProtocolAttribute()
    {
      Name = new SimpleCustomProtocol();
    }
  }
}
