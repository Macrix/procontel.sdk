using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications.Middlewares;
using ProconTel.Sdk.Services;

namespace WebEndpoints.WebApiEndpoint.Endpoints
{
  public abstract class WebHostEndpoint<TStartup> : IEndpointLifeTimeCycle where TStartup : class
  {
    protected IWebHost Host;
    private readonly string[] _defaultUrls = new[] { "http://*:5000" };
    public string[] Urls { get; protected set; }

    protected ILogger Logger { get; private set; }
    protected IRuntimeContext RuntimeContext { get; private set; }
    private readonly Func<ILogger> _loggerFactory;
    private readonly Func<IRuntimeContext> _runtimeContextFactory;
   

    public WebHostEndpoint(
      Func<ILogger> loggerFactory,
      Func<IRuntimeContext> runtimeContextFactory)
    {
      _loggerFactory = loggerFactory;
      _runtimeContextFactory = runtimeContextFactory;
      Logger = loggerFactory();
      RuntimeContext = runtimeContextFactory();
    }

    public Task InitializeAsync(IMiddlewareBuilder builder)
    {
      var urls = Urls ?? _defaultUrls;
      Logger.Information($"Start initialize web host, urls = { string.Join(", ", urls.ToArray()) } ");
      Host = Microsoft.AspNetCore.WebHost
        .CreateDefaultBuilder()
        .UseContentRoot(Path.GetDirectoryName(typeof(WebHostEndpoint<>).Assembly.Location))
        .ConfigureServices(ConfigureServices)
        .UseStartup<TStartup>()
        .UseUrls(urls)
        .Build();
      
      return Host.StartAsync();
    }

    protected virtual void ConfigureServices(IServiceCollection ioc)
    {
      ioc.AddTransient(ctx => _loggerFactory());
      ioc.AddTransient(ctx => _runtimeContextFactory());
    }

    public Task TerminateAsync()
    {
      Logger.Information($"Start terminating web host");
      if (Host != null)
      {
        return Host.StopAsync();
      }
      return Task.CompletedTask;
    }
  }
}
