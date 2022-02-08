using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProconTel.Sdk.Services;

namespace SimpleWebApiEndpoint
{
  [Route("api/")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private IMessageBus MessageBus { get; }

    public OrdersController(IMessageBus messageBus)
      => (MessageBus) = (messageBus);

    [HttpGet]
    [Route("IsAlive")]
    public async Task<ActionResult<string>> GetOrders()
    {
      var message = $"Server is working!  {DateTime.Now}";
      return Ok(message);
    }
  }
}
