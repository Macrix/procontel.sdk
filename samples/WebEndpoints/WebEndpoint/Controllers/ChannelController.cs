using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;
using ProconTel.shortbasic;

namespace WebEndpoints.WebApiEndpoint.Controllers
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
    public ActionResult<string> IsAlive()
    {
      var response = $"Server is working!  {DateTime.Now}";
      return Ok(response);
    }

    [HttpPost]
    [Route("BroadcastTelegram")]
    public async Task<ActionResult<string>> BroadcastTelegram(string id, string message)
    {
      var response = $"Wrong telegram ID!  {DateTime.Now}";

      if (id == TelegramIdentifiers.SIMPLETELEGRAM)
      {
        var telegram = new SimpleTelegram() { ID = id, Message = message };
        await MessageBus.BroadcastAsync(nameof(SimpleTelegram), telegram, new XmlProtocol());
        response = $"Telegram send!  {DateTime.Now}";
      }

      return Ok(response);
    }
  }
}
