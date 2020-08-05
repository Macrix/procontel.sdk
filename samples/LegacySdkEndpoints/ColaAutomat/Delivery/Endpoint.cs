using ColaAutomat.Common;
using ProconTel.CommunicationCenter.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Delivery
{
  [Endpoint(Name = "Delivery Service", SupportedRoles = SupportedRoles.Subscriber)]
  public class Endpoint : ChannelEndpointBase
  {
    internal State State { get; private set; }

    public override void Initialize() 
    {
      this.State = new Delivery.State();
    }

    public override ProviderStrategyBase InstantiateProviderStrategy()
    {
      return new Provider();
    }

    internal void ProcessRefillRequest(RefillRequest refillMessage)
    {
      if (0 == State.Orders.Where(x => x.Vendor.Equals(refillMessage.Vendor)).Count())
      {
        State.Orders.Add(refillMessage);
        UpdateStatusControl(State);
      }
    }

    internal void ProcessRefillAcknowledge(RefillAcknowledge refillAcknowledge)
    {
      State.Orders = State.Orders.Where(x => !x.Vendor.Equals(refillAcknowledge.Vendor)).ToList();
      UpdateStatusControl(State);
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
