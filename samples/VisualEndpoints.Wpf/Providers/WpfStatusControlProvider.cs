using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Providers;
using ProconTel.Sdk.UI.Services;
using VisualEndpoints.Wpf.UI;

namespace VisualEndpoints.Wpf.Providers
{
    public class WpfStatusControlProvider : IEndpointStatusControlProvider
    {
        public bool SupportsDialogOnlineUpgrade => true;

        public bool SupportsCommunicationConsole => true;

        private readonly IEndpointStatusControl _control;
        private readonly IEndpointCommandSender _sender;
        private readonly ILocalStorage _localStorage;
        private readonly ISecurityService _securityService;
        public WpfStatusControlProvider(IEndpointCommandSender sender, ILocalStorage localStorage, ISecurityService securityService)
        {
            _sender = sender;
            _localStorage = localStorage;
            _securityService = securityService;
            _control = new WpfStatusControl(_sender, _localStorage, _securityService);
        }

        public object GetStatusControl() => _control;

        public EndpointStatusControlType GetStatusControlType() => EndpointStatusControlType.Wpf;

        public IEndpointStatusControl GetStatusDialogController() => _control;
    }
}
