using ColaAutomat.Common;
using ProconTel.CommunicationCenter.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Vending
{
  [Endpoint(Name = "Vending Machine", SupportedRoles = SupportedRoles.Both)]
  public class Endpoint : ChannelEndpointBase
  {
    public State State { get; private set; }

    public override void Initialize()
    {
      this.State = new State
      {
        NoColaBottles = 7,
        NoLimonadeBottles = 6,
        NoWaterBottles = 4,
        Vendor = this.DisplayName,
        Time = DateTime.Now
      };

      UpdateStatusControl(State);
    }

    public override ProviderStrategyBase InstantiateProviderStrategy()
    {
      return new Provider();
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
    public override object ExecuteCommandFromStatusControl(object command)
    {
      switch (command)
      {
        case Actions.SellCola:
          if (0 == State.NoColaBottles) { return State; }
          State.NoColaBottles = Math.Max(0, State.NoColaBottles - 1);
          break;
        case Actions.SellLimonade:
          if (0 == State.NoLimonadeBottles) { return State; }
          State.NoLimonadeBottles = Math.Max(0, State.NoLimonadeBottles - 1);
          break;
        case Actions.SellWater:
          if (0 == State.NoWaterBottles) { return State; }
          State.NoWaterBottles = Math.Max(0, State.NoWaterBottles - 1);
          break;
        case Actions.Refill:
          State.NoColaBottles =
            State.NoLimonadeBottles =
            State.NoWaterBottles = 10;
          BroadcastContent("RefillAcknowledge", new RefillAcknowledge { Vendor = this.DisplayName }, new XmlProtocol());
          break;
        default:
          return State;
      }
      State.Time = DateTime.Now;
      BroadcastContent("Vending.State", State, new XmlProtocol());
      UpdateStatusControl(State);
      return State;
    }
  }
}
