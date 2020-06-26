using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualEndpoints.WinForms.Providers;

namespace VisualEndpoints.WinForms
{
    [EndpointMetadata(Name = "Generic Configuration Endpoint Loosely Coupled", SupportedRoles = SupportedRoles.None)]
    [ConfigurationDialogProvider("VisualEndpoints.WinForms", "GenericConfigurationDialogProvider")]
    public class GenericConfigurationEndpointLooselyCoupled
    {
    }

    [EndpointMetadata(Name = "Generic Configuration Endpoint", SupportedRoles = SupportedRoles.None)]
    [ConfigurationDialogProvider(typeof(GenericConfigurationDialogProvider))]
    public class GenericConfigurationEndpoint
    {
    }
}
