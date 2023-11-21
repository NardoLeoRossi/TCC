using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.QuantityResource;

namespace OrcamentosIfc.IFC
{
    public static class Extensoes
    {

        public static IfcAreaMeasure GetNetFloorArea(this IfcSpace space)
        {
            IfcQuantityArea qArea = space.GetQuantity<IfcQuantityArea>("BaseQuantities", "NetFloorArea");
            if (qArea == null) qArea = space.GetQuantity<IfcQuantityArea>("NetFloorArea");
            if (qArea != null) return qArea.AreaValue;

            qArea = space.GetQuantity<IfcQuantityArea>("GSA Space Areas", "GSA BIM Area");
            if (qArea != null) return qArea.AreaValue;

            return 0;
        }


    }
}
