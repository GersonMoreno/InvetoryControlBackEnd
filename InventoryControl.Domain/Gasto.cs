using InventoryControl.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain
{
    public class Gasto: Entity<int>
    {
        public string? Descripcion { get; private set; }
        public string? Valor { get; private set; }
        public Persona? Persona { get; private set; }
        public bool EsConstante { get; private set; }
        public bool Habilitado { get; private set; }
        public Gasto()
        {
            
        }
    }
}
