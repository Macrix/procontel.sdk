using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Communications.Middlewares;
using ProconTel.Sdk.Services;

namespace WebEndpoints.WebApiEndpoint.Endpoints
{
  [EndpointMetadata(Name = "[Test] WebServer", SupportedRoles = SupportedRoles.Both)]
  public class WebHostEndpoint : IEndpointLifeTimeCycle
  {
    protected IWebHost Host;
    private readonly string[] _defaultUrls = new[] { "http://*:5000" };
    public string[] Urls { get; protected set; }

    protected ILogger _logger { get; private set; }
    private readonly IRuntimeContext _runtimeContext;
    private readonly IMessageBus _messageBus;

    public WebHostEndpoint(
     ILogger logger,
      IRuntimeContext runtimeContext,
      IMessageBus messageBus)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
      _messageBus = messageBus;
    }

    public Task InitializeAsync(IMiddlewareBuilder builder)
    {
      var urls = Urls ?? _defaultUrls;
      _logger.Information($"Start initialize web host, urls = { string.Join(", ", urls.ToArray()) } ");
      Host = Microsoft.AspNetCore.WebHost
        .CreateDefaultBuilder()
        .UseContentRoot(Path.GetDirectoryName(typeof(WebHostEndpoint).Assembly.Location))
        .ConfigureServices(ConfigureServices)
        .UseStartup<Startup>()
        .UseUrls(urls)
        .Build();
      
      return Host.StartAsync();
    }

    protected virtual void ConfigureServices(IServiceCollection ioc)
    {
      ioc.AddTransient(ctx => _logger);
      ioc.AddTransient(ctx => _runtimeContext);
      ioc.AddTransient(ctx => _messageBus);
    }

    public Task TerminateAsync()
    {
      _logger.Information($"Start terminating web host");
      if (Host != null)
      {
        return Host.StopAsync();
      }
      return Task.CompletedTask;
    }
  }
}
