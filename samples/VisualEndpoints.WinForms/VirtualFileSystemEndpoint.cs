using System;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.UI.Attributes;
using UI.WinForms.NewSdk.Tests.Configurations;
using UI.WinForms.NewSdk.Tests.StatusControls;

namespace Communications.NewSdk.Tests
{
  [ConfigurationDialog(typeof(VirtualFileSystemConfigurationDialog))]
  [StatusControl(typeof(VirtualFileSystemStatusControl), ProconTel.Sdk.UI.Models.EndpointStatusControlType.WinForms)]
  [EndpointMetadata(Name = "[Test] VirtualFileSystem New Sdk", SupportedRoles = SupportedRoles.Both)]
  public class VirtualFileSystemEndpoint
  {
  }
}
