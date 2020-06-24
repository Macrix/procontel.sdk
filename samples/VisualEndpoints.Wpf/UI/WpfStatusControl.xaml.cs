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
        private readonly IEndpointCommandSender _sender;
        private readonly ILocalStorage _localStorage;
        private readonly ISecurityService _securityService;
        public WpfStatusControl() => InitializeComponent();
        public WpfStatusControl(IEndpointCommandSender sender, ILocalStorage localStorage, ISecurityService securityService) : this()
        {
            _sender = sender;
            _localStorage = localStorage;
            _securityService = securityService;
        }
        public void DisplayStatus(object statusInformation)
        {
            if (statusInformation != null)
            {
                txtNotifications.Text = txtNotifications.Text.Insert(0, $"{DateTime.Now.ToString("HH:mm:ss")} {statusInformation.ToString()}{Environment.NewLine}");
            }
        }

        public void OnStatusControlHidden() { }

        public void OnStatusControlShown()
        {
            var theme = _localStorage.ReadValue<object>("theme");
            cbxTheme.SelectedItem = cbxTheme.Items.OfType<ComboBoxItem>().SingleOrDefault(x => x.Content.Equals(theme));
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            txtConsole.Text = "Running...";
            try
            {
                var commands = txtCommand.Text.Split(' ');
                switch (commands.FirstOrDefault())
                {
                    case "login":
                        {
                            _securityService.SignOut();
                            var auth = commands[1];
                            var token = _securityService.Authenticate(auth);
                            if (_securityService.IsAuthorized)
                            {
                                txtConsole.Text = $"Login successed.";
                            }
                            else
                            {
                                txtConsole.Text = $"Login failed.";
                            }
                            
                            break;
                        }
                    case "isinrole":
                        {
                            var role = commands[1];
                            txtConsole.Text = $"Is in role {role}: { _securityService.IsInRole(role)}";
                            break;
                        }
                    default:
                        {
                            var result = _sender.SendCommandToServerEndpoint(txtCommand.Text);
                            txtConsole.Text = result.ToString();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                txtConsole.Text = $"Something goes wrong. {ex.Message}";
            }
        }

        private void cbxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxTheme.SelectedItem is ComboBoxItem item)
            {
                _localStorage.WriteValue("theme", item.Content);
            }
        }
    }
}
