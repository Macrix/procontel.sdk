using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Services;
using System.Reflection;
using System.Threading.Tasks;
using ProconTel.Sdk.Communications.Middlewares;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "LifeTimeCycle", SupportedRoles = SupportedRoles.Both)]
  public class LifeTimeCycleEndpoint : IEndpointLifeTimeCycle
  {
    private readonly ILogger _logger;
    public LifeTimeCycleEndpoint(ILogger logger) => _logger = logger;

    public Task InitializeAsync(IMiddlewareBuilder builder)
    {
      _logger.Information($"Initialized endpoint {Assembly.GetExecutingAssembly().GetName().Version.ToString()}");
      return Task.CompletedTask;
    }

    public Task AfterActivateAsync()
    {
      _logger.Information("After activate async.");
      return Task.CompletedTask;
    }

    public Task TerminateAsync()
    {
      _logger.Information("Terminated.");
      return Task.CompletedTask;
    }
  }
}
