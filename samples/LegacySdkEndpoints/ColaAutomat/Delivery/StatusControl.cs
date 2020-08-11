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
using ColaAutomat.Common;
using ProconTel.Sdk.UI.Models;

namespace ColaAutomat.Delivery
{
  public partial class StatusControl : UserControl, IEndpointStatusControl
  {
    public StatusControl()
    {
      InitializeComponent();
    }

    public Task DisplayStatusAsync(object statusInformation)
    {
      if (statusInformation is Delivery.State)
      {
        dataGridViewRefill.DataSource = (statusInformation as Delivery.State).Orders;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
