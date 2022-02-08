using System;

namespace WebEndpoint.WebCommon.Commands
{
  [Serializable]
  public class BroadcastMessageCommand
  {
    public string Message { get; set; }
  }
}
