using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProconTel.Sdk.Legacy;
using System.Security.Cryptography;
using ColaAutomat.Common;
using ProconTel.Sdk.UI.Models;
using ProconTel.Sdk.UI.Services;

namespace ColaAutomat.Vending
{
  public partial class StatusControl : UserControl, IEndpointStatusControl
  {
    private readonly IEndpointCommandSender _sender;
    public StatusControl(IEndpointCommandSender sender)
    {
      InitializeComponent();

      _sender = sender;
    }

    public Task DisplayStatusAsync(object statusInformation)
    {
      if (statusInformation is State)
      {
        var state = statusInformation as State;
        ColaInfo.Text = state.NoColaBottles.ToString();
        Cola.Enabled = 0 < state.NoColaBottles;

        LimonadeInfo.Text = state.NoLimonadeBottles.ToString();
        Limonade.Enabled = 0 < state.NoLimonadeBottles;

        WasserInfo.Text = state.NoWaterBottles.ToString();
        Wasser.Enabled = 0 < state.NoWaterBottles;
      }
      return Task.CompletedTask;
    }

    public Task OnStatusControlHiddenAsync()
    {
      return Task.CompletedTask;
    }

    public Task OnStatusControlShownAsync()
    {
      return Task.CompletedTask;
    }

    private void Kaufen_Click(object sender, EventArgs e)
    {
      var button = sender as Button;
      var action = Actions.None;
      if (button == Cola)
      {
        action = Actions.SellCola;
      }
      else if (button == Limonade)
      {
        action = Actions.SellLimonade;
      }
      else if (button == Wasser)
      {
        action = Actions.SellWater;
      }
      else
      {
        return;
      }
      DisplayStatusAsync(_sender.SendCommandToServerEndpoint(action));
    }

    private void Auffuellen_Click(object sender, EventArgs e)
    {
      DisplayStatusAsync(_sender.SendCommandToServerEndpoint(Actions.Refill));
    }
  }
}
