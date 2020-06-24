using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Attributes;
using ProconTel.Sdk.UI.Models;
using System;
using System.Threading.Tasks;
using VisualEndpoints.Wpf.UI;

namespace VisualEndpoints.Wpf
{
    [StatusControl(typeof(WpfStatusControl), EndpointStatusControlType.Wpf)]
    //[StatusControlProvider(typeof(WpfStatusControlProvider))]
    [EndpointMetadata(Name = "WpfStatus", SupportedRoles = SupportedRoles.None)]
    public class WpfStatusEndpoint : ICommandHandler
    {
        private readonly ILogger _logger;
        private readonly IRuntimeContext _runtimeContext;
        public WpfStatusEndpoint(ILogger logger, IRuntimeContext runtimeContext)
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
