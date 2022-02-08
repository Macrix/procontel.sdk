using System;
using System.Threading.Tasks;

namespace WebEndpoints.WebApiEndpoint.Hubs
{
  public interface IOrderBroadcaster
  {
    Task OrderCreated(OrderEvent message);
    Task OrderRemoved(OrderEvent message);
    Task OrderReasigned(OrderEvent message);
  }

  public interface IOrdersEndpointEvent { }

  [Serializable]
  public class OrderEvent : IOrdersEndpointEvent
  {
    public int OrderId { get; set; }
    public string ContainerId { get; set; }
    public string ContainerType { get; set; }
  }
}
