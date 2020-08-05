using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProconTel.CommunicationCenter.Kernel;
using System.Security.Cryptography;
using ColaAutomat.Common;

namespace ColaAutomat.Vending
{
  public partial class StatusControl : UserControl, IEndpointStatusControl
  {
    public StatusControl()
    {
      InitializeComponent();
    }

    public IEndpointStatusController Context { get; internal set; }

    public void DisplayStatus(object statusInformation)
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
    }

    public void OnStatusControlHidden()
    {
    }

    public void OnStatusControlShown()
    {
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
      DisplayStatus(Context.SendCommandToServerEndpoint(action));
    }

    private void Auffuellen_Click(object sender, EventArgs e)
    {
      DisplayStatus(Context.SendCommandToServerEndpoint(Actions.Refill));
    }
  }
}
