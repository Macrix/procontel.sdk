using System;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using ProconTel.Sdk.Communications;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;
using ProconTel.shortbasic;
using WebEndpoints.WebApiEndpoint.Commands;

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
    public async Task<ActionResult<string>> IsAlive()
    {
      var response = $"Server is working!  {DateTime.Now}";
      return Ok(response);
    }

    [HttpGet]
    [Route("BroadcastMessageInChannel/{message}")]
    public async Task<ActionResult<string>> BroadcastMessageInChannel(string message)
    {
      var command = new BroadcastMessageCommand() { Message = message };
      await MessageBus.BroadcastAsync(nameof(BroadcastMessageCommand), command, DefaultProtocol.Instance);
      var response = $"Message broadcasted!  {DateTime.Now}";
      return Ok(response);
    }

    [HttpGet]
    [Route("BroadcastSimpleTelegramInChannel/{message}")]
    public async Task<ActionResult<string>> BroadcastSimpleTelegramInChannel(string message)
    {
      var telegram = new SimpleTelegram() { Message = message };
      await MessageBus.BroadcastAsync(nameof(SimpleTelegram), telegram, new XmlProtocol());
      var response = $"Telegram broadcasted!  {DateTime.Now}";
      return Ok(response);
    }
  }
}
