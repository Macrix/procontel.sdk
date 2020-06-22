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
        public WpfStatusControl() => InitializeComponent();
        public WpfStatusControl(IEndpointCommandSender sender, ILocalStorage localStorage) : this()
        {
            _sender = sender;
            _localStorage = localStorage;
        }
        public void DisplayStatus(object statusInformation)
        {
            if (statusInformation != null)
            {
                txtNotifications.Text = txtNotifications.Text.Insert(0, $"{DateTime.Now.ToString("HH:mm:ss")} {statusInformation.ToString()}{Environment.NewLine}");
            }
        }

        public void OnStatusControlHidden(){}

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
                var result = _sender.SendCommandToServerEndpoint(txtCommand.Text);
                txtConsole.Text = result.ToString();
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
