using System;

namespace WebEndpoints.WebApiEndpoint.Commands
{
  [Serializable]
  public class BroadcastMessageCommand
  {
    public string Message { get; set; }
  }
}
