using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public abstract class Factura: Entity<int>
    {
        public List<Articulo>? Articulos { get; protected set; }
        public Usuario? Usuario { get; protected set; }
        public decimal? Total { get; protected set; }
        public DateTime? Fecha { get; protected set; }
    }
}
