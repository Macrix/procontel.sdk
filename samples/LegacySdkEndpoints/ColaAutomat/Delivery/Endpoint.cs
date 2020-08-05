using ColaAutomat.Common;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Legacy;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Attributes;
using ProconTel.Sdk.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Delivery
{
  [EndpointMetadata(Name = "Delivery Service", SupportedRoles = SupportedRoles.Subscriber)]
  [StatusControl(typeof(StatusControl), EndpointStatusControlType.WinForms)]
  public class Endpoint : ChannelEndpointBase
  {
    public Endpoint(IMessageBus messageBus, ILogger logger, IRuntimeContext runtimeContext, IConfigurationReader configurationReader,
      INotificationService notificationService, IReportService reportService)
      : base(messageBus, logger, runtimeContext, configurationReader, notificationService, reportService)
    {
    }

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
  }
}
