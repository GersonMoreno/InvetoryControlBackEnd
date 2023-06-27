using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Persona: Entity<int>
    {
        public string? NumeroIdentificacion { get; private set; }
        public string? Nombres { get; private set; }
        public string? Apellidos { get; private set; }
        public string? Celular { get; private set; }
    }
}
