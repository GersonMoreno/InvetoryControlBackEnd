using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class DetalleFactura: Entity
    {
        public Articulo? Articulo { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public DetalleFactura(DetalleFacturaDTO DTO)
        {
            if (DTO is null) throw new Exception("EL detalle de la factura no puede ser nulo.");
            if (DTO.Articulo is null || DTO.Articulo.Id <= 0) throw new Exception("El articulo no puede ser nulo o vacío.");
            if (DTO.Cantidad < 0) throw new Exception("La cantidad no puede ser nula.");

            Articulo = DTO.Articulo;
            Cantidad = DTO.Cantidad;
            Costo = Articulo.Costo;
            Precio = Articulo.Precio;
            
        }
        public DetalleFactura()
        {
            
        }
    }
    public class DetalleFacturaDTO
    {
        public Articulo? Articulo { get; set; }

        public int Cantidad { get;  set; }
    }
}
