using ProconTel.Sdk.Communications;
using ProconTel.Sdk.Communications.Attributes;

namespace VisualEndpoints.Wpf
{
  class SimpleCustomProtocol : IProtocol
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
