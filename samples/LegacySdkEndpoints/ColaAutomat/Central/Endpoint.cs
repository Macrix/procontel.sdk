using ColaAutomat.Common;
using ColaAutomat.Vending;
using ProconTel.CommunicationCenter.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Central
{
  [Endpoint(Name = "Central Office", SupportedRoles = SupportedRoles.Both)]
  public class Endpoint : ChannelEndpointBase
  {
    public State State { get; private set; }

    public override void Initialize()
    {
      this.State = new Central.State();
    }

    public override ProviderStrategyBase InstantiateProviderStrategy()
    {
      return new Provider();
    }

    internal void RegisterTransaction(Vending.State state)
    {
      State.Transactions.Add(state);
      UpdateStatusControl(State);

      if (0 == state.NoColaBottles || 0 == state.NoLimonadeBottles || 0 == state.NoWaterBottles)
      {
        BroadcastContent("RefillRequest", new RefillRequest { Vendor = state.Vendor, Time = state.Time }, new XmlProtocol());
      }
    }

    public override SubscriberStrategyBase InstantiateSubscriberStrategy()
    {
      return new Subscriber();
    }

    public override void Terminate() { }

    public override bool HasStatusControl(IEndpointStatusController context) { return true; }

    public override IEndpointStatusControlProvider GetStatusControl(IEndpointStatusController context)
    {
      return new DefaultWinFormsStatusControlProvider(new StatusControl { Context = context });
    }
  }
}
