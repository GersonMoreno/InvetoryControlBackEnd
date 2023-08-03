using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Application.Ventas.Agregar
{
    public class AgregarRequest
    {
        public List<ArticuloVender>? Articulos { get; set; }
        public decimal? Descuento { get; set; }
        public long clienteId { get; set; }
    }
    public class ArticuloVender
    {
        public long ArticuloId { get; set; }
        public int Cantidad { get; set; }
    }
}
