using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Attributes;
using ProconTel.Sdk.UI.Models;

namespace EndpointViewerWPF
{
  [StatusControl(typeof(StatusBar), EndpointStatusControlType.Wpf)]
  [EndpointMetadata(Name = "StatusBar", SupportedRoles = SupportedRoles.None)]
  public class StatusBarEndpoint : ICommandHandler
  {
    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    public StatusBarEndpoint(ILogger logger, IRuntimeContext runtimeContext)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
    }

    public Task<object> HandleCommandAsync(object command, ICorrelationContext context = null)
    {
      return Task.FromResult<object>("Done");
    }
  }
}
