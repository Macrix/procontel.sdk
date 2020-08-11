using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;

namespace VisualEndpoints.WinForms.UI
{
  public partial class FileUploadStatusControl : UserControl, IEndpointStatusControl
  {
    private readonly IFileUploaderService _fileTransfer;
    public FileUploadStatusControl()
    {
      InitializeComponent();
    }

    public FileUploadStatusControl(IFileUploaderService fileTransfer) : this()
    {
      _fileTransfer = fileTransfer;
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
      return Task.CompletedTask;
    }
  
    private async void btnUpload_Click(object sender, EventArgs e)
    {
      var result = openFileDialog1.ShowDialog();
      if (result == DialogResult.OK)
      {
        await _fileTransfer.UploadFilesAsync(new[] { new FileDescriptor() { Location = openFileDialog1.FileName } });
      }
    }
  }
}
