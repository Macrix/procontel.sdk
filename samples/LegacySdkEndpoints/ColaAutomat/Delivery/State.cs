using ColaAutomat.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Delivery
{
  [Serializable]
  class State
  {
    public State()
    {
      Orders = new List<RefillRequest>();
    }
    public List<RefillRequest> Orders { get; internal set; }

  }
}
