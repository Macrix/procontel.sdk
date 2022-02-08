using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.Communications;
using WebEndpoint.WebCommon.Commands;

namespace WebEndpoints.WebApiEndpoint
{
  [Route("api/")]
  [ApiController]
  public class ChannelController : ControllerBase
  {
    private IMessageBus MessageBus { get; }

    public ChannelController(IMessageBus messageBus)
      => (MessageBus) = (messageBus);

    [HttpGet]
    [Route("IsAlive")]
    public async Task<ActionResult<string>> GetOrders()
    {
      var response = $"Server is working!  {DateTime.Now}";
      return Ok(response);
    }

    [HttpGet]
    [Route("BroadcastAsync/{message}")]
    public async Task<ActionResult<string>> GetOrders(string message)
    {
      var command = new BroadcastMessageCommand() { Message = message };
      MessageBus.Broadcast(nameof(BroadcastMessageCommand), command, DefaultProtocol.Instance);
      var response = $"Message broadcasted!  {DateTime.Now}";
      return Ok(response);
    }
  }
}
