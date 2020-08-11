using ColaAutomat.Common;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Legacy;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;
using ProconTel.Sdk.UI.Attributes;
using ProconTel.Sdk.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Vending
{
  [EndpointMetadata(Name = "Vending Machine", SupportedRoles = SupportedRoles.Both)]
  [StatusControl(typeof(StatusControl), EndpointStatusControlType.WinForms)]
  public class Endpoint : ChannelEndpointBase
  {
    public Endpoint(IMessageBus messageBus, ILogger logger, IRuntimeContext runtimeContext, IConfigurationReader configurationReader,
      INotificationService notificationService, IReportService reportService)
      : base(messageBus, logger, runtimeContext, configurationReader, notificationService, reportService)
    {
    }

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
