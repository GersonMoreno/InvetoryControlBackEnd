using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControl.Domain.Base;

namespace InventoryControl.Domain
{
    public class Venta: Factura
    {
        public Caja? Caja { get; private set; }
        public Persona? Cliente { get; private set; }
        public decimal? Subtotal { get; private set; }
        public decimal? Descuento { get; private set; }

        public Venta(FacturaDTO facutura, VentaDTO venta, Caja? caja) : base(facutura)
        {
            if (venta is null) throw new Exception("La venta no puede ser nula.");
            if(caja is null || caja.Id <= 0 || caja.Estado == Enums.EstadoCaja.Cerrada) throw new Exception("La caja debe estar abierta.");
            if (venta.Cliente is null || venta.Cliente.Id <= 0 ||! venta.Cliente.Habilitado) throw new Exception("El cliente no puede ser nulo o vacío y debe estar habilitado.");
            if (venta.Descuento is null || venta.Descuento < 0) throw new Exception("El descuento no puede ser nulo o menor que 0.");
            Subtotal = 0m;
            Cliente = venta.Cliente;
            Descuento = venta.Descuento;
            Caja = caja;
        }
        public Venta()
        {
            
        }
        public Response FacturarArticulo(ref Articulo articulo, int cantidad)
        {
            if(articulo.Cantidad <= 0) return new Response($"El articulo {articulo.Descripcion} no tiene stock, por favor revisar.");
            if (articulo.Habilitado is false) return new Response($"El articulo {articulo.Descripcion} esta deshabilitado, por favor revisar.");
            if (cantidad <= 0) return new Response($"La cantidad a vender del articulo {articulo.Descripcion} debe ser mayor a 0.");
            if (cantidad > articulo.Cantidad) return new Response($"La cantidad a vender del articulo {articulo.Descripcion} no puede ser mayor a la cantidad en stock.");
            

            articulo.RestarStock(cantidad);
            AgregarArticuloADetalle(articulo, cantidad);
            SumarAlSubTotal(articulo, cantidad);

            return new Response("Se facturó con éxito el articulo.", false);
        }

        public Response RealizarVenta()
        {
            if(DetallesFactura is null || !DetallesFactura.Any()) return new Response($"No se puede realizar una venta sin articulos facturados.");
            if(!puedeHacerDescuento()) return new Response($"No se puede hacer descuento {Descuento}, porque es mayor a las utilidades de la venta.");
            Total = Subtotal - Descuento;
            return new Response("Se realizó la venta correctamente.", false);
        }
        private  bool puedeHacerDescuento()
        {
            decimal? utilidadVenta = 0m;
            DetallesFactura?.ForEach(x =>
            {
                utilidadVenta += x.Articulo?.Utilidad;
            });
            return utilidadVenta - Descuento >= 0;
        }
        private void AgregarArticuloADetalle(Articulo articulo, int cantidad)
        {
            DetallesFactura?.Add(new DetalleFactura(new DetalleFacturaDTO()
            {
                Articulo = articulo,
                Cantidad = cantidad
            }));
        }
        private void SumarAlSubTotal(Articulo articulo, int cantidad)
        {
            Subtotal += (articulo.Precio * cantidad);
        }
    }
    public class VentaDTO
    {
        public Persona? Cliente { get; set; }
        public decimal? Descuento { get; set; }
    }
}
