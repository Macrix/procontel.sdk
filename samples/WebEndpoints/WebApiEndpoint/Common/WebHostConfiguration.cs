using System;
using System.Collections.Generic;

namespace WebEndpoints.WebApiEndpoint.Common
{
  [Serializable]
  public class WebHostConfiguration
  {
    public List<string> Urls { get; set; } = new List<string>();
    public bool UseHttps { get; set; }
    public bool ForceHttps { get; set; }
    public bool SSLFromFile { get; set; } = true;
    public string SSLFilePath { get; set; } 
    public string SSLFilePathPassword { get; set; }
    public string SSLStoreName { get; set; }
    public string SSLSubject { get; set; }
    
  }
}
