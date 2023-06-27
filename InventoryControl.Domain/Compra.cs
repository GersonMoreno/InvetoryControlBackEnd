using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Compra:Factura
    {
        public Proveedor? Proveedor { get; private set; }
    }
}
