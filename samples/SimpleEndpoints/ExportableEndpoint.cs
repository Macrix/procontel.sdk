using System;
using System.IO;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;

namespace SimpleEndpoints
{
  [EndpointMetadata(Name = "Exportable Endpoint", SupportedRoles = SupportedRoles.None)]
  public class ExportableEndpoint : IExportable
  {
    public async Task ImportContentDirectoryAsync(byte[] directory)
    {
      using (var file = File.Open("C:\\some-file.txt", FileMode.Create))
        await file.WriteAsync(directory, 0, directory.Length);
    }

    public Task<byte[]> ExportContentDirectoryAsync()
    {
      var message = $"{DateTime.Now} {Guid.NewGuid()}";
      return Task.FromResult(System.Text.Encoding.UTF8.GetBytes(message));
    }
  }
}
