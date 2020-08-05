using ColaAutomat.Common;
using ColaAutomat.Vending;
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

namespace ColaAutomat.Central
{
  [EndpointMetadata(Name = "Central Office", SupportedRoles = SupportedRoles.Both)]
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
  }
}
