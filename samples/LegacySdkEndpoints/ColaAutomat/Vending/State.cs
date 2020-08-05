using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Vending
{
  [Serializable]
  public class State
  {
    public int NoColaBottles { get; internal set; }
    public int NoLimonadeBottles { get; internal set; }
    public int NoWaterBottles { get; internal set; }
    public string Vendor { get; internal set; }
    public DateTime Time { get; internal set; }
  }
}
