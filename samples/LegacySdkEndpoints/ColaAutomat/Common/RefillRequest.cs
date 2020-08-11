using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaAutomat.Common
{
  [Serializable]
  public class RefillRequest
  {
    public string Vendor { get; internal set; }
    public DateTime Time { get; internal set; }
  }
}
