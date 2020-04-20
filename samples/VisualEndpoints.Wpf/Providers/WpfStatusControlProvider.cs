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
    public WpfStatusControlProvider(IEndpointCommandSender sender)
    {
      _sender = sender;
      _control = new WpfStatusControl(_sender);
    }

    public object GetStatusControl() => _control;

    public EndpointStatusControlType GetStatusControlType() => EndpointStatusControlType.Wpf;

    public IEndpointStatusControl GetStatusDialogController() => _control;
  }
}
