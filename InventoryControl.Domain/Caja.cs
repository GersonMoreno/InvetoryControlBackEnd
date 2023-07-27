using InventoryControl.Domain.Base;
using InventoryControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Caja:Entity
    {
        public Usuario? Usuario { get; private set; }
        public EstadoCaja Estado { get; private set; }
        public DateTime FechaApertura { get; private set; }
        public DateTime FechaCierre { get; private set; }
        public Caja()
        {
            
        }
        public void CerrarCaja()
        {
            Estado = EstadoCaja.Cerrada;
        }
    }

}
