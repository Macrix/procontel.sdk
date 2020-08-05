using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Attributes;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;
using VisualEndpoints.WinForms.Providers;
using VisualEndpoints.WinForms.UI;

namespace UI.CustomMenuItems.NewSdk.Tests
{

  public class MenuItemAction : IMenuItemAction
  {
    public MenuItemAction()
    {
    }
    public Task ExecuteAsync()
    {
      new GenericConfigurationDialog<string>().ShowDialog();
      return Task.CompletedTask;
    }
  }

  [ConfigurationDialogProvider(typeof(GenericConfigurationDialogProvider))]
  [EndpointMetadata(Name = "Custom Menu Items", SupportedRoles = SupportedRoles.Both)]
  [MenuItem("1", "Items")]
  [MenuItem("2", "1", "MenuItem1", typeof(MenuItemAction))]
  [MenuItem("3", "1", "MenuItem2", typeof(MenuItemAction))]
  public class MenuItemsEndpoint
  {
    public MenuItemsEndpoint()
    {
    }
  }
}
