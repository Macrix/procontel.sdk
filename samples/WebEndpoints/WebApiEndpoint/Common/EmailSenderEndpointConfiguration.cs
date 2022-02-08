using System;
using System.Collections.Generic;

namespace WebEndpoints.WebApiEndpoint.Common
{
  [Serializable]
  public class EmailSenderEndpointConfiguration
  {
    public string SmtpHost { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; }
    public string SmtpPass { get; set; }
    public string FromUser { get; set; }
    public string DevTestUser { get; set; }
  }
}
