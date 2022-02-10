using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebEndpoints.WebApiEndpoint.Hubs
{
  public static class HubExtensions
  {
    public static string ToUserGroup(this string userId)
    {
      return $"users:{userId}";
    }
  }

  public class OrderHub : Hub<IOrderBroadcaster>
  {
    public virtual Task SubscribeAsync(string userId)
    {
      return Groups.AddToGroupAsync(Context.ConnectionId, userId.ToUserGroup());// Context.User.Identity.Name.ToUserGroup());
    }

    public virtual Task UnsubscribeAsync(string userId)
    {
      return Groups.RemoveFromGroupAsync(Context.ConnectionId, userId.ToUserGroup()); //Context.User.Identity.Name.ToUserGroup());

    }
  }
}
