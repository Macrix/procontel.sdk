using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;
using System;
using System.Windows.Forms;

namespace VisualEndpoints.WinForms.UI
{
  public partial class WinFormsStatusControl : UserControl, IEndpointStatusControl
  {
    private readonly IEndpointCommandSender _sender;
    public WinFormsStatusControl() => InitializeComponent();
    public WinFormsStatusControl(IEndpointCommandSender sender) : this() => _sender = sender;

    public void DisplayStatus(object statusInformation)
    {
      if (statusInformation != null)
      {
        //txtNotification.Text = txtNotification.Text.Insert(0, $"{DateTime.Now.ToString("HH:mm:ss")} {statusInformation.ToString()}{Environment.NewLine}");
      }
    }

    public void OnStatusControlHidden() { }
    public void OnStatusControlShown() { }

    //private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    //{
    //  txtConsole.Text = "Running...";
    //  try
    //  {
    //    var result = _sender.SendCommandToServerEndpoint(txtCommand.Text);
    //    txtConsole.Text = result.ToString();
    //  }
    //  catch (Exception ex)
    //  {
    //    txtConsole.Text = $"Something goes wrong. {ex.Message}";
    //  }
    //}
  }
}
