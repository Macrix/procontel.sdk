using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Providers;
using ProconTel.Sdk.UI.Services;
using VisualEndpoints.WinForms.UI;

namespace VisualEndpoints.WinForms.Providers
{
  public class WinFormsStatusControlProvider : IEndpointStatusControlProvider
  {
    public bool SupportsDialogOnlineUpgrade => true;

    public bool SupportsCommunicationConsole => true;

    private readonly IEndpointStatusControl _control;
    private readonly IEndpointCommandSender _sender;
    public WinFormsStatusControlProvider(IEndpointCommandSender sender)
    {
      _sender = sender;
      _control = new WinFormsStatusControl(_sender);
    }

    public object GetStatusControl() => _control;

    public EndpointStatusControlType GetStatusControlType() => EndpointStatusControlType.WinForms;

    public IEndpointStatusControl GetStatusDialogController() => _control;
  }
}
