using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Central
{
  [Serializable]
  public class State
  {
    public List<Vending.State> Transactions { get; private set; }
    public State()
    {
      this.Transactions = new List<Vending.State>();
    }

  }
}
