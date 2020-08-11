using ProconTel.Sdk.Communications;
using ProconTel.Sdk.Legacy;
using ProconTel.Sdk.StandardEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Vending
{
  public class Subscriber : SubscriberStrategyBase
  {
    public override void Initialize()
    {
    }

    public override bool ProcessContent(string contentId, object content, ContentInfo contentInfo)
    {
      return true;
    }

    public override void Terminate()
    {
    }

    public override bool AcceptsContent(string contentId, ContentInfo contentInfo) { return true; }
    public override IEnumerable<IProtocol> SubscribingProtocols { get { return new List<IProtocol> { new XmlProtocol() }; } }

  }
}
