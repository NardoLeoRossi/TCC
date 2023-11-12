using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc.Utils
{
    public class CustomEventArgsItemSinapiSelecionado : EventArgs
    {
        public object Tag { get; }

        public decimal Qntd { get; }

        public CustomEventArgsItemSinapiSelecionado(object tag, decimal qntd)
        {
            Tag = tag;
            Qntd = qntd;
        }
    }
}
