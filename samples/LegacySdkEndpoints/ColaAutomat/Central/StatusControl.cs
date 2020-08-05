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
using System.Net.NetworkInformation;
using ProconTel.Sdk.UI.Models;

namespace ColaAutomat.Central
{
  public partial class StatusControl : UserControl, IEndpointStatusControl
  {
    public StatusControl()
    {
      InitializeComponent();
    }

    public List<Vending.State> Transactions { get; }

    public void DisplayStatus(object statusInformation)
    {
      if (statusInformation is Central.State)
      {
        dataGridViewTransactions.DataSource = (statusInformation as Central.State).Transactions;
      }
    }

    public void OnStatusControlHidden()
    {
    }

    public void OnStatusControlShown()
    {
    }
  }
}
