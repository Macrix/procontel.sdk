using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;
using System;
using System.Windows.Controls;

namespace VisualEndpoints.Wpf.UI
{
  public partial class WpfStatusControl : UserControl, IEndpointStatusControl
  {
    private readonly IEndpointCommandSender _sender;
    public WpfStatusControl() => InitializeComponent();
    public WpfStatusControl(IEndpointCommandSender sender) : this() => _sender = sender;

    public void DisplayStatus(object statusInformation)
    {
      if (statusInformation != null)
      {
        txtNotifications.Text = txtNotifications.Text.Insert(0, $"{DateTime.Now.ToString("HH:mm:ss")} {statusInformation.ToString()}{Environment.NewLine}");
      }
    }

    public void OnStatusControlHidden() { }
    public void OnStatusControlShown() { }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
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
