using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.Services.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "IoC", SupportedRoles = SupportedRoles.Provider)]
  public class IoCEndpoint : IEndpointLifeTimeCycle
  {
    private readonly Func<string, ILogger> _loggerFactory;
    private readonly IServiceContext _serviceContext;

    public IoCEndpoint(IServiceContext serviceContext)
    {
      _serviceContext = serviceContext;
      _loggerFactory = _serviceContext.Resolve<Func<string, ILogger>>();
      _loggerFactory("Custom Origin").Information("Invoke constructor for endpoint IoC");
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public Task TerminateAsync() => Task.CompletedTask;  
  }
}
