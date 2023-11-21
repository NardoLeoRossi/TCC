using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbim.Ifc;
using Xbim.Ifc2x3.Interfaces;

namespace OrcamentosIfc.Utils
{
    public class CustomEventArgsItemSinapiSelecionado : EventArgs
    {
        public object Tag { get; }

        public decimal? Qntd { get; }

        public string Dimensao{ get; }

        public CustomEventArgsItemSinapiSelecionado(object tag, string dimensao, decimal? qntd)
        {
            Tag = tag;
            Qntd = qntd;
            Dimensao = dimensao;
        }
    }

    public class CostumEventArgsElementoIfcSelecionado: EventArgs
    {
        public IIfcElement Element { get; }
        
        public IfcStore Model { get; }

        public CostumEventArgsElementoIfcSelecionado(IIfcElement element, IfcStore model)
        {
            Element = element;
            Model = model;
        }        
    }
}
