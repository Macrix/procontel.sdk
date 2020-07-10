using System;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Models;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Attributes;
using VisualEndpoints.WinForms.UI;

namespace VisualEndpoints.WinForms
{
  [ConfigurationDialog(typeof(FileUploadConfigurationDialog))]
  [StatusControl(typeof(FileUploadStatusControl), ProconTel.Sdk.UI.Models.EndpointStatusControlType.WinForms)]
  [EndpointMetadata(Name = "File Receiver", SupportedRoles = SupportedRoles.None)]
  public class FileReceiverEndpoint : IFileHandler
  {
    private readonly ILogger _logger;

    public FileReceiverEndpoint(ILogger logger)
    {
      _logger = logger;
    }
    public Task<object> HandleFileAsync(IUploadedFiles uploadedFiles)
    {
      _logger.Information($"Execute {nameof(HandleFileAsync)}. Transfered files: {String.Join(",", uploadedFiles.TransferedFiles)}.");

      uploadedFiles.AutoRemoveFiles = false;

      return Task.FromResult(new object());
    }
  }
}
