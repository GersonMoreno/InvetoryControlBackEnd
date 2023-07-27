using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain.Test.Utilidades
{
    public class ObjetosVenta
    {
        
        public Venta ConFacturaNula()
        {
            return new Venta(null, null, null);
        }
        
        public Venta SinUsuario()
        {
            var facturaDTO = new FacturaDTO();
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, null,caja);
        }
        public Venta ConUsuarioVacio()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, null, caja);
        }
        public Venta ConFechaNula()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = null;
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, null, caja);
        }
        public Venta ConVentaNula()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, null, caja);
        }

        public Venta ConCajaNula()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = null;
            return new Venta(facturaDTO, ventaDTO, null);
        }
        public Venta ConCajaVacia()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = null;
            var caja = new Caja();
            return new Venta(facturaDTO, ventaDTO, caja);
        }
        public Venta ConCajaCerrada()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = null;
            var caja = new Caja();
            caja.AsignarId();
            caja.CerrarCaja();
            return new Venta(facturaDTO, ventaDTO, caja);
        }
        public Venta ConClienteNulo()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = null;
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, ventaDTO, caja);
        }
        public Venta ConClienteVacio()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = new Persona();
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, ventaDTO, caja);
        }
        public Venta ConDescuentoNulo()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = new Persona();
            ventaDTO.Cliente.AsignarId();
            ventaDTO.Descuento = null;
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, ventaDTO, caja);
        }
        public Venta ConDescuentoMenor0()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = new Persona();
            ventaDTO.Cliente.AsignarId();
            ventaDTO.Descuento = -2000;
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, ventaDTO, caja);
        }
        public Venta Exitosa()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = new Persona();
            ventaDTO.Cliente.AsignarId();
            ventaDTO.Descuento = 0;
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, ventaDTO, caja);
        }
        public Venta ConDescuentode4000()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;

            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = new Persona();
            ventaDTO.Cliente.AsignarId();
            ventaDTO.Descuento = 4000;
            var caja = new Caja();
            caja.AsignarId();
            return new Venta(facturaDTO, ventaDTO, caja);
        }

    }
}
