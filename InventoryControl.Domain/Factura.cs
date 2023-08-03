using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public abstract class Factura: Entity
    {
        public List<DetalleFactura>? DetallesFactura { get; protected set; }
        public Usuario? Usuario { get; protected set; }
        public decimal? Total { get; protected set; }
        public DateTime? Fecha { get; protected set; }

        public Factura(FacturaDTO DTO)
        {
            if (DTO is null) throw new Exception("La factura no puede ser nula.");
            if (DTO.Usuario is null || DTO.Usuario.Id <= 0 || !DTO.Usuario.Habilitado) throw new Exception("El usuario no puede ser nulo o vacío y debe estar habilitado.");
            if (DTO.Fecha is null) throw new Exception("La fecha no puede ser nulo.");

            Total = 0m;
            Usuario = DTO.Usuario;
            Fecha = DTO.Fecha;
            DetallesFactura = new List<DetalleFactura>();
        }
        public Factura()
        {
            
        }
    }
    public class FacturaDTO
    {
        public Usuario? Usuario { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
