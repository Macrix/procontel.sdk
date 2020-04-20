using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Attributes;
using ProconTel.Sdk.UI.Models;
using System;
using System.Threading.Tasks;
using VisualEndpoints.WinForms.Providers;
using VisualEndpoints.WinForms.UI;

namespace VisualEndpoints.WinForms
{
  [StatusControl(typeof(WinFormsStatusControl), EndpointStatusControlType.WinForms)]
  //[StatusControlProvider(typeof(WinFormsStatusControlProvider))]
  [EndpointMetadata(Name = "WinFormsStatus", SupportedRoles = SupportedRoles.None)]
  public class WinFormsStatusEndpoint : ICommandHandler
  {
    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    public WinFormsStatusEndpoint(ILogger logger, IRuntimeContext runtimeContext)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
    }

    public Task<object> HandleCommandAsync(object command, ICorrelationContext context = null)
    {
      _logger.Information($"Received command from status control {command}");
      switch (command)
      {
        case "dowork": _logger.Information($"Let's do some work!"); break;
        case "notify": _runtimeContext.NotificationService.NotifyUI($"Notify from { _runtimeContext.MetadataContext.Caption} ", false); break;
        default: throw new NotSupportedException($"Command {command} is not supported.");
      }
      return Task.FromResult<object>("Done");
    }
  }
}
