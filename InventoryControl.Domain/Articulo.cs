using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Articulo:Entity<int>
    {
        public string? Descripcion { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Utilidad { get; private set; }
        public bool Habilitado { get; private set; }
    }
}
