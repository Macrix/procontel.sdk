using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows;
using ProconTel.Extensions.Services;
using ProconTel.IoC;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;
using Controls = System.Windows.Controls;
using System.Linq;

namespace EndpointViewerWPF
{
  /// <summary>
  /// Interaction logic for StatusBar.xaml
  /// </summary>
  public partial class StatusBar : Controls.UserControl, IEndpointStatusControl
  {
    internal IHost hostService;

    public StatusBar(IEndpointCommandSender sender)
    {
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
      hostService?.DisplayStatus("Test", "Test Status Bar", ImageToByteArray(Properties.Resources.green));
      return Task.CompletedTask;
    }

    private void UpdateStatusBar(object sender, RoutedEventArgs routedEventArgs)
    {
      Parallel.ForEach(Enumerable.Range(0, 25), async number =>
      {
        hostService?.DisplayStatus($"Test{number % 2}", $"Test updated!{number}", ImageToByteArray(Properties.Resources.red));
        hostService.SetTitle("asdd");
        await Task.Delay(1000);
      });
    }

    private void DeleteStatusBar(object sender, RoutedEventArgs routedEventArgs)
    {
      hostService?.DisplayStatus("Test", null, null);
    }

    private byte[] ImageToByteArray(Image imageIn)
    {
      using MemoryStream ms = new();
      imageIn.Save(ms, imageIn.RawFormat);
      return ms.ToArray();
    }

  }
}
