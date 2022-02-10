using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using WebEndpoints.WebApiEndpoint.Protocols;

namespace WebEndpoints.WebApiEndpoint.Endpoints
{
  [EndpointMetadata(Name = "[Test] WebServer", SupportedRoles = SupportedRoles.Both)]
  [SimpleCustomProtocol]
  public class WebServerEndpoint : WebHostEndpoint<Startup>, IHandler
  {
    private readonly IConfigurationReader _configurationReader;
    private readonly IMessageBus _messageBus;

    public WebServerEndpoint(Func<ILogger> logger, Func<IRuntimeContext> runtimeContext,
      IConfigurationReader configurationReader, IMessageBus messageBus)
      : base(logger, runtimeContext)
    {
      _configurationReader = configurationReader;
      _messageBus = messageBus;
    }

    protected override void ConfigureServices(IServiceCollection ioc)
    {
      base.ConfigureServices(ioc);
      ioc.AddTransient(ctx => _configurationReader);
      ioc.AddTransient(ctx => _messageBus);
    }

    public bool CanHandle(string messageId, ICorrelationContext context = null)
    {
      return true;
    }

    public async Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      Logger.Debug($"Handling {messageId} {message}");
      return new Ack();
    }
  }
}

