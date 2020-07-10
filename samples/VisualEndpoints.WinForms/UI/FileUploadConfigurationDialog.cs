using System;
using System.Windows.Forms;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;

namespace VisualEndpoints.WinForms.UI
{
  public partial class FileUploadConfigurationDialog : Form
  {
    private readonly IFileUploaderService _fileTransfer;

    public FileUploadConfigurationDialog()
    {
      InitializeComponent();
    }

    public FileUploadConfigurationDialog(IFileUploaderService fileTransfer)
      : this()
    {
      _fileTransfer = fileTransfer;
    }

    private async void btnUpload_Click(object sender, EventArgs e)
    {
      var result = openFileDialog1.ShowDialog();
      if(result == DialogResult.OK)
      {
        await _fileTransfer.UploadFilesAsync(new[] { new FileDescriptor() { Location = openFileDialog1.FileName } });

      }
      DialogResult = DialogResult.OK;
    }
  }
}
