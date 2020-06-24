using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Controls;

namespace VisualEndpoints.Wpf.UI
{
    public partial class WpfStatusControl : UserControl, IEndpointStatusControl
    {
        private readonly ISecurityService _securityService;
        public WpfStatusControl() => InitializeComponent();
        public WpfStatusControl(ISecurityService securityService) : this() => _securityService = securityService;

        public void DisplayStatus(object statusInformation) { }
        public void OnStatusControlHidden() { }
        public void OnStatusControlShown() { }

        public void Logout(object sender, System.Windows.RoutedEventArgs e)
        {
            _securityService.SignOut();
        }

        public void Login(object sender, System.Windows.RoutedEventArgs e)
        {
            var isAdministrator = false;
            var authorized = _securityService.Authenticate(hashLoginAdpassword);
            if (authorized)
            {
                isAdministrator = _securityService.IsInRole("administrator");
            }
        }
    }
}
