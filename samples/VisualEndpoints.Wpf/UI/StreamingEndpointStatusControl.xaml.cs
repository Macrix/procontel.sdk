using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProconTel.Sdk.Models;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;

namespace VisualEndpoints.Wpf.UI
{
  /// <summary>
  /// Interaction logic for StreamingEndpointStatusControl.xaml
  /// </summary>
  public partial class StreamingEndpointStatusControl : UserControl, IEndpointStatusControl
  {
    private readonly IEndpointCommandSender _endpointCommandSender;
    private readonly IStreamingService _streamingService;

    public StreamingEndpointStatusControl(IEndpointCommandSender endpointCommandSender)
    {
      _endpointCommandSender = endpointCommandSender;
      InitializeComponent();
    }


    #region Command_endpoint_share_stream

    private void Broadcast(object sender, RoutedEventArgs e)
    {
      _endpointCommandSender.SendCommandToServerEndpoint("broadcast");
    }

    private void NotifyUI(object sender, RoutedEventArgs e)
    {
      _endpointCommandSender.SendCommandToServerEndpoint("notify");
    }

    #endregion

    #region Receive_stream

    public Task DisplayStatusAsync(object statusInformation)
    {
      if (statusInformation == null)
        return Task.CompletedTask;

      //get stream
      if (statusInformation is IStreamDescriptor descriptor)
      {
        var stream = _streamingService.GetStream(descriptor.StreamId);
      }

      //get message body
      var type = statusInformation.GetType();
      if (type.IsGenericType)
      {
        var messageBody = type.GetProperty(nameof(StreamDescriptor<object>.Data))?.GetValue(statusInformation);
      }


      return Task.CompletedTask;
    }

    #endregion

    public Task OnStatusControlHiddenAsync()
    {
      return Task.CompletedTask;
    }

    public Task OnStatusControlShownAsync()
    {
      return Task.CompletedTask;
    }
  }
}
