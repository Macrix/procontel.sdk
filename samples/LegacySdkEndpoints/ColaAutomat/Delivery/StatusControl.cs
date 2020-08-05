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

namespace ColaAutomat.Delivery
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
      if (statusInformation is Delivery.State)
      {
        dataGridViewRefill.DataSource = (statusInformation as Delivery.State).Orders;
      }
    }

    public void OnStatusControlHidden()
    {
    }

    public void OnStatusControlShown()
    {
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
