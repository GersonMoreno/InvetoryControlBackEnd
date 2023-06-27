using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Venta: Factura
    {
        public Persona? Cliente { get; private set; }
        public decimal? Subtotal { get; private set; }
        public decimal? Descuento { get; private set; }
    }
}
