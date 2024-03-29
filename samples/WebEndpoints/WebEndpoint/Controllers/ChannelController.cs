﻿using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.StandardEndpoints;
using ProconTel.shortbasic;

namespace WebEndpoints.WebApiEndpoint.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ChannelController : ControllerBase
  {
    private IMessageBus MessageBus { get; }
    public ChannelController(IMessageBus messageBus)
    {
      MessageBus = messageBus;
    }

    [HttpGet]
    [Route("IsAlive")]
    public ActionResult<string> IsAlive()
    {
      var message = $"Server is working!  {DateTime.Now}";
      return Ok(message);
    }

    [HttpPost]
    [Route("BroadcastTelegram")]
    public async Task<ActionResult<string>> BroadcastTelegram([FromBody] string xmlAsString)
    {
      string message;
      try
      {
        xmlAsString = System.Web.HttpUtility.HtmlDecode(xmlAsString);
        var xmlDoc = XDocument.Parse(xmlAsString);

        if (xmlDoc.Root != null)
        {
          await MessageBus.BroadcastAsync(nameof(SimpleTelegram), xmlAsString, new XmlProtocol());
          message = "Telegram send!";
        }
        else
        {
          message = "XML is empty!";
        }
      }
      catch (Exception ex)
      {
        message = $"Wrong xml content. {ex.Message}";
      }

      return Ok($"{message} {DateTime.Now}");
    }
  }
}
