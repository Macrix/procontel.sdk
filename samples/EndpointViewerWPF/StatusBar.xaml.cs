using System;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows;
using ProconTel.Extensions.Services;
using ProconTel.IoC;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;
using Controls = System.Windows.Controls;

namespace EndpointViewerWPF
{
  /// <summary>
  /// Interaction logic for StatusBar.xaml
  /// </summary>
  public partial class StatusBar : Controls.UserControl, IEndpointStatusControl
  {
    private readonly IEndpointCommandSender _sender;

    internal IHost hostService;

    public StatusBar(IEndpointCommandSender sender)
    {
      _sender = sender;
      InitializeComponent();
      hostService = ServiceLocator.Instance.GetService<IHost>();
    }

    public Task DisplayStatusAsync(object statusInformation)
    {
      return Task.CompletedTask;
    }

    public Task OnStatusControlHiddenAsync()
    {
      return Task.CompletedTask;
    }

    public Task OnStatusControlShownAsync()
    {
      hostService.DisplayStatus("Test", "Test Status Bar", ImageToByteArray(Image.FromFile("pack://application:,,,/assets/green.png")));
      return Task.CompletedTask;
    }

    private void UpdateStatusBar(object sender, RoutedEventArgs routedEventArgs)
    {
      hostService.DisplayStatus("Test", "Test updated!", ImageToByteArray(Image.FromFile("pack://application:,,,/assets/red.png")));
    }

    private void DeleteStatusBar(object sender, RoutedEventArgs routedEventArgs)
    {
      hostService.DisplayStatus("Test", null, null);
    }

    private byte[] ImageToByteArray(Image imageIn)
    {
      using (var ms = new MemoryStream())
      {
        imageIn.Save(ms, imageIn.RawFormat);
        return ms.ToArray();
      }
    }

  }
}
