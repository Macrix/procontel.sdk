using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebEndpoints.WebApiEndpoint.Middlewares
{
  public class ErrorHandlingMiddleware
  {
    readonly RequestDelegate _next;
    //static Microsoft.Extensions.Logging.ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next)
      //,
        //Microsoft.Extensions.Logging.ILogger<ErrorHandlingMiddleware> logger)
    {
      _next = next;
      //_logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    static async Task HandleExceptionAsync(
         HttpContext context,
         Exception exception)
    {
      string error = "An internal server error has occured.";
      error += $"{exception.Source} - {exception.Message} - {exception.StackTrace} - {exception.TargetSite.Name}";
      //_logger.Log<>($"{exception.Source} - {exception.Message} - {exception.StackTrace} - {exception.TargetSite.Name}");

      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      context.Response.ContentType = "application/json";

      await context.Response.WriteAsync(JsonConvert.SerializeObject(new
      {
        error
      }));

    }
  }
}
