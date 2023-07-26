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
            return new Venta(null, null);
        }
        public Venta SinUsuario()
        {
            var facturaDTO = new FacturaDTO();
            return new Venta(facturaDTO, null);
        }
        public Venta ConUsuarioVacio()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            return new Venta(facturaDTO, null);
        }
        public Venta ConFechaNula()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = null;
            return new Venta(facturaDTO, null);
        }
        public Venta ConVentaNula()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            return new Venta(facturaDTO, null);
        }
        public Venta ConClienteNulo()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = null;
            return new Venta(facturaDTO, ventaDTO);
        }
        public Venta ConClienteVacio()
        {
            var facturaDTO = new FacturaDTO();
            facturaDTO.Usuario = new Usuario();
            facturaDTO.Usuario.AsignarId();
            facturaDTO.Fecha = DateTime.Now;
            var ventaDTO = new VentaDTO();
            ventaDTO.Cliente = new Persona();
            return new Venta(facturaDTO, ventaDTO);
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
            return new Venta(facturaDTO, ventaDTO);
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
            return new Venta(facturaDTO, ventaDTO);
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
            return new Venta(facturaDTO, ventaDTO);
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
            return new Venta(facturaDTO, ventaDTO);
        }
    }
}
