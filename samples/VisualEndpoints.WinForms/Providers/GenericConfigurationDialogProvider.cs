using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Providers;
using ProconTel.Sdk.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualEndpoints.WinForms.Models;
using VisualEndpoints.WinForms.UI;

namespace VisualEndpoints.WinForms.Providers
{
    public class GenericConfigurationDialogProvider : IEndpointConfigurationDialogProvider
    {
        private readonly GenericConfigurationDialog<PlantConfiguration> _configurationDialog;
        public GenericConfigurationDialogProvider(IConfigurationWriter configurationWriter,
          IConfigurationReader configurationReader,
          IEndpointCommandSender endpointCommandSender)
        => _configurationDialog = new GenericConfigurationDialog<PlantConfiguration>();

        public object ConfigurationDialog => _configurationDialog;
    }
}
