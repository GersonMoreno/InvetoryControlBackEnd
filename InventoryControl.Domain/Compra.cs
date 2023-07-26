using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Compra:Factura
    {
        public Compra(FacturaDTO facturaDTO):base(facturaDTO)

        {
            
        }
        public Compra()
        {
            
        }
        public Proveedor? Proveedor { get; private set; }
    }
}
