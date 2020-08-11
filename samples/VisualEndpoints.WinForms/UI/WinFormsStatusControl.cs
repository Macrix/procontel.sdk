using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualEndpoints.WinForms.UI
{
  public partial class WinFormsStatusControl : UserControl, IEndpointStatusControl
  {
    private readonly IEndpointCommandSender _sender;
    public WinFormsStatusControl() => InitializeComponent();
    public WinFormsStatusControl(IEndpointCommandSender sender) : this() => _sender = sender;

    public Task DisplayStatusAsync(object statusInformation)
    {
      if (statusInformation != null)
      {
        txtNotifications.Text = txtNotifications.Text.Insert(0, $"{DateTime.Now.ToString("HH:mm:ss")} {statusInformation.ToString()}{Environment.NewLine}");
      }
      return Task.CompletedTask;
    }

    public Task OnStatusControlHiddenAsync()
    {
      return Task.CompletedTask;
    }
    public Task OnStatusControlShownAsync()
    {
      return Task.CompletedTask;
    }

    private void Button_Click(object sender, EventArgs e)
    {
      txtConsole.Text = "Running...";
      try
      {
        var result = _sender.SendCommandToServerEndpoint(txtCommand.Text);
        txtConsole.Text = result.ToString();
      }
      catch (Exception ex)
      {
        txtConsole.Text = $"Something goes wrong. {ex.Message}";
      }
    }
  }
}
