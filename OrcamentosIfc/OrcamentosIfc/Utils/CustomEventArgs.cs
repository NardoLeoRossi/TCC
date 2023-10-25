using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc.Utils
{
    public class CustomEventArgs : EventArgs
    {
        public object Tag { get; }

        public CustomEventArgs(object tag = null)
        {
            Tag = tag;
        }
    }
}
