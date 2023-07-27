using InventoryControl.Domain.Base;
using InventoryControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Usuario: Entity
    {
        public Rol Rol { get; private set; }
        public string? NombreUsuario { get; private set; }
        public string? Clave { get; private set; }
        public Persona? Persona { get; private set; }
        public bool Habilitado { get; private set; }
        public Usuario()
        {
            
        }

    }
}
