using Microsoft.AspNetCore.Http;
using ProconTel.Sdk.Services;
using System.Threading.Tasks;
using WebEndpoints.WebApiEndpoint.Common;

namespace WebEndpoints.WebApiEndpoint.Middlewares
{
  public class RequestLoggingMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    public RequestLoggingMiddleware(RequestDelegate next, ILogger logger, IRuntimeContext runtimeContext)
    {
      _next = next;
      _logger = logger;
      _runtimeContext = runtimeContext;
    }

    public async Task Invoke(HttpContext context)
    {
      var message = new HttpLog
      {
        Scheme = context.Request.Scheme,
        Host = context.Request.Host.ToString(),
        Path = context.Request.Path,
        QueryString = context.Request.QueryString.ToString(),
        Body = context.Response.Body.ToString()
      };
      _logger.Information(message.ToString());
      _runtimeContext.NotificationService.NotifyUI<HttpLog>(message, false);
      await _next(context);
    }
  }
}
