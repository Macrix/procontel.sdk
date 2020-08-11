using ProconTel.Sdk.Communications;
using ProconTel.Sdk.Legacy;
using ProconTel.Sdk.StandardEndpoints;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Central
{
  public class Subscriber : SubscriberStrategyBase
  {
    public override void Initialize()
    {
    }

    public override bool ProcessContent(string contentId, object content, ContentInfo contentInfo)
    {
      if (content is Vending.State)
      {
        var endpoint = this.Endpoint as Central.Endpoint;
        endpoint.RegisterTransaction(content as Vending.State);
      }
      return true;
    }

    public override void Terminate()
    {
    }

    public override bool AcceptsContent(string contentId, ContentInfo contentInfo) { return true; }
    public override IEnumerable<IProtocol> SubscribingProtocols { get { return new List<IProtocol> { new XmlProtocol() }; } }

  }
}
