using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Application.Ventas.Consultar
{
    public class ConsultarResponse
    {
        public long VentaId { get; set; }
        public decimal? Subtotal { get;  set; }
        public decimal? Descuento { get;  set; }
        public decimal? Total { get;  set; }
        public DateTime? Fecha { get;  set; }
        public string? NumeroIdentificacion { get; set; }
        public string? NombreCompleto { get; set; }
    }
}
