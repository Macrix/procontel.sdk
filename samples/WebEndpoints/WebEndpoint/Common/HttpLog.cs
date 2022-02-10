using System;

namespace WebEndpoints.WebApiEndpoint.Common
{
  [Serializable]
  public class HttpLog
  {
    public string Scheme { get; set; }
    public string Host { get; set; }
    public string Path { get; set; }
    public string QueryString { get; set; }
    public string Body { get; set; }
    public override string ToString()
    {
      return $"Schema:{Scheme} " +
            $"Host: {Host} " +
            $"Path: {Path} " +
            $"QueryString: {QueryString} " +
            $"Response Body: {Body}";
    }
  }
}
