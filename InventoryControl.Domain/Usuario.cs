using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Usuario: Entity<int>
    {
        public string? NombreUsuario { get; private set; }
        public string? Clave { get; private set; }
        public Persona? Persona { get; private set; }
    }
}
