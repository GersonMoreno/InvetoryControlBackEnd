using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Proveedor: Entity
    {
        public string? Nombres { get; private set; }
        public string? Celular { get; private set; }
        public bool Habilitado { get; private set; }
        public Proveedor()
        {
            
        }
    }
}
