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
using ColaAutomat.Common;
using System.Net.NetworkInformation;

namespace ColaAutomat.Central
{
  public partial class StatusControl : UserControl, IEndpointStatusControl
  {
    public StatusControl()
    {
      InitializeComponent();
    }

    public IEndpointStatusController Context { get; internal set; }
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
